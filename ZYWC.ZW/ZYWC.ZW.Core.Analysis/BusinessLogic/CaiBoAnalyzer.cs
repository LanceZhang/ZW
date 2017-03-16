using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class CaiBoAnalyzer : GongAnalyzer
    {
        public CaiBoAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public CaiBoGong GetResult(PaiPan pan)
        {
            CaiBoGong result = base.GetResult<CaiBoGong>(pan, GongIndex.财帛宫, 0);

            //主星
            foreach (var xing in result.ZhuXing)
            {
                var t = dal.s15.Find(x => x.id == xing.Id.ToString());
                xing.Content = t.caibo;
                xing.Risk = t.caibofengxian;
            }

            //吉星
            foreach (var xing in result.JiXing)
            {
                xing.Content = dal.s15.Find(x => x.id == xing.Id.ToString()).caibo;
            }

            //凶星
            foreach (var xing in result.XiongXing)
            {
                xing.Content = dal.s15.Find(x => x.id == xing.Id.ToString()).caibo;
            }

            if (result.ZhuXing.Count == 2)
            {
                var shuang = dal.s15.Find(x => x.id == string.Format("{0}#{1}", result.ZhuXing[0].Id, result.ZhuXing[1].Id));
                result.ShuangZhuXing = shuang.caibo;
                result.ShuangZhuXingRisk = shuang.caibofengxian;
            }


            //命宫、田宅对财运方面影响

            var zhuxing = pan.MingGong.Stars.Where(s => dal.Dic_ZhuXing.ContainsKey(s.Name)).ToList();
            foreach (var item in zhuxing)
            {
                result.MingXing.Add(new Xing(item, dal.Dic_ZhuXing[item.Name].id, Position.坐宫));
            }

            var fuxing = pan.MingGong.Stars.Where(s => dal.Dic_JiXing.ContainsKey(s.Name)).ToList();
            foreach (var item in fuxing)
            {
                result.MingXing.Add(new Xing(item, dal.Dic_JiXing[item.Name].id, Position.坐宫));
            }

            var xiongxing = pan.MingGong.Stars.Where(s => dal.Dic_XiongXing.ContainsKey(s.Name)).ToList();
            foreach (var item in xiongxing)
            {
                result.MingXing.Add(new Xing(item, dal.Dic_XiongXing[item.Name].id, Position.坐宫));
            }

            //
            var tianzhai = pan.Gongs.First(g => g.Name == GongIndex.田宅宫.ToString());

            zhuxing = tianzhai.Stars.Where(s => dal.Dic_ZhuXing.ContainsKey(s.Name)).ToList();
            foreach (var item in zhuxing)
            {
                result.TianZhaiXing.Add(new Xing(item, dal.Dic_ZhuXing[item.Name].id, Position.坐宫));
            }

            fuxing = tianzhai.Stars.Where(s => dal.Dic_JiXing.ContainsKey(s.Name)).ToList();
            foreach (var item in fuxing)
            {
                result.TianZhaiXing.Add(new Xing(item, dal.Dic_JiXing[item.Name].id, Position.坐宫));
            }

            xiongxing = tianzhai.Stars.Where(s => dal.Dic_XiongXing.ContainsKey(s.Name)).ToList();
            foreach (var item in xiongxing)
            {
                result.TianZhaiXing.Add(new Xing(item, dal.Dic_XiongXing[item.Name].id, Position.坐宫));
            }

            //

            foreach (var xing in result.MingXing)
            {
                xing.Content = dal.s15.Find(s => s.id == xing.Id.ToString()).mingong;
            }

            foreach (var xing in result.TianZhaiXing)
            {
                xing.Content = dal.s15.Find(s => s.id == xing.Id.ToString()).tianzai;
            }



            return result;
        }
    }
}
