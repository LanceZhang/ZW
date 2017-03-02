using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s11 : List<s11_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s11_xingdi
    {
        [XmlAttribute]
        public int dizhi { get; set; }

        [XmlAttribute]
        public string name { get; set; }


        [XmlArray("gong")]
        [XmlArrayItem("item")]
        public string[] items { get; set; }
    }
}
