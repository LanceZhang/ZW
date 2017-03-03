using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class FuMuAnalyzer : GongAnalyzer
    {
        public FuMuAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public FuMuGong GetResult(PaiPan pan)
        {
            FuMuGong result = base.GetResult<FuMuGong>(pan, GongIndex.父母宫, 10);

            return result;
        }
    }
}
