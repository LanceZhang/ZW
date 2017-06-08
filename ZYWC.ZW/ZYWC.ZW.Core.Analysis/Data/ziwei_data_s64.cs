using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s64 : List<s64_item>
    {
    }

    [XmlType("weekday")]
    public class s64_item
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement]
        public string explanation { get; set; }
        [XmlElement]
        public int matchscore { get; set; }
    }
}
