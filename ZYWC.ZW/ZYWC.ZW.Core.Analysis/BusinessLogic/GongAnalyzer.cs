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





            //主星四化
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


            //四化（不只主星）
            foreach (var item in model.DuiZhaoGong.Stars.Where(x => !string.IsNullOrEmpty(x.Hua)))
            {
                model.Hua.Add(new Hua(item.Name, (HuaType)Enum.Parse(typeof(HuaType), item.Hua, false), Position.对照));
            }

            foreach (var item in model.SelfGong.Stars.Where(x => !string.IsNullOrEmpty(x.Hua)))
            {
                model.Hua.Add(new Hua(item.Name, (HuaType)Enum.Parse(typeof(HuaType), item.Hua, false), Position.坐宫));
            }

            foreach (var item in model.HuiGongs[0].Stars.Where(x => !string.IsNullOrEmpty(x.Hua)))
            {
                model.Hua.Add(new Hua(item.Name, (HuaType)Enum.Parse(typeof(HuaType), item.Hua, false), Position.加会));
            }

            foreach (var item in model.HuiGongs[1].Stars.Where(x => !string.IsNullOrEmpty(x.Hua)))
            {
                model.Hua.Add(new Hua(item.Name, (HuaType)Enum.Parse(typeof(HuaType), item.Hua, false), Position.加会));
            }


            //福德则直接返回
            if (gong_idx == GongIndex.福德宫)
            {
                return model;
            }


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


            //计算吉凶指数
            int ji = 0;
            int xiong = 0;

            var jis = model.JiXing.Select(j => j.Star.Name).ToList();
            var self_jis = model.SelfGong.Stars.Where(s => dal.Dic_JiXing.ContainsKey(s.Name)).Select(j => j.Name).ToList();

            //组合
            var xiongs = model.XiongXing.Select(j => j.Star.Name).ToList();
            var self_xiongs = model.SelfGong.Stars.Where(s => dal.Dic_XiongXing.ContainsKey(s.Name)).Select(j => j.Name).ToList();

            var jizu = dal.s20.jixiongzhishu.Where(jx => jx.id > 16
                && jis.Contains(jx.name.Substring(0, 2))
                && jis.Contains(jx.name.Substring(2, 2))
                && !self_jis.Contains(jx.name.Substring(0, 2))
                && !self_jis.Contains(jx.name.Substring(2, 2)));

            var xiongzu = dal.s20.jixiongzhishu.Where(jx => jx.id > 16
                && xiongs.Contains(jx.name.Substring(0, 2))
                && xiongs.Contains(jx.name.Substring(2, 2))
                && !self_xiongs.Contains(jx.name.Substring(0, 2))
                && !self_xiongs.Contains(jx.name.Substring(2, 2)));

            ji += jizu.Count() * 3;
            xiong += xiongzu.Count() * 3;


            //单星
            ji += self_jis.Count * 2;
            ji += (jis.Count - self_jis.Count) * 1;

            xiong += self_xiongs.Count * 2;
            xiong += (xiongs.Count - self_xiongs.Count) * 1;


            //四化(有非本宫组合++)
            if (model.Hua.Exists(h => h.HuaType == HuaType.忌))
            {
                xiong += 1;
                if (model.Hua.Exists(h => h.HuaType == HuaType.忌 && h.Position == Position.坐宫))
                {
                    xiong += 1;
                }
            }

            int goodhua = model.Hua.Count(h => h.HuaType != HuaType.忌);
            int goodselfhua = model.Hua.Count(h => h.HuaType != HuaType.忌 && h.Position == Position.坐宫);

            xiong += goodhua;
            xiong += goodselfhua;
            if (goodhua - goodselfhua > 1)
            {
                xiong += (goodhua - goodselfhua);
            }

            model.JiXiongZhiShu = ji * 100.00 / (ji + xiong);

            model.DaShi = DaShisWords.GetDaShi(model, dal);

            return model;
        }
    }
}
