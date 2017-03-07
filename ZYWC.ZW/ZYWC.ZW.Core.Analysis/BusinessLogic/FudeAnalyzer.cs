using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class FudeAnalyzer : GongAnalyzer
    {
        public FudeAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public FuDeGong GetResult(PaiPan pan)
        {
            FuDeGong result = base.GetResult<FuDeGong>(pan, GongIndex.福德宫, 0);

            //主星
            foreach (var xing in result.ZhuXing)
            {
                if (pan.IsMale)
                {
                    xing.Content = dal.s12.Find(x => x.id == xing.Id.ToString()).jiexinan;
                }
                else
                {
                    xing.Content = dal.s12.Find(x => x.id == xing.Id.ToString()).jiexinu;
                }
            }

            //吉星
            foreach (var xing in result.JiXing)
            {
                xing.Content = dal.s12.Find(x => x.id == xing.Id.ToString()).jiexinan;
            }

            //凶星
            foreach (var xing in result.XiongXing)
            {
                xing.Content = dal.s12.Find(x => x.id == xing.Id.ToString()).jiexinan;
            }

            if (result.ZhuXing.Count == 2)
            {
                var shuang = dal.s12.Find(x => x.id == string.Format("{0}#{1}", result.ZhuXing[0].Id, result.ZhuXing[1].Id));
                result.ShuangZhuXing = pan.IsMale ? shuang.jiexinan : shuang.jiexinu;
            }

            base.GetJiXiong<FuDeGong>(result);

            return result;
        }

    }
}
