using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s10 : List<s10_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s10_xingdi
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }


        [XmlElement("youdian")]
        public string youdian { get; set; }


        [XmlElement("quedian")]
        public string quedian { get; set; }


        [XmlElement("fenxi")]
        public string fenxi { get; set; }
    }
}
