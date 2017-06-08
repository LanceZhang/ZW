using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s65:List<s65_item>
    {
    }

    [XmlType("constellation")]
    public class s65_item
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }

        [XmlElement]
        public int matchscore { get; set; }
        [XmlElement]
        public int risk { get; set; }
        [XmlElement]
        public int friendship { get; set; }
        [XmlElement]
        public int love { get; set; }
        [XmlElement]
        public int marriage { get; set; }
        [XmlElement]
        public int family { get; set; }
        [XmlElement]
        public string explanation { get; set; }
    }
}
