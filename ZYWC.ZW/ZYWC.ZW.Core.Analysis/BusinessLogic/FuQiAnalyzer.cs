using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class FuQiAnalyzer: GongAnalyzer
    {
        public FuQiAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public FuQiGong GetResult(PaiPan pan)
        {
            FuQiGong result = base.GetResult<FuQiGong>(pan, GongIndex.夫妻宫, 3);

            return result;
        }
    }
}
