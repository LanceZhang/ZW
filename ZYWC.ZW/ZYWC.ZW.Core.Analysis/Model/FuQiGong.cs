using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class FuQiGong : BasicGong
    {
        public override GongIndex Name
        {
            get { return GongIndex.夫妻宫; }
        }
    }
}