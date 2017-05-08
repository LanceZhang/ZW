using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class BasicGong
    {
        public virtual GongIndex Name { get; set; }

        public Gong SelfGong { get; set; }

        public string GongWei { get; set; }

        public Gong DuiZhaoGong { get; set; }

        public List<Gong> HuiGongs { get; set; }

        public List<Xing> ZhuXing { get; set; }
        public bool isJieXing { get; set; }

        public List<Xing> JiXing { get; set; }

        public List<Xing> XiongXing { get; set; }

        public List<Hua> Hua { get; set; }

        public double JiXiongZhiShu { get; set; }

        public DaShi DaShi { get; set; }


        public BasicGong()
        {
            HuiGongs = new List<Gong>();
            ZhuXing = new List<Xing>();
            JiXing = new List<Xing>();
            XiongXing = new List<Xing>();
            Hua = new List<Hua>();
            DaShi = new DaShi();
        }


        public override string ToString()
        {
            return string.Format(@"
【{0}】：
三方四正：[{1}]对照，[{2}]拱会，[{3}]拱会
宫位：{4}
吉凶指数：{8}%

主星：
{5}
吉星：
{6}
凶星：
{7}

大师赠言：
命中特点：{9}
大师建议：{10}

", Name
       , DuiZhaoGong.Name, HuiGongs[0].Name, HuiGongs[1].Name
       , GongWei
       , GetXingsString(ZhuXing)
       , GetXingsString(JiXing)
       , GetXingsString(XiongXing)
       , JiXiongZhiShu.ToString(".00")
       , DaShi.MingZhongTeDian??string.Empty
       , DaShi.JianYi ?? string.Empty
       );
        }


        protected string GetXingsString(List<Xing> xings)
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
        public string Risk { get; set; }

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

    public class Hua
    {
        public string StarName { get; set; }

        public HuaType HuaType { get; set; }

        public Position Position { get; set; }

        public Hua(string name, HuaType type, Position position)
        {
            this.HuaType = type;
            this.Position = position;
            this.StarName = name;
        }
    }


    public enum Position
    {
        坐宫,
        对照,
        加会
    }

    public enum HuaType
    {
        禄,
        权,
        科,
        忌
    }


    public class DaShi
    {
        public float JiXiongZhiShu { get; set; }

        public string MingZhongTeDian { get; set; }

        public string JianYi { get; set; }
    }

}
