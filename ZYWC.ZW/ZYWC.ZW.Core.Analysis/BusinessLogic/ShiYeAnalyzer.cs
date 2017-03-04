using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class ShiYeAnalyzer : GongAnalyzer
    {
        public ShiYeAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public GuanLuGong GetResult(PaiPan pan)
        {
            GuanLuGong result = base.GetResult<GuanLuGong>(pan, GongIndex.官禄宫, 8);

            result.ShiYeFenXi = new ShiYeFenXi();

            foreach (var item in dal.s9)
            {
                if (result.ZhuXing.Exists(x => x.Id == item.id))
                {
                    result.ShiYeFenXi.StarId = item.id;
                    result.ShiYeFenXi.Name = item.name;
                    result.ShiYeFenXi.juese = item.juese;
                    result.ShiYeFenXi.zhiye = item.zhiye;
                    result.ShiYeFenXi.zongping = item.zongping;
                    result.ShiYeFenXi.jianyi = item.jianyi;

                    int zhi = result.SelfGong.Zhi > 6 ? result.SelfGong.Zhi - 6 : result.SelfGong.Zhi;
                    switch (zhi)
                    {
                        case 1:
                            result.ShiYeFenXi.chenggongmijue = item.ziwu;
                            break;
                        case 2:
                            result.ShiYeFenXi.chenggongmijue = item.chouwei;
                            break;
                        case 3:
                            result.ShiYeFenXi.chenggongmijue = item.yinshen;
                            break;
                        case 4:
                            result.ShiYeFenXi.chenggongmijue = item.maoyou;
                            break;
                        case 5:
                            result.ShiYeFenXi.chenggongmijue = item.chenxu;
                            break;
                        default:
                            result.ShiYeFenXi.chenggongmijue = item.sihai;
                            break;
                    }


                    break;
                }
            }


            return result;
        }
    }
}
