using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class GongScoreAnalyzer : GongAnalyzer
    {
        //private DAL dal;
        public GongScoreAnalyzer(DAL dal)
        {
            this.dal = dal;
        }
        public IList<KeyValuePair<GongIndex, int>> Get12GongScore(PaiPan pan)
        {
            var ret = new List<KeyValuePair<GongIndex, int>>(12);

            for (int i = 0; i < 12; i++){
                var index = (GongIndex)i;
                var gong = base.GetResult<BasicGong>(pan, index, 0);
                var score = GetScore(gong, index);
                ret.Add( new KeyValuePair<GongIndex, int>(index, score));
            }

            return ret;
        }

        public int GetScore(BasicGong gong, GongIndex index)
        {
            float score = 0;

            #region 主星
            if (gong.ZhuXing.Count == 1){
                var xing = gong.ZhuXing[0];
                var xingScore = zhuXingScore[xing.Star.Name];
                var liandu = xing.Star.LiangDu.HasValue ? (int)xing.Star.LiangDu : 1;
                if (gong.isJieXing)
                {
                    liandu -= 2;
                    if (liandu < -3)
                        liandu = -3;
                }
                score += xingScore[(int)index] * LiangDuWieght[liandu];
            } else{
                var xing1 = gong.ZhuXing[0];
                var xing2 = gong.ZhuXing[1];
                var xingScore = zhuXingScore.ContainsKey(xing1.Star.Name + xing2.Star.Name) ? zhuXingScore[xing1.Star.Name + xing2.Star.Name] : zhuXingScore[xing2.Star.Name + xing1.Star.Name];
                var liandu1 = xing1.Star.LiangDu.HasValue ? (int)xing1.Star.LiangDu : 1;
                if (gong.isJieXing)
                {
                    liandu1 -= 2;
                    if (liandu1 < -3)
                        liandu1 = -3;
                }
                var liandu2 = xing2.Star.LiangDu.HasValue ? (int)xing2.Star.LiangDu : 1;
                if (gong.isJieXing)
                {
                    liandu2 -= 2;
                    if (liandu2 < -3)
                        liandu2 = -3;
                }
                score += xingScore[(int)index] * (LiangDuWieght[liandu1] + LiangDuWieght[liandu2]) / 2;
            }
            #endregion

            #region 吉星
            var zhuJixing = new List<Xing>();
            var otherJixing = new List<Xing>();
            foreach (var xing in gong.JiXing){
                if(gong.SelfGong.Stars.Exists(s => s.Name == xing.Star.Name))
                    zhuJixing.Add(xing);
                else
                    otherJixing.Add(xing);
            }

            if (zhuJixing.Exists(x => x.Star.Name == "文昌") && zhuJixing.Exists(x => x.Star.Name == "文曲")){
                zhuJixing.RemoveAll(x => x.Star.Name == "文昌" || x.Star.Name == "文曲");
                score += jiXingScore["文昌文曲"][0];
            }
            if (zhuJixing.Exists(x => x.Star.Name == "左辅") && zhuJixing.Exists(x => x.Star.Name == "右弼"))
            {
                zhuJixing.RemoveAll(x => x.Star.Name == "左辅" || x.Star.Name == "右弼");
                score += jiXingScore["左辅右弼"][0];
            }
            if (zhuJixing.Exists(x => x.Star.Name == "天魁") && zhuJixing.Exists(x => x.Star.Name == "天钺"))
            {
                zhuJixing.RemoveAll(x => x.Star.Name == "天魁" || x.Star.Name == "天钺");
                score += jiXingScore["天魁天钺"][0];
            }

            if (otherJixing.Exists(x => x.Star.Name == "文昌") && otherJixing.Exists(x => x.Star.Name == "文曲"))
            {
                otherJixing.RemoveAll(x => x.Star.Name == "文昌" || x.Star.Name == "文曲");
                score += jiXingScore["文昌文曲"][1];
            }
            if (otherJixing.Exists(x => x.Star.Name == "左辅") && otherJixing.Exists(x => x.Star.Name == "右弼"))
            {
                otherJixing.RemoveAll(x => x.Star.Name == "左辅" || x.Star.Name == "右弼");
                score += jiXingScore["左辅右弼"][1];
            }
            if (otherJixing.Exists(x => x.Star.Name == "天魁") && otherJixing.Exists(x => x.Star.Name == "天钺"))
            {
                otherJixing.RemoveAll(x => x.Star.Name == "天魁" || x.Star.Name == "天钺");
                score += jiXingScore["天魁天钺"][1];
            }

            foreach (var xing in zhuJixing){
                score += jiXingScore[xing.Star.Name][0];
            }
            foreach (var xing in otherJixing)
            {
                score += jiXingScore[xing.Star.Name][1];
            }

            #endregion

            #region 凶星
            var zhuXiongxing = new List<Xing>();
            var otherXiongxing = new List<Xing>();
            foreach (var xing in gong.XiongXing)
            {
                if (gong.SelfGong.Stars.Exists(s => s.Name == xing.Star.Name))
                    zhuXiongxing.Add(xing);
                else
                    otherXiongxing.Add(xing);
            }

            if (zhuXiongxing.Exists(x => x.Star.Name == "火星") && zhuXiongxing.Exists(x => x.Star.Name == "铃星"))
            {
                zhuXiongxing.RemoveAll(x => x.Star.Name == "火星" || x.Star.Name == "铃星");
                score += xiongXingScore["火星铃星"][0];
            }
            if (zhuXiongxing.Exists(x => x.Star.Name == "擎羊") && zhuXiongxing.Exists(x => x.Star.Name == "陀罗"))
            {
                zhuXiongxing.RemoveAll(x => x.Star.Name == "擎羊" || x.Star.Name == "陀罗");
                score += xiongXingScore["擎羊陀罗"][0];
            }
            if (zhuXiongxing.Exists(x => x.Star.Name == "地空") && zhuXiongxing.Exists(x => x.Star.Name == "地劫"))
            {
                zhuXiongxing.RemoveAll(x => x.Star.Name == "地空" || x.Star.Name == "地劫");
                score += xiongXingScore["地空地劫"][0];
            }

            if (otherXiongxing.Exists(x => x.Star.Name == "火星") && otherXiongxing.Exists(x => x.Star.Name == "铃星"))
            {
                otherXiongxing.RemoveAll(x => x.Star.Name == "火星" || x.Star.Name == "铃星");
                score += xiongXingScore["火星铃星"][1];
            }
            if (otherXiongxing.Exists(x => x.Star.Name == "擎羊") && otherXiongxing.Exists(x => x.Star.Name == "陀罗"))
            {
                otherXiongxing.RemoveAll(x => x.Star.Name == "擎羊" || x.Star.Name == "陀罗");
                score += xiongXingScore["擎羊陀罗"][1];
            }
            if (otherXiongxing.Exists(x => x.Star.Name == "地空") && otherXiongxing.Exists(x => x.Star.Name == "地劫"))
            {
                otherXiongxing.RemoveAll(x => x.Star.Name == "地空" || x.Star.Name == "地劫");
                score += xiongXingScore["地空地劫"][1];
            }

            foreach (var xing in zhuXiongxing)
            {
                score += xiongXingScore[xing.Star.Name][0];
            }
            foreach (var xing in otherXiongxing)
            {
                score += xiongXingScore[xing.Star.Name][1];
            }
            #endregion

            #region 特殊情况

            if (gong.XiongXing.Exists(x => x.Star.Name == "火星"))
            {
                if (gong.ZhuXing.Exists(x => x.Star.Name == "七杀")){
                    score += 40;
                }
                if (gong.ZhuXing.Exists(x => x.Star.Name == "贪狼"))
                {
                    score += 80;
                }
                if (gong.JiXing.Exists(x => x.Star.Name == "武曲"))
                {
                    score += 60;
                }
            }

            if (gong.XiongXing.Exists(x => x.Star.Name == "擎羊") && index==GongIndex.疾厄宫)
            {
                score += 80;
            }
            #endregion

            if (score < 40){
                score = 40 + score%4;
            }
            else if (score >= 200){
                score = 100;
            } else{
                score = (score - 40)*60/160 + 40;
            }
            return (int)score;
        }

        #region 计算参数
        static Dictionary<string, int[]> zhuXingScore = new Dictionary<string, int[]>()
        {
            {"紫微", new int[]{90,50,70,50,70,50,80,70,90,80,80,70}},
            {"天机", new int[]{70,60,60,70,50,40,60,40,70,60,60,50}},
            {"太阳", new int[]{80,70,80,70,70,70,70,60,80,70,70,80}},
            {"武曲", new int[]{80,20,60,70,80,50,70,20,80,90,60,40}},
            {"天同", new int[]{30,90,80,80,40,60,80,90,60,70,90,90}},
            {"廉贞", new int[]{70,50,60,80,40,60,80,90,90,60,70,40}},
            {"天府", new int[]{80,90,80,80,70,90,90,80,80,90,80,90}},
            {"太阴", new int[]{80,90,90,80,60,70,70,80,70,80,80,80}},
            {"贪狼", new int[]{70,10,70,60,60,60,80,30,90,60,60,50}},
            {"巨门", new int[]{60,40,60,50,30,60,60,50,70,40,70,50}},
            {"天相", new int[]{60,80,90,80,30,60,70,60,80,70,80,80}},
            {"天梁", new int[]{60,90,80,80,30,60,80,80,80,80,80,90}},
            {"七杀", new int[]{80,50,60,70,60,60,70,40,70,60,60,40}},
            {"破军", new int[]{80,30,70,50,50,60,70,40,60,60,60,40}},

            {"紫微破军", new int[]{90,40,70,50,65,55,75,55,75,70,70,55}},
            {"紫微天府", new int[]{90,70,75,65,90,70,85,75,85,85,80,80}},
            {"紫微贪狼", new int[]{90,30,70,55,90,55,80,50,90,70,70,60}},
            {"紫微天相", new int[]{75,65,80,65,40,55,75,65,85,75,80,75}},
            {"紫微七杀", new int[]{90,50,65,60,90,55,75,55,80,70,70,55}},
            {"天机太阴", new int[]{80,75,75,75,50,55,65,60,70,70,70,65}},
            {"天机巨门", new int[]{75,50,60,60,60,50,60,45,70,50,65,50}},
            {"天机天梁", new int[]{75,75,70,75,60,50,70,60,75,70,70,70}},
            {"太阳太阴", new int[]{85,80,85,75,70,70,70,70,75,75,75,80}},
            {"太阳巨门", new int[]{85,55,70,60,80,65,65,55,75,55,70,65}},
            {"太阳天梁", new int[]{85,80,80,75,40,65,75,70,80,75,75,85}},
            {"武曲七杀", new int[]{85,35,60,70,80,55,70,30,75,75,60,40}},
            {"武曲天相", new int[]{70,50,75,75,70,55,70,40,80,80,70,60}},
            {"武曲破军", new int[]{70,25,65,60,50,55,70,30,70,75,60,40}},
            {"武曲天府", new int[]{80,55,70,75,90,70,80,50,80,90,70,65}},
            {"武曲贪狼", new int[]{80,15,65,65,80,55,75,25,85,75,60,45}},
            {"天同巨门", new int[]{45,65,70,65,50,60,70,70,65,55,80,70}},
            {"天同天梁", new int[]{45,90,80,80,45,60,80,85,70,75,85,90}},
            {"天同太阴", new int[]{60,90,85,80,50,65,75,85,65,75,85,85}},
            {"廉贞天府", new int[]{70,70,70,80,50,75,85,85,85,75,75,65}},
            {"廉贞贪狼", new int[]{50,30,65,70,40,60,80,60,90,60,65,45}},
            {"廉贞天相", new int[]{70,65,75,80,40,60,75,75,85,65,75,60}},
            {"廉贞七杀", new int[]{70,50,60,75,40,60,75,65,80,60,65,40}},
            {"廉贞破军", new int[]{60,40,65,65,40,60,75,65,75,60,65,40}},
        }; 

        static Dictionary<int,float> LiangDuWieght = new Dictionary<int, float>()
        {
            {3,1.5f},
            {2,1.2f},
            {1,1.0f},
            {0,1.0f},
            {-1,0.8f},
            {-2,0.7f},
            {-3,0.5f},
        };

        private static Dictionary<string, int[]> jiXingScore = new Dictionary<string, int[]>()
        {
            {"禄存", new []{40,20}},
            {"天马", new []{40,20}},
            {"文昌", new []{40,20}},
            {"文曲", new []{40,20}},
            {"左辅", new []{40,20}},
            {"右弼", new []{40,20}},
            {"天魁", new []{40,20}},
            {"天钺", new []{40,20}},
            {"文昌文曲", new []{80,60}},
            {"左辅右弼", new []{80,60}},
            {"天魁天钺", new []{40,60}},
        };

        private static Dictionary<string, int[]> huaXingScore = new Dictionary<string, int[]>()
        {
            {"化禄", new []{60,20}},
            {"化权", new []{40,20}},
            {"化科", new []{40,20}},
            {"化忌", new []{-40,-20}},
        };

        private static Dictionary<string, int[]> xiongXingScore = new Dictionary<string, int[]>()
        {
            {"火星", new []{-20,-10}},
            {"铃星", new []{-10,-10}},
            {"擎羊", new []{-30,-20}},
            {"陀罗", new []{-10,-10}},
            {"地空", new []{-5,0}},
            {"地劫", new []{-5,0}},
            {"火星铃星", new []{-25,-20}},
            {"擎羊陀罗", new []{-30,-20}},
            {"地空地劫", new []{-5,-10}},
        };
        #endregion
    }
}
