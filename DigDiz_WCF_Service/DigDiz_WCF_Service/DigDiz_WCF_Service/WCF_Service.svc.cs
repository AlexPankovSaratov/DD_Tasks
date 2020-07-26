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
        public string RotateAllPhotoInFolder(string path)
        {
            if (path == null) return "Missing path";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return "The path to the folder is not correct";
            }
            try
            {
                var files = directoryInfo.GetFiles().Where(x =>
            x.Extension.ToUpper() == ".JPG"
            || x.Extension.ToUpper() == ".PNG"
            || x.Extension.ToUpper() == ".BMP");
                Parallel.ForEach(files, RotatePhoto);
                return "All photos are processed";
            }
            catch (Exception ex)
            {
                return "An error occurred during processing: " + ex.Message;
            }

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
                img.RotateFlip(RotateFlipType.Rotate90FlipX);
                img.Save(File.FullName);
            }
        }
    }
}
