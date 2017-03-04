using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class ZiNvAnalyzer : GongAnalyzer
    {
        public ZiNvAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public ZiNvGong GetResult(PaiPan pan)
        {
            ZiNvGong result = base.GetResult<ZiNvGong>(pan, GongIndex.子女宫, 4);

            return result;
        }
    }
}
