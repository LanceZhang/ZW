using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class FuQiAnalyzer : GongAnalyzer
    {
        public FuQiAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public FuQiGong GetResult(PaiPan pan)
        {
            FuQiGong result = base.GetResult<FuQiGong>(pan, GongIndex.夫妻宫, 3);

            //命宫主星爱情分析
            result.AiQingFenXi = new AiQingFenXi();

            var stars = pan.MingGong.Stars.Select(s => s.Name);

            foreach (var item in dal.s8)
            {
                if (stars.Contains(item.name.Substring(0, 2)))
                {
                    result.AiQingFenXi.StarId = int.Parse(item.id);
                    result.AiQingFenXi.Name = item.name;
                    result.AiQingFenXi.aiqingguan = item.aiqingguan;
                    result.AiQingFenXi.jianyi = item.jianyi;
                    result.AiQingFenXi.shihe = item.shihe;

                    var liangdu = pan.MingGong.Stars.First(s => s.Name == item.name.Substring(0, 2)).LiangDu;
                    if (liangdu.HasValue && liangdu.Value < 0)
                    {
                        result.AiQingFenXi.liangdu = item.ruoxian;
                    }
                    else
                    {
                        result.AiQingFenXi.liangdu = item.miaowang;
                    }

                    break; //一定break
                }
            }

            return result;
        }
    }
}
