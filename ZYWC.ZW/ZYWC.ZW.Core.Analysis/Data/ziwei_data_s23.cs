using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZYWC.ZW.Core.Analysis.Data
{
    [XmlRoot("root")]
    public class ziwei_data_s23
    {

        [XmlArray("worm")]
        [XmlArrayItem("xingyao")]
        public List<s22_xingyao> worm { get; set; }
    }


}
