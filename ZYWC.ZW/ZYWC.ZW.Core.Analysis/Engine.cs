using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.BusinessLogic;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis
{
    public class Engine
    {
        DAL dal = null;
        FuMuAnalyzer fumu = null;
        FuQiAnalyzer fuqi = null;
        CaiBoAnalyzer caibo = null;
        FudeAnalyzer fude = null;
        JiaoYouAnalyzer jiaoyou = null;
        JiEAnalyzer jie = null;
        MingAnalyzer ming = null;
        QianYiAnalyzer qianyi = null;
        ShiYeAnalyzer shiye = null;
        TianZhaiAnalyzer tianzhai = null;
        XiongDiAnalyzer xiongdi = null;
        ZiNvAnalyzer zinv = null;
        GeJuAnalyzer geju = null;

        public Engine(string path)
        {
            dal = new DAL(path);

            fumu = new FuMuAnalyzer(dal);
            fuqi = new FuQiAnalyzer(dal);
            caibo = new CaiBoAnalyzer(dal);
            jiaoyou = new JiaoYouAnalyzer(dal);
            jie = new JiEAnalyzer(dal);
            ming = new MingAnalyzer(dal);
            qianyi = new QianYiAnalyzer(dal);
            shiye = new ShiYeAnalyzer(dal);
            tianzhai = new TianZhaiAnalyzer(dal);
            xiongdi = new XiongDiAnalyzer(dal);
            zinv = new ZiNvAnalyzer(dal);
            geju = new GeJuAnalyzer(dal);
            //fude = new FudeAnalyzer(dal);
        }


        public FuMuAnalyzer FuMuAnalyzer
        {
            get
            {
                return fumu;
            }
        }


        public FuQiAnalyzer FuQiAnalyzer
        {
            get
            {
                return fuqi;
            }
        }

        public CaiBoAnalyzer CaiBoAnalyzer
        {
            get
            {
                return caibo;
            }
        }

        public FudeAnalyzer FudeAnalyzer
        {
            get
            {
                return fude;
            }
        }

        public JiaoYouAnalyzer JiaoYouAnalyzer
        {
            get
            {
                return jiaoyou;
            }
        }

        public JiEAnalyzer JiEAnalyzer
        {
            get
            {
                return jie;
            }
        }

        public MingAnalyzer MingAnalyzer
        {
            get
            {
                return ming;
            }
        }

        public QianYiAnalyzer QianYiAnalyzer
        {
            get
            {
                return qianyi;
            }
        }

        public ShiYeAnalyzer ShiYeAnalyzer
        {
            get
            {
                return shiye;
            }
        }

        public TianZhaiAnalyzer TianZhaiAnalyzer
        {
            get
            {
                return tianzhai;
            }
        }

        public XiongDiAnalyzer XiongDiAnalyzer
        {
            get
            {
                return xiongdi;
            }
        }

        public ZiNvAnalyzer ZiNvAnalyzer
        {
            get
            {
                return zinv;
            }
        }

        public GeJuAnalyzer GeJuAnalyzer
        {
            get
            {
                return geju;
            }
        }

        /// <summary>     
        /// 从某一XML文件反序列化到某一类型   
        /// </summary>    
        /// <param name="filePath">待反序列化的XML文件名称</param>  
        /// <param name="type">反序列化出的</param>  
        /// <returns></returns>    
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
}
