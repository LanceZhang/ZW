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

            var shen = pan.Gongs.First(g => g.Is_Shen);
            result.ShenGongPosition = shen.Name;
            result.ShenGongContent = dal.s3.Find(s => shen.Name.Contains(s.name)).text;


            return result;
        }
    }
}
