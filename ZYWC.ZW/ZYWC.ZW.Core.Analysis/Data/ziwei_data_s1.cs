using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s1 : List<s1_xingdi>
    {
        //[XmlArray("root")]
        //[XmlArrayItem("xingdi")]
        //public List<xingdi> xingdis { get; set; }
    }


    [XmlType("xingdi")]
    public class s1_xingdi
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string level { get; set; }

        [XmlAttribute]
        public string character { get; set; }
    }
}
