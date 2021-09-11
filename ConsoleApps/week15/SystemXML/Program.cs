using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SystemXML
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Xml vasitesi ile sistem ve platformalar arasinda data transferi standart hala getirilmisdir,
            xml isaretleme / markup language dir.

            harda istifade edile biler ?
             2 ferqli application arasinda data transferinde istifade ede bilersiz . Meselen e-gov xidmetleri deye bir
            app dusunun  vetendasin vesiqesinde olan Fin-e gore onun haqqinda size output / result verir . Bu app hansi dilde
            develop edilmesinden asili olmayaraq standart olaraq outputu size xml olaraq verirse , siz de oz novbenizde sirketinizin
            ve ya ferdi appiniz-de yenede hansi dilde develop edilmesinden asili olmayaraq xml formasinda data-ni qebul edib 
            ferqli formatda istifade ede bilersiniz

                e-gov                               my app
            |-------------|  request             |------------|
            |             |  input Fin: 123GFHA  |            |
            |             |<-------------------- |            |
            |             |--------------------->|            |
            |             |  response            |------------|
             -------------   output

            input : 123GFHA
            output : <person>
                      <name>Agil</name>
                      <surname>Veliyev</surname>
                      <bithday>1990.12.12</bithday>
                      </person>


            elave olaraq toplu sekilde data transferi esnasinda istifade edile biler, fikilesin ki oz app-nizde butun olke, seher 
            adlari gosterilmelidir her hansisa hazir xml file-dan bunlari cox asanliqla bir defelik sisteme daxil edib db-da saxlaya bilersiz.
            bu sizi manual qaydada dbya insert emeliyyatlarindan xilas edir. 
             
             */
        }

        private static string AppRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher
                .Match(exePath ?? string.Empty ).Value;
            return appRoot;
        }
    }
}
