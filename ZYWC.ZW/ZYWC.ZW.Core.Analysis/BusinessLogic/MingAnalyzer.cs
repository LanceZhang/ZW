using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class MingAnalyzer : GongAnalyzer
    {
        public MingAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public MingGong GetResult(PaiPan pan)
        {
            MingGong result = base.GetResult<MingGong>(pan, GongIndex.命宫, pan.IsMale ? 0 : 1);

            //身
            var shen = pan.Gongs.First(g => g.Is_Shen);
            result.ShenGongPosition = shen.Name;
            result.ShenGongContent = dal.s3.Find(s => shen.Name.Contains(s.name)).text;


            //分析
            s10_xingdi fenxi = null;
            if (result.ZhuXing.Count == 2)
            {
                fenxi = dal.s10.Find(s => s.id == string.Format("{0}#{1}", result.ZhuXing[0].Id, result.ZhuXing[1].Id));
            }
            else
            {
                fenxi = dal.s10.Find(s => s.id == result.ZhuXing[0].Id.ToString());
            }

            result.Youdian = fenxi.youdian;
            result.Quedian = fenxi.quedian;
            result.Fenxi = fenxi.fenxi;

            return result;
        }
    }
}
