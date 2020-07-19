using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace DigDiz_Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Rotator rotator = new Rotator();
            rotator.RotateAllPhoto();
        }
    }
    public class Rotator
    {
        public void RotateAllPhoto()
        {
            Console.WriteLine("Enter the full path to the folder: ");
            string FolderPath = Console.ReadLine();
            DirectoryInfo directoryInfo = new DirectoryInfo(FolderPath);
            if (!directoryInfo.Exists)
            {
                Console.WriteLine("The path to the folder is not correct");
                return;
            }
            foreach (FileInfo item in directoryInfo.GetFiles())
            {
                Console.WriteLine("File: " + item.Name + " taken to work.");
                Console.WriteLine(RotatePhoto(item));
            }
            Console.ReadKey();
        }
        string RotatePhoto(FileInfo File)
        {
            string Expansion = File.Name.Substring(File.Name.LastIndexOf('.') + 1, 3);
            int IdThread = System.Threading.Thread.CurrentThread.ManagedThreadId;
            if (Expansion == "jpg" | Expansion == "png" | Expansion == "bmp")
            {
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
                        return "Photo processed. Time of processing: " + elapsedTime + ". Id of the executable thread: " + IdThread;
                    }
                    else return "Photo not found";
                }
                catch (Exception)
                {
                    return "Mistake. Photo is not processed";
                }
            }
            else return "File is not a picture";
        }
    }

}
