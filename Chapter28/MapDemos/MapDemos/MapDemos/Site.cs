using System;
using System.Xml.Serialization;

namespace MapDemos
{
    public class Site
    {
        [XmlAttribute]
        public string Name { set; get; }

        [XmlAttribute]
        public string LongName { set; get; }

        [XmlAttribute]
        public double Latitude { set; get; }

        [XmlAttribute]
        public double Longitude { set; get; }

        [XmlAttribute]
        public string Address { set; get; }

        [XmlAttribute]
        public string Website { set; get; }

        [XmlIgnore]
        public double DistanceToCenter { set; get; }

        [XmlIgnore]
        public double DistanceToUser { set; get; }
    }
}
