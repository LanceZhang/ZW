using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class JiEAnalyzer: GongAnalyzer
    {
        public JiEAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public JiEGong GetResult(PaiPan pan)
        {
            JiEGong result = base.GetResult<JiEGong>(pan, GongIndex.疾厄宫, 5);

            return result;
        }
    }
}
