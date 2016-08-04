using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace MapDemos
{
    public class Locations
    {
        public Locations()
        {
            Sites = new List<Site>();
        }

        public string Title { set; get; }

        public List<Site> Sites { set; get; }

        public static Locations Load(string resource)
        {
            Assembly assembly = typeof(Locations).GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Locations));
                    Locations locations = (Locations)xmlSerializer.Deserialize(stream);

                    return locations;
                }
            }
        }
    }
}
