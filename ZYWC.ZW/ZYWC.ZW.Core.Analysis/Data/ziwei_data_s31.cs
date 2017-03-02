using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s31 : List<s31_dashizhenyan>
    {
    }


    [XmlType("dashizhenyan")]
    public class s31_dashizhenyan
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlElement("dizhi")]
        public List<s31_dizhi> dizhis { get; set; }
    }


    [XmlType("dizhi")]
    public class s31_dizhi 
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlElement("content")]
        public List<s31_content> contents { get; set; }
    }

    
    [XmlType("contents")]
    public class s31_content
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlText]
        public string text { get; set; }
    }
}
