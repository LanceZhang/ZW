using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s42 : List<s42_kaiyun>
    {
    }


    [XmlType("kaiyun")]
    public class s42_kaiyun 
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string title { get; set; }

        [XmlText]
        public string text { get; set; }
    }
}
