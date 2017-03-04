using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class QianYiAnalyzer: GongAnalyzer
    {
        public QianYiAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public QianYiGong GetResult(PaiPan pan)
        {
            QianYiGong result = base.GetResult<QianYiGong>(pan, GongIndex.迁移宫, 6);

            return result;
        }
    }
}
