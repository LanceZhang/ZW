using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s21
    {

        [XmlArray("gongweizhuxing")]
        [XmlArrayItem("zhuxing")]
        public List<s21_zhuxing> gongweizhuxing { get; set; }
    }


    [XmlType("zhuxing")]
    public class s21_zhuxing
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string character { get; set; }

        [XmlElement("item")]
        public List<s21_item> items { get; set; }
    }



    [XmlType(TypeName = "item")]
    public class s21_item
    {
        [XmlAttribute]
        public string name { get; set; }

        [XmlText]
        public string text { get; set; }
    }

}
