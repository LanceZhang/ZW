using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s45 : List<s45_yiji>
    {
        //[XmlArray("root")]
        //[XmlArrayItem("xingdi")]
        //public List<xingdi> xingdis { get; set; }
    }


    [XmlType("yiji")]
    public class s45_yiji
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string value { get; set; }
    }
}
