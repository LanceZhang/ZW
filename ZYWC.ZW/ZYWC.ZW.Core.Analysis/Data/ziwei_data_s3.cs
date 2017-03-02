using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s3 : List<s3_xingdi>
    {

    }


    [XmlType("xingdi")]
    public class s3_xingdi
    {
        [XmlAttribute]
        public int position { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlText]
        public string text { get; set; }
    }
}
