using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class JiaoYouAnalyzer: GongAnalyzer
    {
        public JiaoYouAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public PuYiGong GetResult(PaiPan pan)
        {
            PuYiGong result = base.GetResult<PuYiGong>(pan, GongIndex.仆役宫, 7);

            return result;
        }
    }
}
