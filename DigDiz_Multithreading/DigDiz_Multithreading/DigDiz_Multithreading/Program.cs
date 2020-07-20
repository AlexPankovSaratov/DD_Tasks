using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace DigDiz_Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            RotateAllPhoto();
        }
        public static void RotateAllPhoto()
        {
            Console.WriteLine("Enter the full path to the folder: ");
            string FolderPath = Console.ReadLine();
            DirectoryInfo directoryInfo = new DirectoryInfo(FolderPath);
            if (!directoryInfo.Exists)
            {
                Console.WriteLine("The path to the folder is not correct");
                return;
            }
            Parallel.ForEach(directoryInfo.GetFiles().Where(x=> 
            x.Extension.ToUpper() == ".JPG" 
            || x.Extension.ToUpper() == ".PNG"
            || x.Extension.ToUpper() == ".BMP"), RotatePhoto);
            Console.ReadKey();
        }

        public static void RotatePhoto(FileInfo File)
        {
            Console.WriteLine("File: " + File.Name + " taken to work.");
            int IdThread = System.Threading.Thread.CurrentThread.ManagedThreadId;
            try
            {
                Image img = null;
                using (FileStream stream = new FileStream(File.FullName, FileMode.Open, FileAccess.Read))
                {
                    img = Image.FromStream(stream);
                }
                if (img != null)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    img.RotateFlip(RotateFlipType.Rotate90FlipX);
                    img.Save(File.FullName);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine("Photo " + File.Name + " processed. Time: " + elapsedTime + ". Id thread: " + IdThread);
                }
                else Console.WriteLine("Photo not found");
            }
            catch (Exception)
            {
                Console.WriteLine("Mistake. Photo is not processed");
            }
        }
    }
}

