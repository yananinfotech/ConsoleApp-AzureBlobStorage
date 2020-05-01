using System;
using System.IO;

namespace AzureStorageService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string fileLoc = (@"D:\test.txt");
            FileStream fs = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);

            UploadFile uploadFile = new UploadFile();
            var result = uploadFile.UploadFileWithFileStream(fs);


            Console.WriteLine(result.ToString());
            Console.ReadKey();

        }
    }
}
