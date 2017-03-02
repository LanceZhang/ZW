using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s12 : List<s12_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s12_xingdi
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }


        [XmlElement("jiexinan")]
        public string jiexinan { get; set; }


        [XmlElement("jiexinu")]
        public string jiexinu { get; set; }


        [XmlElement("miaowang")]
        public string miaowang { get; set; }


        [XmlElement("di")]
        public string di { get; set; }


        [XmlElement("pingxian")]
        public string pingxian { get; set; }
    }
}
