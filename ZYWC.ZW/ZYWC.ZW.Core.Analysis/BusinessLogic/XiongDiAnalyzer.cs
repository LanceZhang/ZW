using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class XiongDiAnalyzer: GongAnalyzer
    {
        public XiongDiAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public XiongDiGong GetResult(PaiPan pan)
        {
            XiongDiGong result = base.GetResult<XiongDiGong>(pan, GongIndex.兄弟宫, 2);

            return result;
        }
    }
}
