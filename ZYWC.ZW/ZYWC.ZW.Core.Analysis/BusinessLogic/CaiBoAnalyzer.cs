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
                xing.Content = dal.s15.Find(x => x.id == xing.Id.ToString()).caibo;
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
            }


            return result;
        }
    }
}
