using System;
using DigDiz_WCF_Service;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WCF_Service WCF_Service = new WCF_Service();
            Console.WriteLine("Enter the full path to the folder: ");
            string FolderPath = Console.ReadLine();
            string result = WCF_Service.RotateAllPhotoInFolder(FolderPath,90);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
