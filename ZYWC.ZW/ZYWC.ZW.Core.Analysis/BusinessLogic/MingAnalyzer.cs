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
            MingGong result = base.GetResult<MingGong>(pan, GongIndex.命宫, 0);

            return result;
        }
    }
}
