using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s66 : List<s66_item>
    {
    }

    [XmlType("animal")]
    public class s66_item
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }

        [XmlElement]
        public string characteristics { get; set; }
        [XmlElement]
        public string fit { get; set; }
        [XmlElement]
        public string unfit { get; set; }
        [XmlElement]
        public string fitreason { get; set; }
    }
}
