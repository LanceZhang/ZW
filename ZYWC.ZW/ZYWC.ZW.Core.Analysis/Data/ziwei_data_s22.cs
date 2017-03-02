using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s22
    {

        [XmlArray("zhuxing")]
        [XmlArrayItem("xingyao")]
        public List<s22_xingyao> zhuxing { get; set; }
    }


    [XmlType("zhuxing")]
    public class s22_xingyao 
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string character { get; set; }

        [XmlAttribute]
        public int index { get; set; }


        [XmlElement("item")]
        public List<s22_item> items { get; set; }


    }



    [XmlType(TypeName = "item")]
    public class s22_item
    {
        [XmlAttribute]
        public string name { get; set; }

        [XmlText]
        public string text { get; set; }
    }

}
