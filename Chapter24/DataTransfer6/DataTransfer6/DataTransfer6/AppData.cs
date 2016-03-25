using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace DataTransfer6
{
    public class AppData
    {
        public AppData()
        {
            InfoCollection = new ObservableCollection<InformationViewModel>();
            CurrentInfoIndex = -1;
        }

        public ObservableCollection<InformationViewModel> InfoCollection { private set; get; }

        [XmlIgnore]
        public InformationViewModel CurrentInfo { set; get; }

        public int CurrentInfoIndex { set; get; }

        public string Serialize()
        {
            // If the CurrentInfo is valid, set the CurrentInfoIndex.
            if (CurrentInfo != null)
            {
                CurrentInfoIndex = InfoCollection.IndexOf(CurrentInfo);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(AppData));
            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, this);
                return stringWriter.GetStringBuilder().ToString();
            }
        }

        public static AppData Deserialize(string strAppData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppData));
            using (StringReader stringReader = new StringReader(strAppData))
            {
                AppData appData = (AppData)serializer.Deserialize(stringReader);

                // If the CurrentInfoIndex is valid, set the CurrentInfo.
                if (appData.CurrentInfoIndex != -1)
                {
                    appData.CurrentInfo = appData.InfoCollection[appData.CurrentInfoIndex];
                }
                return appData;
            }
        }
    }
}
