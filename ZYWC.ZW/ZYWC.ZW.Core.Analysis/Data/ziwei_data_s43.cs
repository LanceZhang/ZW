using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s43 : List<s43_liunianData>
    {
    }


    [XmlType("liunianData")]
    public class s43_liunianData 
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlElement("starData")]
        public List<s43_starData> starDatas { get; set; }
    }


    [XmlType("starData")]
    public class s43_starData
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string title { get; set; }

        [XmlText]
        public string text { get; set; }
    }






}
