using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class ShiYeAnalyzer: GongAnalyzer
    {
        public ShiYeAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public GuanLuGong GetResult(PaiPan pan)
        {
            GuanLuGong result = base.GetResult<GuanLuGong>(pan, GongIndex.官禄宫, 8);

            return result;
        }
    }
}
