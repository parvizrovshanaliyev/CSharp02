using System;
using System.IO;


namespace SystemIO_DirectoryOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            #region using System.IO;
            /*
             * System.IO kitabxanasindan istifade ederek file uzerinde yazma oxuma emeliyyatlarini ve ya directory ile
             * bagli emeliyyatlari yerine yetire bilerik. Burada olan IO input output qisaltmasidir.
             *
             *
             * System.IO namespace https://docs.microsoft.com/en-us/dotnet/api/system.io?view=net-5.0
             * https://tr.wikibooks.org/wiki/C_Sharp_Programlama_Dili/Temel_I/O_i%C5%9Flemleri
             */


            #endregion


            #region example

            #region Directory.CreateDirectory

            CreateNewFolder(@"c:\test1");

            #endregion

            #region exist

            //bool control1 = Exists(@"c:\test1");

            //if(!control1) CreateNewFolder(@"c:\test1");
            //else Console.WriteLine("daxil edilen adresde folder movcuddur");

            #endregion

            #region delete

            //DeleteDir(@"c:\test1");

            #endregion

            #region Move

            Move(@"c:\test1", @"c:\test2\test1");

            #endregion

            #endregion


        }
        #region Directory.CreateDirectory
        /*
         *  Directory.CreateDirectory vasitesile daxil edilen adresde yeni folder yarada bilerik.
         *  geriye DirectoryInfo tipinde data qaytarir.
         */
        static void CreateNewFolder(string path)
        {
            DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
        }
        #endregion

        #region Directory.Exists

        /*
         * Directory.Exists methodu bildirilen adressin movcud olub olmadigi yoxlayir ve geriye bool qaytarir.
         */
        static bool Exists(string path)
        {
            return Directory.Exists(path);
        }
        #endregion

        #region Directory.Delete

        /*
         * Directory.Delete methodu ilk daxil edilen parametrde qeyd edilen adresi silir, ikinci daxil edilen parametrde ise
         * daxil edilen addresdeki qovluq icerisinde data varsa onu da silir.
         *
         *
         * Xeta : The directory is not empty. : 'c:\test1
         */
        static void DeleteDir(string path)
        {
            bool control = Exists(path);

            if (control)
            {
                Directory.Delete(path,true);
                Console.WriteLine("qovluq silindi");
            }
            else
                Console.WriteLine("silinecek qovluq movcud deyil");
        }
        #endregion

        #region Directory.Move

        /*
         * Directory.Move bir addresden digerine dasima.
         */
        static void Move(string sourceDirPath, string destinationDirPath)
        {
            Directory.Move(sourceDirPath,destinationDirPath);
        }
        #endregion
    }
}
