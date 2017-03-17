using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;


namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class LiuNianAnalyzer
    {
        private DAL dal;

        public LiuNianAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public IList<LiuNianInfo> GetLiuNianInfo(PaiPan pan, GongIndex index)
        {
            var list = new List<LiuNianInfo>();
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
                //case GongIndex.夫妻宫: id = 0; break;
                //case GongIndex.夫妻宫: id = 0; break;
                default: return list;
            }

            var container = dal.s43.Find(d => d.id == id);
            var gong = pan.Gongs.First(g => g.LiuName == index.ToString());
            var stars = gong.Stars.Where(s => s.Type == Star.StarType.主星).ToList();
            string xingid = null;
            if (stars.Count == 1)
            {
                xingid = dal.Dic_ZhuXing[stars[0].Name].id.ToString();
            } 
            else if (stars.Count == 2)
            {
                xingid = string.Format("{0}#{1}", dal.Dic_ZhuXing[stars[0].Name].id, dal.Dic_ZhuXing[stars[1].Name].id);
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

    }

    public class LiuNianInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string text { get; set; }
    }
}
