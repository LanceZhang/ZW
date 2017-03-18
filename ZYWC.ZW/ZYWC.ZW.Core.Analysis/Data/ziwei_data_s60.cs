using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s60 : List<s60_starData>
    {
    }

    [XmlType("starData")]
    public class s60_starData
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string wuxing { get; set; }

        [XmlAttribute]
        public string stone { get; set; }

        [XmlText]
        public string text { get; set; }
    }
}
