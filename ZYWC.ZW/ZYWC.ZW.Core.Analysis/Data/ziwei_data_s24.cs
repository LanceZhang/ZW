using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s24 : List<s24_dashizhenyan>
    {
    }


    [XmlType("dashizhenyan")]
    public class s24_dashizhenyan
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlElement("content")]
        public List<s24_content> items { get; set; }
    }


    [XmlType(TypeName = "content")]
    public class s24_content
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlText]
        public string text { get; set; }
    }



}
