using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s15 : List<s15_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s15_xingdi
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlElement("caibo")]
        public string caibo { get; set; }


        [XmlElement("tianzai")]
        public string tianzai { get; set; }


        [XmlElement("mingong")]
        public string mingong { get; set; }

        [XmlElement("caibofengxian")]
        public string caibofengxian { get; set; }
    }
}
