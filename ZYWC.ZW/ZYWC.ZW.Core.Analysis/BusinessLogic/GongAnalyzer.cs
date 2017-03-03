using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public abstract class GongAnalyzer
    {
        protected DAL dal = null;


        public T GetResult<T>(PaiPan pan, GongIndex gong_idx, int index_of_s2) where T : BasicGong, new()
        {
            T model = new T();

            #region 宫位信息初始化

            //三方四正
            model.SelfGong = pan.Gongs.First(g => g.Name == gong_idx.ToString());

            int dui = (model.SelfGong.Zhi + 6) % 12;
            if (dui == 0)
            {
                dui = 12;
            }

            int hui1 = (model.SelfGong.Zhi + 4) % 12;
            if (hui1 == 0)
            {
                hui1 = 12;
            }

            int hui2 = (model.SelfGong.Zhi - 4) % 12;
            if (hui2 == 0)
            {
                hui2 = 12;
            }

            model.DuiZhaoGong = pan.Gongs[dui - 1];
            model.HuiGongs.Add(pan.Gongs[hui1 - 1]);
            model.HuiGongs.Add(pan.Gongs[hui2 - 1]);


            //主星
            var zhuxing = model.SelfGong.Stars.Where(s => dal.Dic_ZhuXing.ContainsKey(s.Name)).ToList();
            if (zhuxing.Count == 0)
            {
                zhuxing = model.DuiZhaoGong.Stars.Where(s => dal.Dic_ZhuXing.ContainsKey(s.Name)).ToList(); //借星
            }

            foreach (var item in zhuxing)
            {
                model.ZhuXing.Add(new Xing(item, dal.Dic_ZhuXing[item.Name].id, Position.坐宫));
            }




            //吉星
            foreach (var item in model.SelfGong.Stars.Where(s => dal.Dic_JiXing.ContainsKey(s.Name)).ToList())
            {
                model.JiXing.Add(new Xing(item, dal.Dic_JiXing[item.Name].id, Position.坐宫));
            }

            foreach (var item in model.DuiZhaoGong.Stars.Where(s => dal.Dic_JiXing.ContainsKey(s.Name)).ToList())
            {
                model.JiXing.Add(new Xing(item, dal.Dic_JiXing[item.Name].id, Position.对照));
            }

            foreach (var gong in model.HuiGongs)
            {
                foreach (var item in gong.Stars.Where(s => dal.Dic_JiXing.ContainsKey(s.Name)).ToList())
                {
                    model.JiXing.Add(new Xing(item, dal.Dic_JiXing[item.Name].id, Position.加会));
                }
            }





            //凶星
            foreach (var item in model.SelfGong.Stars.Where(s => dal.Dic_XiongXing.ContainsKey(s.Name)).ToList())
            {
                model.XiongXing.Add(new Xing(item, dal.Dic_XiongXing[item.Name].id, Position.坐宫));
            }

            foreach (var item in model.DuiZhaoGong.Stars.Where(s => dal.Dic_XiongXing.ContainsKey(s.Name)).ToList())
            {
                model.XiongXing.Add(new Xing(item, dal.Dic_XiongXing[item.Name].id, Position.对照));
            }

            foreach (var gong in model.HuiGongs)
            {
                foreach (var item in gong.Stars.Where(s => dal.Dic_XiongXing.ContainsKey(s.Name)).ToList())
                {
                    model.XiongXing.Add(new Xing(item, dal.Dic_XiongXing[item.Name].id, Position.加会));
                }
            }

            #endregion

            //宫位
            model.GongWei = string.Format("【{0}在{1}】", gong_idx.ToString(), model.SelfGong.ZhiString) + dal.s11[model.SelfGong.Zhi - 1].items[gong_idx.GetHashCode()];

            //主星
            foreach (var xing in model.ZhuXing)
            {
                xing.Content = dal.s2[xing.Id].items[index_of_s2];
            }

            //吉星
            foreach (var xing in model.JiXing)
            {
                xing.Content = dal.s2[xing.Id].items[index_of_s2];
            }

            //凶星
            foreach (var xing in model.XiongXing)
            {
                xing.Content = dal.s2[xing.Id].items[index_of_s2];
            }

            //四化
            foreach (var item in model.ZhuXing.Where(x => !string.IsNullOrEmpty(x.Star.Hua)))
            {
                switch (item.Star.Hua)
                {
                    case "禄":
                        item.HuaContent = dal.s4.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                    case "权":
                        item.HuaContent = dal.s5.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                    case "科":
                        item.HuaContent = dal.s6.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                    case "忌":
                        item.HuaContent = dal.s7.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                }
            }

            foreach (var item in model.JiXing.Where(x => !string.IsNullOrEmpty(x.Star.Hua)))
            {
                switch (item.Star.Hua)
                {
                    case "禄":
                        item.HuaContent = dal.s4.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                    case "权":
                        item.HuaContent = dal.s5.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                    case "科":
                        item.HuaContent = dal.s6.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                    case "忌":
                        item.HuaContent = dal.s7.Find(x => x.id == item.Id).items[gong_idx.GetHashCode()];
                        break;
                }
            }


            return model;
        }
    }
}
