using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class LiuNianAnalyzer
    {
        private DAL dal;

        public LiuNianAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public IList<LiuNianInfo> GetLiuNianInfo(string[] stars, GongIndex index)
        {
            var list = new List<LiuNianInfo>();
            if (stars == null || stars.Length == 0)
                return list;

            int id = 0;
            switch (index)
            {
                case GongIndex.命宫: id = 0; break;
                case GongIndex.夫妻宫: id = 1; break;
                case GongIndex.事业宫: id = 2; break;
                case GongIndex.财帛宫: id = 3; break;
                case GongIndex.迁移宫: id = 4; break;
                case GongIndex.田宅宫: id = 5; break;
                case GongIndex.疾厄宫: id = 6; break;
                case GongIndex.仆役宫: id = 7; break;
                case GongIndex.父母宫: id = 8; break;
                case GongIndex.子女宫: id = 9; break;
                default: return list;
            }

            var container = dal.s43.Find(d => d.id == id);
            string xingid = null;
            if (stars.Length == 1)
            {
                xingid = dal.Dic_ZhuXing[stars[0]].id.ToString();
            }
            else if (stars.Length == 2)
            {
                xingid = string.Format("{0}#{1}", dal.Dic_ZhuXing[stars[0]].id, dal.Dic_ZhuXing[stars[1]].id);
            }
            else
            {
                return list;
            }

            var raw = container.starDatas.Where(d => d.id == xingid);
            foreach(var item in raw)
            {
                var info = new LiuNianInfo()
                {
                    id = item.id,
                    name = item.name,
                    title = item.title,
                    text = item.text
                };
                list.Add(info);
            }

            return list;
        }


        #region 流年财运

        /// <summary>
        /// 获取流年财运指数
        /// </summary>
        /// <param name="pan"></param>
        /// <returns></returns>
        public float GetLiuNianCaiboScore(PaiPan pan)
        {
            var caiboMing = pan.Gongs.First(g => g.Name == GongIndex.财帛宫.ToString());
            var caiboXian = pan.Gongs.First(g => g.XianName == GongIndex.财帛宫.ToString());
            var caiboLiu = pan.Gongs.First(g => g.LiuName == GongIndex.财帛宫.ToString());
            var scoreMing = CaiboScore(pan, caiboMing);
            var scoreXian = CaiboScore(pan, caiboXian);
            var scoreLiu = CaiboScore(pan, caiboLiu);
            return scoreMing * ming_weight + scoreXian * xian_weight + scoreLiu * liu_weight;
        }

        private BasicGong SanFangSiZheng(PaiPan pan, string name)
        {
            //三方四正
            var model = new BasicGong();
            model.SelfGong = pan.Gongs.First(g => g.Name == name);

            int dui = (model.SelfGong.Zhi + 6) % 12;
            if (dui == 0)
            {
                dui = 12;
            }
            else if (dui < 0)
            {
                dui += 12;
            }

            int hui1 = (model.SelfGong.Zhi + 4) % 12;
            if (hui1 == 0)
            {
                hui1 = 12;
            }
            else if (hui1 < 0)
            {
                hui1 += 12;
            }


            int hui2 = (model.SelfGong.Zhi - 4) % 12;
            if (hui2 == 0)
            {
                hui2 = 12;
            }
            else if (hui2 < 0)
            {
                hui2 += 12;
            }

            model.DuiZhaoGong = pan.Gongs[dui - 1];
            model.HuiGongs.Add(pan.Gongs[hui1 - 1]);
            model.HuiGongs.Add(pan.Gongs[hui2 - 1]);

            return model;
        }

        public float CaiboScore(PaiPan pan, Gong caibo)
        {
            var sfsz = SanFangSiZheng(pan, caibo.Name);
            // 主星
            List<Star> zhuxing = caibo.Stars.Where(s => s.Type == Star.StarType.主星).ToList();
            if (zhuxing == null || zhuxing.Count == 0)
            {
                zhuxing = new List<Star>();
                var duiStars = sfsz.DuiZhaoGong.Stars.Where(s => s.Type == Star.StarType.主星);
                foreach (var star in duiStars)
                {
                    var s = new Star(star.Name, star.Type);
                    if (star.LiangDu != null)
                    {
                        int ld = (int)star.LiangDu;
                        ld -= 2;
                        if (ld < -3) 
                            ld = -3;
                        s.LiangDu = ld;
                    }
                    zhuxing.Add(s);
                }
            }

            // 辅星
            var fuxing = caibo.Stars.Where(s => dal.Dic_JiXing.ContainsKey(s.Name) || dal.Dic_XiongXing.ContainsKey(s.Name)).ToList();

            // 会照辅星
            List<Star> huizhaoFuxing = new List<Star>();
            foreach (var s in sfsz.DuiZhaoGong.Stars)
            {
                if (dal.Dic_JiXing.ContainsKey(s.Name) || dal.Dic_XiongXing.ContainsKey(s.Name))
                {
                    huizhaoFuxing.Add(s);
                }
            }
            foreach (var s in sfsz.HuiGongs[0].Stars)
            {
                if (dal.Dic_JiXing.ContainsKey(s.Name) || dal.Dic_XiongXing.ContainsKey(s.Name))
                {
                    huizhaoFuxing.Add(s);
                }
            }
            foreach (var s in sfsz.HuiGongs[1].Stars)
            {
                if (dal.Dic_JiXing.ContainsKey(s.Name) || dal.Dic_XiongXing.ContainsKey(s.Name))
                {
                    huizhaoFuxing.Add(s);
                }
            }

            // 三方四正是否有武曲
            bool hasWuqu = false;
            if (sfsz.SelfGong.Stars.Exists(s => s.Name == "武曲")
                || sfsz.DuiZhaoGong.Stars.Exists(s => s.Name == "武曲")
                || sfsz.HuiGongs[0].Stars.Exists(s => s.Name == "武曲")
                || sfsz.HuiGongs[1].Stars.Exists(s => s.Name == "武曲"))
            {
                hasWuqu = true;
            }

            return CaiboScore(zhuxing, fuxing, huizhaoFuxing, hasWuqu);
        }

        private float CaiboScore(IList<Star> zhuXing,IList<Star> fuXing,IList<Star> huizhaoFuXing, bool hasWuqu)
        {
            if(zhuXing == null || zhuXing.Count == 0) 
                return 0;

            float totalScore = 0;

            // 主星得分
            if(zhuXing.Count == 1) {
                int liandu = (int)zhuXing[0].LiangDu;
                totalScore = caiboZhuXingScore[zhuXing[0].Name] * liangduWeight[liandu];
            } else if(zhuXing.Count == 2) {
                float liandu = (liangduWeight[(int)zhuXing[0].LiangDu] + liangduWeight[(int)zhuXing[1].LiangDu]) / 2;
                int score = 0;
                bool exist = caiboZhuXingScore.TryGetValue(zhuXing[0].Name + zhuXing[1].Name, out score);
                if(!exist)
                    exist = caiboZhuXingScore.TryGetValue(zhuXing[1].Name + zhuXing[0].Name, out score);
                if(!exist)
                    return 0;
                totalScore = score * liandu;
            }

            // 辅星吉星得分
            foreach (var star in fuXing)
            {
                int score = 0;
                if (caiboJiXingScore.TryGetValue(star.Name, out score))
                    totalScore += score;
            }

            // 会照辅星吉星得分
            foreach (var star in huizhaoFuXing)
            {
                int score = 0;
                if (sfszJiXingScore.TryGetValue(star.Name, out score))
                    totalScore += score;
            }

            // 武曲加分
            if (hasWuqu)
                totalScore += caiboJiXingScore["武曲"];

            // 辅星凶星加权
            bool hasTanLang = (zhuXing.FirstOrDefault(s => s.Name == "贪狼")!=null)?true:false;
            foreach (var star in fuXing)
            {
                float weight = 1;
                if(caiboXiongXingWeight.TryGetValue(star.Name, out weight))
                {
                    float weight2 = 1;
                    if (hasTanLang && caiboXiongXingWeight.TryGetValue(star.Name, out weight2))
                    {
                        totalScore = totalScore * weight2;
                    }
                    else
                    {
                        totalScore = totalScore * weight;
                    }
                }
            }

            // 会照辅星凶星加权
            foreach (var star in huizhaoFuXing)
            {
                float weight = 1;
                if (sfszXiongXingWeight.TryGetValue(star.Name, out weight))
                {
                    totalScore = totalScore * weight;
                }
            }

            return totalScore;
        }

        #region 流年参数
        private const float ming_weight = 1f;
        private const float xian_weight = 0.2f;
        private const float liu_weight = 0.8f;
        private static Dictionary<int, float> liangduWeight = new Dictionary<int, float>()
        {
            {3, 1.5f},
            {2, 1.2f},
            {1, 1f},
            {0, 1f},
            {-1, 0.8f},
            {-2, 0.7f},
            {-3, 0.5f}
        };
        private static Dictionary<string, int> caiboJiXingScore = new Dictionary<string, int>()
        {
            {"武曲",30},
            {"禄存",30},
            {"天马",10},
            {"化禄",30},
        };
        private static Dictionary<string, float> caiboXiongXingWeight = new Dictionary<string, float>()
        {
            {"火星",1.1f},
            {"铃星",0.9f},
            {"擎羊",0.9f},
            {"陀罗",0.8f},
            {"地空",0.7f},
            {"地劫",0.7f},
        };
        private static Dictionary<string, float> caiboTanLangWeight = new Dictionary<string, float>()
        {
            {"火星",1.5f},
            {"铃星",1.3f},
        };

        private static Dictionary<string, int> sfszJiXingScore = new Dictionary<string, int>()
        {
            {"武曲",30},
            {"禄存",30},
            {"天马",10},
            {"化禄",30},
        };
        private static Dictionary<string, float> sfszXiongXingWeight = new Dictionary<string, float>()
        {
            {"火星",1.1f},
            {"铃星",0.9f},
            {"擎羊",0.9f},
            {"陀罗",0.8f},
            {"地空",0.7f},
            {"地劫",0.7f},
        };
        
        private static Dictionary<string, int> caiboZhuXingScore = new Dictionary<string, int>() 
        { 
            {"紫微",70},
            {"天机",30},
            {"太阳",60},
            {"武曲",80},
            {"天同",40},
            {"廉贞",20},
            {"天府",70},
            {"太阴",60},
            {"贪狼",40},
            {"巨门",10},
            {"天相",10},
            {"天梁",10},
            {"七杀",20},
            {"破军",10},
            {"紫微破军",50},
            {"紫微天府",90},
            {"紫微贪狼",90},
            {"紫微天相",40},
            {"紫微七杀",90},
            {"天机太阴",50},
            {"天机巨门",20},
            {"天机天梁",20},
            {"太阳太阴",50},
            {"太阳巨门",80},
            {"太阳天梁",40},
            {"武曲七杀",80},
            {"武曲天相",70},
            {"武曲破军",50},
            {"武曲天府",90},
            {"武曲贪狼",80},
            {"天同巨门",10},
            {"天同天梁",10},
            {"天同太阴",50},
            {"廉贞天府",50},
            {"廉贞贪狼",40},
            {"廉贞天相",30},
            {"廉贞七杀",40},
            {"廉贞破军",10}
        };
        #endregion

        #endregion
    }

    public class LiuNianInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string text { get; set; }
    }
}
