using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s26 : List<s26_minggonggeju>
    {
    }


    [XmlType("minggonggeju")]
    public class s26_minggonggeju
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string gejuJixiong { get; set; }

        [XmlAttribute]
        public string gejuname { get; set; }

        [XmlText]
        public string text { get; set; }
    }
}
