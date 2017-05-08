using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYWC.ZW.Core.Analysis.Data
{
    public class DAL
    {
        public ziwei_data_s1 s1 { get; private set; }
        public ziwei_data_s2 s2 { get; private set; }
        public ziwei_data_s3 s3 { get; private set; }
        public ziwei_data_s4 s4 { get; private set; }
        public ziwei_data_s5 s5 { get; private set; }
        public ziwei_data_s6 s6 { get; private set; }
        public ziwei_data_s7 s7 { get; private set; }
        public ziwei_data_s8 s8 { get; private set; }
        public ziwei_data_s9 s9 { get; private set; }
        public ziwei_data_s10 s10 { get; private set; }
        public ziwei_data_s11 s11 { get; private set; }
        public ziwei_data_s12 s12 { get; private set; }
        public ziwei_data_s13 s13 { get; private set; }
        public ziwei_data_s14 s14 { get; private set; }
        public ziwei_data_s15 s15 { get; private set; }
        public ziwei_data_s18 s18 { get; private set; }
        public ziwei_data_s20 s20 { get; private set; }
        public ziwei_data_s21 s21 { get; private set; }
        public ziwei_data_s22 s22 { get; private set; }
        public ziwei_data_s23 s23 { get; private set; }
        public ziwei_data_s24 s24 { get; private set; }
        public ziwei_data_s25 s25 { get; private set; }
        public ziwei_data_s26 s26 { get; private set; }
        public ziwei_data_s31 s31 { get; private set; }
        public ziwei_data_s31 s32 { get; private set; }
        public ziwei_data_s31 s33 { get; private set; }
        public ziwei_data_s31 s34 { get; private set; }
        public ziwei_data_s31 s35 { get; private set; }
        public ziwei_data_s31 s36 { get; private set; }
        public ziwei_data_s31 s37 { get; private set; }
        public ziwei_data_s31 s38 { get; private set; }
        public ziwei_data_s31 s39 { get; private set; }
        public ziwei_data_s31 s40 { get; private set; }
        public ziwei_data_s31 s41 { get; private set; }
        public ziwei_data_s42 s42 { get; private set; }
        public ziwei_data_s43 s43 { get; private set; }
        public ziwei_data_s44 s44 { get; private set; }
        public ziwei_data_s45 s45 { get; private set; }
        public ziwei_data_s60 s60 { get; private set; }
        public ziwei_data_s61 s61 { get; private set; }
        public ziwei_data_s63 s63 { get; private set; }
        public Dictionary<string, s1_xingdi> Dic_ZhuXing { get; private set; }
        public Dictionary<string, s1_xingdi> Dic_JiXing { get; private set; }
        public Dictionary<string, s1_xingdi> Dic_XiongXing { get; private set; }




        public DAL(string path)
        {
            s1 = DeserializeFromXml<ziwei_data_s1>(path + "ziwei_data_s1.xml");

            s2 = DeserializeFromXml<ziwei_data_s2>(path + "ziwei_data_s2.xml");

            s3 = DeserializeFromXml<ziwei_data_s3>(path + "ziwei_data_s3.xml");

            s4 = DeserializeFromXml<ziwei_data_s4>(path + "ziwei_data_s4.xml");

            s5 = DeserializeFromXml<ziwei_data_s5>(path + "ziwei_data_s5.xml");

            s6 = DeserializeFromXml<ziwei_data_s6>(path + "ziwei_data_s6.xml");

            s7 = DeserializeFromXml<ziwei_data_s7>(path + "ziwei_data_s7.xml");

            s8 = DeserializeFromXml<ziwei_data_s8>(path + "ziwei_data_s8.xml");

            s9 = DeserializeFromXml<ziwei_data_s9>(path + "ziwei_data_s9.xml");

            s10 = DeserializeFromXml<ziwei_data_s10>(path + "ziwei_data_s10.xml");

            s11 = DeserializeFromXml<ziwei_data_s11>(path + "ziwei_data_s11.xml");

            s12 = DeserializeFromXml<ziwei_data_s12>(path + "ziwei_data_s12.xml");

            s13 = DeserializeFromXml<ziwei_data_s13>(path + "ziwei_data_s13.xml");

            s14 = DeserializeFromXml<ziwei_data_s14>(path + "ziwei_data_s14.xml");

            s15 = DeserializeFromXml<ziwei_data_s15>(path + "ziwei_data_s15.xml");

            s18 = DeserializeFromXml<ziwei_data_s18>(path + "ziwei_data_s18.xml");

            s20 = DeserializeFromXml<ziwei_data_s20>(path + "ziwei_data_s20.xml");

            s21 = DeserializeFromXml<ziwei_data_s21>(path + "ziwei_data_s21.xml");

            s22 = DeserializeFromXml<ziwei_data_s22>(path + "ziwei_data_s22.xml");

            s23 = DeserializeFromXml<ziwei_data_s23>(path + "ziwei_data_s23.xml");

            s24 = DeserializeFromXml<ziwei_data_s24>(path + "ziwei_data_s24.xml");

            s25 = DeserializeFromXml<ziwei_data_s25>(path + "ziwei_data_s25.xml");

            s26 = DeserializeFromXml<ziwei_data_s26>(path + "ziwei_data_s26.xml");

            s31 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s31.xml");

            s32 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s32.xml");

            s33 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s33.xml");

            s34 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s34.xml");

            s35 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s35.xml");

            s36 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s36.xml");

            s37 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s37.xml");

            s38 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s38.xml");

            s39 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s39.xml");

            s40 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s40.xml");

            s41 = DeserializeFromXml<ziwei_data_s31>(path + "ziwei_data_s41.xml");

            s42 = DeserializeFromXml<ziwei_data_s42>(path + "ziwei_data_s42.xml");

            s43 = DeserializeFromXml<ziwei_data_s43>(path + "ziwei_data_s43.xml");

            s44 = DeserializeFromXml<ziwei_data_s44>(path + "ziwei_data_s44.xml");

            s45 = DeserializeFromXml<ziwei_data_s45>(path + "ziwei_data_s45.xml");

            s60 = DeserializeFromXml<ziwei_data_s60>(path + "ziwei_data_s60.xml");

            s61 = DeserializeFromXml<ziwei_data_s61>(path + "ziwei_data_s61.xml");

            s63 = DeserializeFromXml<ziwei_data_s63>(path + "ziwei_data_s63.xml");

            Dic_ZhuXing = s1.Where(s => s.character == "正翟").ToDictionary(x => x.name);


            Dic_JiXing = s1.Where(s => s.character == "吉星" && s.level == "甲").ToDictionary(x => x.name);


            Dic_XiongXing = s1.Where(s => s.character == "煞星").ToDictionary(x => x.name);

        }



        public static T DeserializeFromXml<T>(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                    throw new ArgumentNullException(filePath + " not Exists");
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    T ret = (T)xs.Deserialize(reader);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

    }

    public enum GongIndex
    {
        命宫 = 0,
        兄弟宫 = 1,
        夫妻宫 = 2,
        子女宫 = 3,
        财帛宫 = 4, //???
        疾厄宫 = 5,
        迁移宫 = 6,
        仆役宫 = 7,
        事业宫 = 8,
        田宅宫 = 9,
        福德宫 = 10, //???
        父母宫 = 11
    }
}
