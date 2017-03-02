using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s44 : List<s44_lucky>
    {
    }


    [XmlType("lucky")]
    public class s44_lucky
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string wuxing { get; set; }

        [XmlAttribute]
        public string color { get; set; }

        [XmlAttribute]
        public int miaowangnum { get; set; }

        [XmlAttribute]
        public int levelnum { get; set; }

        [XmlAttribute]
        public string fruit { get; set; }

        [XmlAttribute]
        public string direction { get; set; }

        [XmlAttribute]
        public string dressup { get; set; }
    }
}
