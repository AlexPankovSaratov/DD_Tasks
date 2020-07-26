using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DigDiz_WCF_Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WCF_Service" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WCF_Service.svc или WCF_Service.svc.cs в обозревателе решений и начните отладку.
    public class WCF_Service : IWCF_Service
    {
        private static int angle;
        public string RotateAllPhotoInFolder(string path, int Angle)
        {
            angle = Angle;
            if (path == null) return "Missing path";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return "The path to the folder is not correct";
            }
            if(Angle != 90 && Angle != 180 && Angle != 270)
            {
                return "Rotation possible only 90,180,270 degrees";
            }
            Stopwatch stopWatch = new Stopwatch();
            
            try
            {
                stopWatch.Start();
                var files = directoryInfo.GetFiles().Where(x =>
                x.Extension.ToUpper() == ".JPG"
                || x.Extension.ToUpper() == ".PNG"
                || x.Extension.ToUpper() == ".BMP");
                Parallel.ForEach(files, RotatePhoto);
                stopWatch.Stop();
            }
            catch (Exception ex)
            {
                return "An error occurred during processing: " + ex.Message;
            }
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            return "All photos are processed. Lead time: " + elapsedTime;
        }

        private static void RotatePhoto(FileInfo File)
        {
            Image img = null;
            using (FileStream stream = new FileStream(File.FullName, FileMode.Open, FileAccess.Read))
            {
                img = Image.FromStream(stream);
            }
            if (img != null)
            {
                switch (angle)
                {
                    case 90 :
                        img.RotateFlip(RotateFlipType.Rotate90FlipX);
                        img.Save(File.FullName);
                        break;
                    case 180:
                        img.RotateFlip(RotateFlipType.Rotate180FlipX);
                        img.Save(File.FullName);
                        break;
                    case 270:
                        img.RotateFlip(RotateFlipType.Rotate270FlipX);
                        img.Save(File.FullName);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
