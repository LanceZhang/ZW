
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class TianZhaiAnalyzer: GongAnalyzer
    {
        public TianZhaiAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public TianZhaiGong GetResult(PaiPan pan)
        {
            TianZhaiGong result = base.GetResult<TianZhaiGong>(pan, GongIndex.田宅宫, 9);

            return result;
        }
    }
}
