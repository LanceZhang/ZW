using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public abstract class BasicGong
    {
        public abstract string Name { get; }

        public Gong SelfGong { get; set; }

        public string GongWei { get; set; }

        public Gong DuiZhaoGong { get; set; }

        public List<Gong> HuiGongs { get; set; }

        public List<Xing> ZhuXing { get; set; }

        public List<Xing> JiXing { get; set; }

        public List<Xing> XiongXing { get; set; }

        public int JiXiongZhiShu { get; set; }


        public BasicGong()
        {
            HuiGongs = new List<Gong>();
            ZhuXing = new List<Xing>();
            JiXing = new List<Xing>();
            XiongXing = new List<Xing>();
        }


        public string ToString()
        {
            return string.Format(@"
【{0}】：
三方四正：[{1}]对照，[{2}]拱会，[{3}]拱会
宫位：{4}

主星：
{5}
吉星：
{6}
凶星：
{7}", Name
       , DuiZhaoGong.Name, HuiGongs[0].Name, HuiGongs[1].Name
       , GongWei
       , GetXingsString(ZhuXing)
       , GetXingsString(JiXing)
       , GetXingsString(XiongXing)
       );
        }


        private string GetXingsString(List<Xing> xings)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var xing in xings)
            {
                if (!string.IsNullOrEmpty(xing.HuaContent))
                {
                    sb.AppendLine(string.Format("{0}:\t{1}", xing.HuaToString(), xing.HuaContent));
                }

                sb.AppendLine(string.Format("{0}:\t{1}", xing.ToString(), xing.Content));
            }



            return sb.ToString();
        }
    }


    public class Xing
    {
        public int Id { get; private set; }

        public Star Star { get; private set; }

        public Position Position { get; private set; }

        public string Content { get; set; }

        public string HuaContent { get; set; }

        public Xing(Star star, int id, Position position)
        {
            this.Star = star;
            this.Id = id;
            this.Position = position;
        }


        public string ToString()
        {
            return string.Format("{0}{1}", Star.Name, Position);
        }

        public string HuaToString()
        {
            return string.Format("{0}化{2}{1}", Star.Name, Position, Star.Hua);
        }

    }


    public enum Position
    {
        坐宫,
        对照,
        加会
    }

}
