using System;
using System.IO;

namespace ExceptionHandling.TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            #region exception handling

            /*
             * Umumiyyetle developer proyekt uzerindeki xetalari idare etmeli ve istifadeciye
             * basa duseceyi sekilde xeta mesajlari gostermelidir , yaranan sistem xetalari
             * developer terefinden basa dushulse bele istifadeci terefinden basa dusulmeyecek bunun
             * ucun exceptionlarin duzgun idare edilmesi sertdir.
             *
             * Umumi xeta/exception dedikde bunlarin iki yere bolunduyunu bilmeliyik
             *
             *   Compilation errors
             *   Runtime errors
             *
             *
             * Compilation errors : bu xeta novu sintaks ve duzgun yazilmama ve sair ile elaqeli kodun yazildigi vaxt
             * xeberdarliq olaraq developerin qarshisina cixir.
             *
             * Runtime errors : bu xetalar ise application ise dusduyu anda yaranir ki, bunlar icaze verilmeyen bir file oxumaq,
             * connection string olan her hansisa sehve gore dbya qosulmaq istemek , bir sira mentiq sehvleri ve duzgun datanin daxil edilmemesi ve sair
             * ola biler , asagdaki kimi exceptionlarla qarsilasa bilersiz.
             *
             *        IndexOutOfRangeException
             *        FormatException
             *        NullReferenceException
             *        DivideByZeroException
             *        FileNotFoundException
             *        SQLException,
             *        OverFlowException, etc
             *
             *
             *
             */
            #endregion

            #region examples

            #region 1. enter number




            #endregion


            #endregion
        }

        #region tryCatch1

        static void ExceptionHandlingTrCatch()
        {
            try
            {
                Console.Write("reqem daxil edin :\t");
                int number = int.Parse(Console.ReadLine());

                if (number == 10)
                {
                    throw new CustomExceptions();
                }
            }
            catch (CustomExceptions customExceptions)
            {
                Console.WriteLine("custom exception : catch block");
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("sadece reqem daxil ede bilersiniz");
            }
            catch (Exception e)
            {
                Console.WriteLine("xeta bas verdi");
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                /*
                 * her hansisa bir xeta olmasa bele finally bloku ise dusur.
                 * Numune olaraq deyekki dbya connection etmisiz connection-nin close oldugu yerden once bir xetaniz olarsa connection
                 * aciq qalacaq ancaq finally ile xeta olsa bele blok ise dusur ve connection baglanir, ve ya fileStreamle
                 * isleyerken close qederki yerde problem olarsa ramda hemin filestream aciq qalar.
                 */
                Console.WriteLine("Finally .....");

            }
        }


        #endregion

        #region tryCatch2
        // Assume that we want to read all text in a certain

        static void FileOperation()
        {
            try
            {
                string path = "";
                string path1 = "1212!$#@@";
                string path2 = "C:\\Argument";
                string path3 = "C:\\Argument\\test";
                string text = File.ReadAllText(path);
            }
            catch (FileNotFoundException fileNotFoundException)
            {

                Console.WriteLine("path1/ file not found:\n:" + fileNotFoundException.Message);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {

                Console.WriteLine("path3/ directoryNotFoundException :\n:" + directoryNotFoundException.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("path1/ is invalid:\n:" + argumentException.Message);
            }
            catch (IOException ioException)
            {
                Console.WriteLine("reading a file failure:\n:" + ioException.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine("path/ something is wrong:\n:" + e.Message);
            }
            finally
            {
                Console.WriteLine("leaving read text operation");
            }
        }

        #endregion
        static void EnterNumber()
        {
            Console.Write("reqem daxil edin :\t");
            int number = int.Parse(Console.ReadLine());
        }
    }

    internal class CustomExceptions : Exception
    {
    }
}
