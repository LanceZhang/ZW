using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s6 : List<s6_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s6_xingdi
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public int tiangan { get; set; }


        [XmlArray("gong")]
        [XmlArrayItem("item")]
        public string[] items { get; set; }
    }
}
