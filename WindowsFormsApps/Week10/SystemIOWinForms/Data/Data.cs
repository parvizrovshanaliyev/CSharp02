using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOWinForms
{
    public class Data
    {
        public List<Employer> GetAll(int count)
        {
            List<Employer> employers = new List<Employer>();

            int id = 1;

            for (int i = 1; i <= count; i++)
            {
                var employer = new Employer
                {
                    Id = id,
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Company = FakeData.NetworkData.GetDomain(),
                    Country = FakeData.PlaceData.GetCountry()
                };

                employer.Email = $"{employer.Name}.{employer.Surname}@gmail.com";
                employers.Add(employer);
                id++;
            }

            return employers;
        }

        public void SaveData(string path, List<Employer> data)
        {
            DirectoryInfo directoryInfo = null;

            // kamran : country eriteriya
            // ferid : country eriteriya

            foreach (var item in data)
            {
                string directory = $"{path}\\{item.Country}"; // eriteriya


                if (Directory.Exists(directory)) // false
                {
                    directoryInfo = new DirectoryInfo(directory);
                }
                else
                {
                    directoryInfo=Directory.CreateDirectory(directory);
                }

                FileStream fileStream = File.Create($"{directoryInfo.FullName}\\{item.Name}.{item.Surname}.txt");
                byte[] employerInfoByteArray = new UTF8Encoding(true).GetBytes(item.GetInfo());
                fileStream.Write(employerInfoByteArray,0,employerInfoByteArray.Length);
                fileStream.Close();
            }
        }
    }
}
