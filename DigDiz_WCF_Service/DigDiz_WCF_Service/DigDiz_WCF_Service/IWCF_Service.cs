using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DigDiz_WCF_Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IWCF_Service" в коде и файле конфигурации.
    [ServiceContract]
    public interface IWCF_Service
    {
        [OperationContract]
        string RotateAllPhotoInFolder(string path);
    }
}
