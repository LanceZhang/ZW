using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s20
    {
        [XmlArray("jixiongzhishu")]
        [XmlArrayItem("xingyao")]
        public List<s20_xingyao> jixiongzhishu { get; set; }


        [XmlArray("xingxiang")]
        [XmlArrayItem("liangdu")]
        public List<s20_liangdu> xingxiang { get; set; }


        [XmlArray("zonghe")]
        [XmlArrayItem("xingyao")]
        public List<s20_xingyao> zonghe { get; set; }


        [XmlArray("lucky")]
        [XmlArrayItem("gongzhi")]
        public List<s20_gongzhi> lucky { get; set; }


        [XmlArray("jiyi")]
        [XmlArrayItem("gongwei")]
        public List<s20_gongwei> jiyi { get; set; }

    }









    [XmlType("xingyao")]
    public class s20_xingyao 
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlElement("item")]
        public List<s20_item> items { get; set; }
    }



    [XmlType(TypeName = "item")]
    public class s20_item
    {
        [XmlAttribute]
        public string name { get; set; }

        [XmlText]
        public string text { get; set; }
    }


    [XmlType("liangdu")]
    public class s20_liangdu 
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string character { get; set; }
    }


    [XmlType("gongwei")]
    public class s20_gongwei 
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string character { get; set; }
    }


    [XmlType("gongzhi")]
    public class s20_gongzhi
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlElement("item")]
        public List<s20_item> items { get; set; }
    }

}
