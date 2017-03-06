using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.Model
{
    public class GeJu
    {
        private List<s26_minggonggeju> jiGe = new List<s26_minggonggeju>();
        private List<s26_minggonggeju> xiongGe = new List<s26_minggonggeju>();

        public IList<s26_minggonggeju> JiGe { get { return jiGe; } }
        public IList<s26_minggonggeju> XiongGe { get { return xiongGe; } }

        public GeJu(IList<s26_minggonggeju> geList)
        {
            foreach(var ge in geList)
            {
                if (ge.gejuJixiong == "吉")
                    jiGe.Add(ge);

                if (ge.gejuJixiong == "凶")
                    jiGe.Add(ge);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("格局：\n");
            sb.Append("    吉格：\n");
            if (jiGe.Count == 0)
                sb.Append("        无\n");
            else
            {
                foreach (var ge in jiGe)
                    sb.AppendFormat("        {0}：{1}\n", ge.gejuname, ge.text);
            }

            sb.Append("    凶格：\n");
            if (xiongGe.Count == 0)
                sb.Append("        无\n");
            else
            {
                foreach (var ge in xiongGe)
                    sb.AppendFormat("        {0}：{1}\n", ge.gejuname, ge.text);
            }

            return sb.ToString();
        }
        
    }
}
