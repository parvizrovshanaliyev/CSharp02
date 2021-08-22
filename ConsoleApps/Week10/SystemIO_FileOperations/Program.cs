using System;
using System.IO;

namespace SystemIO_FileOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SystemIO.FileOperations

            /*
             * File uzerindeki emeliyyatlar Directory class-i ile oxsardir sadece qovluq uzerinde yox file uzerinde
             * yazma oxuma silme kimi emeliyyatlar yerine yetirilir
             */

            #endregion


            #region examples

            #region create file
            /*
             * xeta : System.IO.DirectoryNotFoundException: 'Could not find a part of the path 'C:\Test\createdFile.txt'.'
               daxil edilen adresde Test qovluqu olmadigina gore bele bir xeta verir...
             */
            //CreateFile(@"c:\test1\createdTestText.txt");

            #endregion

            #region exist

            //bool control = Exists(@"c:\test1\createdTestText.txt");
            //if(control) Console.WriteLine("Daxil edilen file movcuddur");
            //else CreateFile(@"c:\test1\createdTestText.txt");

            #endregion

            #region delete

            //bool control2= Exists(@"c:\test1\createdTestText.txt");
            //if(control2) Delete(@"c:\test1\createdTestText.txt");
            //else Console.WriteLine("movcud deyil ");
            #endregion

            #region move

            //Move(@"c:\test1\createdTestText.txt", @"c:\test2\createdTestText.txt");

            #endregion
            #region append

            //Append(@"c:\test1\createdTestText.txt", "Append All Text");

            #endregion
            #region read

            string data = Read(@"c:\test1\createdTestText.txt");
            Console.WriteLine(data);
            #endregion

            #endregion


        }

        #region File.Create
        /*
         * bu method vasitesile daxil edilen adressde her hansi bir fayl yaradilir.
         * geriye FileStream qaytarir.
         *
         * asagida istifade edilen Close() method-u yaranan file yarandiqdan sonra bize FileStream olaraq
         * geri donerken arxa terefde aciq qalir bu problem yaranmasin deye istifade edilmelidir.
         *
         * xeta : Could not find a part of the path 'c:\test1\createdTestText.txt'.'
         */
        static void CreateFile(string path)
        {
          FileStream fileStream =  File.Create(path);
          fileStream.Close();
        }
        
        #endregion

        #region File.Exist
        /*
        * qeyd edilen adresde fayl olub olmamasini yoxlayir.
        */
        static bool Exists(string path)
        {
            return File.Exists(path);
        }
       
        #endregion

        #region File.Delete
        /*
        * qeyd edilen adresde faylin silinmesi
        */
        static void Delete(string path)
        {
            File.Delete(path);
        }
      
        #endregion

        #region File.Move
        /*
         * daxil edilen adrese file dasinmasi...
         */
        static void Move(string source, string destination)
        {
            File.Move(source,destination);
        }
       
        #endregion

        #region File.Copy
        /*
         * daxil edilen adrese file dasinmasi...
         */

       
        #endregion

        #region File.AppendAllText
        /*
         * yaradilan her hansisa file data daxil edilmesi
         */
        static void Append(string path, string data)
        {
            File.AppendAllText(path,data);
        }
       
        #endregion

        #region File.ReadAllText
        /*
         * yaradilan her hansisa filedan data oxunmasi 
         */
        static string Read(string path)
        {
            return File.ReadAllText(path);
        }
       
        #endregion
    }
}
