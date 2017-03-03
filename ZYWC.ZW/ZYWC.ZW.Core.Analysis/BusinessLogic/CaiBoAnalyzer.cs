using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class CaiBoAnalyzer : GongAnalyzer
    {
        public CaiBoAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public CaiBoGong GetResult(PaiPan pan)
        {
            throw new NotImplementedException();
            //s15

            //CaiBoGong result = base.GetResult<CaiBoGong>(pan, GongIndex.财帛宫, 10);

        }
    }
}
