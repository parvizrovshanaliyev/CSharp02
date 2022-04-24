using Blog.Shared.Enums;
using Blog.Shared.Extensions;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Shared.Helpers
{
    public class FileDto
    {
        public string FullName { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string SubDirectory { get; set; }
        public long Size { get; set; }
    }

    public interface IFileHelper
    {
        Task<IResult<FileDto>> UploadImageAsync(IFormFile file, ImageSubDirectoryEnum subDirectoryEnum,
            string subDirectory = default, string otherName = default);

        IResult<FileDto> DeleteImage(string fileName);
    }


    public class FileHelper : IFileHelper
    {
        #region ctor

        public FileHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        #endregion

        #region fields

        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string _imgFolder = "img";

        #endregion

        #region Implementation of IFileHelper

        public async Task<IResult<FileDto>> UploadImageAsync(IFormFile file, ImageSubDirectoryEnum subDirectoryEnum,
            string subDirectory, string otherName = null)
        {
            subDirectory ??= subDirectoryEnum.GetDisplayName();

            if (file.Length < 0)
                return new Result<FileDto>(ServiceResultCode.BadFile, null, BaseLocalization.NoDataAvailableOnRequest);

            var directory = $"{_wwwroot}/{_imgFolder}/{subDirectory}";
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            otherName ??= string.Empty;
            var fileName = Path.GetFileNameWithoutExtension(file.FileName); // apple.jpeg ->> apple
            var fileExtension = Path.GetExtension(file.FileName);
            var dateTime = DateTime.Now;
            var uniqueFileName =
                $"{dateTime.FullDateTimeStringWithUnderscore()}_{otherName.RemoveInvalidChars()}_{fileExtension}";
            var path = Path.Combine(directory, uniqueFileName);

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new Result<FileDto>(ServiceResultCode.Ok,
                BaseLocalization.ImageUploadedSuccessfully, new FileDto
                {
                    FullName = $"{subDirectory}/{uniqueFileName}",
                    FileName = fileName,
                    Extension = fileExtension,
                    Path = path,
                    Size = file.Length
                });
        }

        public IResult<FileDto> DeleteImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return new Result<FileDto>(ServiceResultCode.Error, null, BaseLocalization.NoDataAvailableOnRequest);
            var path = Path.Combine($"{_wwwroot}/{_imgFolder}", fileName); // fileName: user/apple.jpeg
            if (!File.Exists(path))
                return new Result<FileDto>(ServiceResultCode.Error, null, BaseLocalization.NoDataAvailableOnRequest);

            var fileInfo = new FileInfo(path);
            var resultDto = new FileDto
            {
                FullName = fileName,
                Extension = fileInfo.Extension,
                Path = fileInfo.FullName,
                Size = fileInfo.Length
            };
            File.Delete(path);

            return new Result<FileDto>(ServiceResultCode.Ok, BaseLocalization.DeletedSuccessfully, resultDto);
        }

        #endregion
    }
}