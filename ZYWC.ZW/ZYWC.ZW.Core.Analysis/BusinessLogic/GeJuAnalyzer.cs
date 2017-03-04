using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class GeJuAnalyzer
    {
        private delegate bool GeJuName(PaiPan pan);

        private DAL dal;
        private GeJuName[] gejuFuncs;
        private BasicGong sfsz;

        public GeJuAnalyzer(DAL dal)
        {
            this.dal = dal;
            initFuncsTable();
        }

        public IList<s26_minggonggeju> GeJuFromPaiPan(PaiPan pan)
        {
            sfsz = SanFangSiZheng(pan, GongIndex.命宫);
            var rets = new List<s26_minggonggeju>();
            for (var i = 0; i < dal.s26.Count && i < gejuFuncs.Length; i++)
            {
                if (gejuFuncs[i](pan))
                    rets.Add(dal.s26[i]);
            }
                
            return rets;
        }

        private BasicGong SanFangSiZheng(PaiPan pan, GongIndex index)
        {
            //三方四正
            var model = new BasicGong();
            model.SelfGong = pan.Gongs.First(g => g.Name == index.ToString());

            int dui = (model.SelfGong.Zhi + 6) % 12;
            if (dui == 0)
            {
                dui = 12;
            }
            else if (dui < 0)
            {
                dui += 12;
            }

            int hui1 = (model.SelfGong.Zhi + 4) % 12;
            if (hui1 == 0)
            {
                hui1 = 12;
            }
            else if (hui1 < 0)
            {
                hui1 += 12;
            }


            int hui2 = (model.SelfGong.Zhi - 4) % 12;
            if (hui2 == 0)
            {
                hui2 = 12;
            }
            else if (hui2 < 0)
            {
                hui2 += 12;
            }

            model.DuiZhaoGong = pan.Gongs[dui - 1];
            model.HuiGongs.Add(pan.Gongs[hui1 - 1]);
            model.HuiGongs.Add(pan.Gongs[hui2 - 1]);

            return model;
        }

        private bool 极向离明格(PaiPan pan)
        {
            // 紫薇在午宫坐命
            var gong = pan.Gongs.First(g => g.ZhiString == "午");        // 午宫
            var star = gong.Stars.FirstOrDefault(s => s.Name == "紫薇");  
            if (star != null && gong.Is_Ming)                            // 紫薇 坐命
                return true;
            return false;
        }

        private bool 君臣庆会格(PaiPan pan)
        {
            // 命宫有紫微星，且于三方四正中有 至少有左辅、右弼任何一星加会或同宫，或两星于两临宫相夹。
            var gong = pan.MingGong;
            var star = gong.Stars.FirstOrDefault(s => s.Name == "紫薇");  
            if (star == null) 
                return false;                              //命宫有紫微星

            // todo

            return false;
        }

        private bool 紫府同宫格(PaiPan pan)
        {
            // 安命在寅或申宫，紫薇天府同宫。

            // 安命在寅或申宫
            if (pan.MingGong.ZhiString != "寅" && pan.MingGong.ZhiString != "申")
                return false;

            // 紫薇天府同宫
            if (!pan.MingGong.Stars.Exists(s => s.Name == "紫薇")
                || !pan.MingGong.Stars.Exists(s => s.Name == "天府"))
                return false;

            return true;
        }

        private bool 紫府朝垣格(PaiPan pan)
        {
            // 紫薇、天府于三方四正照命。
            BasicGong sfsz = SanFangSiZheng(pan, GongIndex.命宫);
            if (sfsz.DuiZhaoGong.Stars.Exists(s => s.Name == "紫薇") 
                && sfsz.DuiZhaoGong.Stars.Exists(s => s.Name == "天府"))
                return true;

            return false;
        }

        private bool 巨机同宫格(PaiPan pan)
        {
            // 巨门、天机二星在卯宫或酉宫坐命，且无化忌同宫。

            // 卯宫或酉宫坐命
            if (pan.MingGong.ZhiString != "卯" && pan.MingGong.ZhiString != "酉")
                return false;

            // 巨门、天机二星坐命
            if (!pan.MingGong.Stars.Exists(s => s.Name == "巨门")
                || !pan.MingGong.Stars.Exists(s => s.Name == "天机"))
                return false;

            // 无化忌同宫
            if (pan.MingGong.Stars.Exists(s => s.Name == "化忌"))
                return false;

            return true;
        }

        private bool 善荫朝纲格(PaiPan pan)
        {
            // 天机、天梁二星同时在辰或戌宫守命，为此格。

            // 辰或戌宫守命
            if (pan.MingGong.ZhiString != "辰" && pan.MingGong.ZhiString != "戌")
                return false;

            // 天机、天梁二星守命
            if (!pan.MingGong.Stars.Exists(s => s.Name == "天机")
                || !pan.MingGong.Stars.Exists(s => s.Name == "天梁"))
                return false;

            return false;
        }

        private bool 机月同梁格(PaiPan pan)
        {
            // 于三方四正中有天机、太阴、天同、天梁四星交会。

            return false;
        }

        private bool 日丽中天格(PaiPan pan)
        {
            // 太阳在午宫坐命。

            // 午宫坐命
            if (pan.MingGong.ZhiString != "午")
                return false;

            // 太阳坐命
            if (!pan.MingGong.Stars.Exists(s => s.Name == "太阳"))
                return false;

            return true;
        }

        private bool 日照雷门格(PaiPan pan)
        {
            // 太阳在卯宫坐命。         日出扶桑格

            // 卯宫坐命
            if (pan.MingGong.ZhiString != "卯")
                return false;

            // 太阳坐命
            if (!pan.MingGong.Stars.Exists(s => s.Name == "太阳"))
                return false;

            return false;
        }

        private bool 日月同宫格(PaiPan pan)
        {
            // 命宫在丑或未，日月二星坐守。

            // 命宫在丑或未
            if (pan.MingGong.ZhiString == "丑" || pan.MingGong.ZhiString == "未")
            {
                // 日月二星坐守
                if (pan.MingGong.Stars.Exists(s => s.Name == "太阳")
                    && pan.MingGong.Stars.Exists(s => s.Name == "太阴"))
                {
                    return true;
                }
            }

            return false;
        }

        private bool 日月并明格(PaiPan pan)
        {
            // 日月位于三方四正中，且太阳在巳，太阴在酉或太阳在辰，太阴在戌，为本格。
            return false;
        }

        private bool 明珠出海格(PaiPan pan)
        {
            // 本宫在未宫，无主星坐命，且太阳在卯宫，太阴在亥宫。此时日月于三方四正中照命。
            return false;
        }

        private bool 巨日同宫格(PaiPan pan)
        {
            // 巨门太阳同时在寅或申宫坐命。
            return false;
        }

        private bool 阳梁昌禄格(PaiPan pan)
        {
            // 三方四正会齐了太阳、天梁、文昌、禄存四星。
            return false;
        }

        private bool 贪武同行格(PaiPan pan)
        {
            // 命宫在丑或未，武曲、贪狼二星坐守。
            return false;
        }

        private bool 将星得地格(PaiPan pan)
        {
            // 武曲坐命在辰或戌宫。
            return false;
        }

        private bool 财禄夹马格(PaiPan pan)
        {
            // 天马守命宫，二左右临宫有武曲与化禄来夹，或为武曲与禄存来夹。
            return false;
        }

        private bool 廉贞文武格(PaiPan pan)
        {
            // 廉贞坐命，官禄宫为武曲来会，三方四正再会文昌或文曲。
            return false;
        }

        private bool 财荫夹印格(PaiPan pan)
        {
            // 天相受化禄和天梁在左右临宫相夹。
            return false;
        }

        private bool 雄宿朝垣格(PaiPan pan)
        {
            // 廉贞在申或寅宫守命。
            return false;
        }

        private bool 府相朝垣格(PaiPan pan)
        {
            // 天府、天相于三方四正照命。
            return false;
        }

        private bool 月朗天门格(PaiPan pan)
        {
            // 太阴在亥宫守命，为本格。
            return false;
        }

        private bool 月生沧海格(PaiPan pan)
        {
            // 太阴，天同星在子宫坐命。
            return false;
        }

        private bool 三合火铃贪格(PaiPan pan)
        {
            // 贪狼守命，遇火星、铃星俱在命或三方会照。
            return false;
        }

        private bool 三合火贪格(PaiPan pan)
        {
            // 贪狼守命，遇火星在命或三方会照。
            return false;
        }

        private bool 三合铃贪格(PaiPan pan)
        {
            // 贪狼守命，遇铃星在命或三方会照。
            return false;
        }

        private bool 石中隐玉格(PaiPan pan)
        {
            // 巨门在子或午宫坐命。
            return false;
        }

        private bool 禄马配印格(PaiPan pan)
        {
            // 禄存、天马、天相同宫守命。或为化禄，天马，天相同宫守命。
            return false;
        }

        private bool 禄马交驰格(PaiPan pan)
        {
            // 命宫或三方有禄存、天马或化禄、天马。
            return false;
        }

        private bool 寿星入庙格(PaiPan pan)
        {
            // 天梁守命，入午宫。
            return false;
        }

        private bool 七杀朝斗格(PaiPan pan)
        {
            // 七杀于子或午或寅或申宫守命。
            return false;
        }

        private bool 英星入庙格(PaiPan pan)
        {
            // 破申守命居子或午宫。
            return false;
        }

        private bool 文桂文华格(PaiPan pan)
        {
            // 文昌、文曲两星在丑或未宫守命。
            return false;
        }

        private bool 文星拱命格(PaiPan pan)
        {
            // 文昌、文曲两星俱在三方四正中。
            return false;
        }

        private bool 紫府夹命格(PaiPan pan)
        {
            // 命宫在寅或申宫，与紫薇与天府来夹。
            return false;
        }

        private bool 日月夹命格(PaiPan pan)
        {
            // 命宫在丑或未宫，太阳与太阴在左右邻宫相夹。
            return false;
        }

        private bool 左右夹命格(PaiPan pan)
        {
            // 命宫在丑或未宫，左辅与右弼在左右邻宫相夹。
            return false;
        }

        private bool 昌曲夹命格(PaiPan pan)
        {
            // 命宫在丑或未宫，文昌与文曲在左右邻宫相夹。
            return false;
        }

        private bool 左右同宫格(PaiPan pan)
        {
            // 命宫在丑或未宫，左辅右弼同宫，为本格。
            return false;
        }

        private bool 辅拱文星格(PaiPan pan)
        {
            // 文昌、文曲在命宫，有辅弼两星在三方四正拱照或左右邻宫相夹。
            return false;
        }

        private bool 双禄朝垣格(PaiPan pan)
        {
            // 禄存和化禄俱在三方四正中。
            return false;
        }

        private bool 三奇嘉会格(PaiPan pan)
        {
            // 化禄、化权、化科俱在三方四正中。
            return false;
        }

        private bool 权禄巡逢格(PaiPan pan)
        {
            // 化禄、化权俱在三方四正中。
            return false;
        }

        private bool 科权禄夹格(PaiPan pan)
        {
            // 化禄、化权、化科有二星在左右邻宫相夹。
            return false;
        }

        private bool 甲第登科格(PaiPan pan)
        {
            // 化科在命宫，化权在三方四正会照。
            return false;
        }

        private bool 科名会禄格(PaiPan pan)
        {
            // 化科在命宫，化禄在三方四正会照。
            return false;
        }

        private bool 坐贵向贵格(PaiPan pan)
        {
            // 如坐命天魁且逢或天钺来加会，或坐命天钺，且逢天魁来加会。
            return false;
        }

        private bool 天乙拱命格(PaiPan pan)
        {
            // 天魁，天钺俱在三方四正中。
            return false;
        }

        private bool 火羊格(PaiPan pan)
        {
            // 在三方四正中，四煞只有火星及擎羊，才入格。
            return false;
        }

        private bool 铃陀格(PaiPan pan)
        {
            // 在三方四正中，四煞只有铃星及陀罗，才入格。
            return false;
        }

        private bool 擎羊入庙格(PaiPan pan)
        {
            // 擎羊坐命于丑辰未戌，为本格。
            return false;
        }

        private bool 马头带剑格(PaiPan pan)
        {
            // 擎羊坐命午宫，为本格。
            return false;
        }

        private bool 极居卯酉格(PaiPan pan)
        {
            // 紫薇，贪狼同在卯或酉坐命。
            return false;
        }

        private bool 巨机化酉格(PaiPan pan)
        {
            // 巨门、天机同在酉宫坐命，有化忌同宫。
            return false;
        }

        private bool 日月反背格(PaiPan pan)
        {
            // 太阳在戌宫坐命，此时太阴在辰宫；或太阴在辰宫坐命，太阳在戌宫。
            return false;
        }

        private bool 梁马飘荡格(PaiPan pan)
        {
            // 天梁在巳亥寅申宫坐命，与天马同宫。
            return false;
        }

        private bool 贞杀同宫格(PaiPan pan)
        {
            // 廉贞、七杀同在同在丑或未宫守命。
            return false;
        }

        private bool 刑囚印格(PaiPan pan)
        {
            // 廉贞、天相在子或午宫坐命，有擎羊同宫。
            return false;
        }

        private bool 巨逢四煞格(PaiPan pan)
        {
            // 巨门守命，且在三方四正中，与羊陀火铃四煞同时有会照或同宫关系。
            return false;
        }

        private bool 命无正曜格(PaiPan pan)
        {
            // 命宫里无任何十四颗主星坐命。
            return false;
        }

        private bool 命里逢空格(PaiPan pan)
        {
            // 地劫、地空二星或其中之一星守命。
            return false;
        }

        private bool 空劫夹命格(PaiPan pan)
        {
            // 地劫、地空二星在左右邻宫夹命。
            return false;
        }

        private bool 文星遇夹格(PaiPan pan)
        {
            // 文昌或文曲守命，遇空劫或火铃或羊陀对星来夹。
            return false;
        }

        private bool 羊陀夹忌格(PaiPan pan)
        {
            // 化忌坐命，擎羊、陀罗于两邻宫相夹。
            return false;
        }

        private bool 羊陀夹命格(PaiPan pan)
        {
            // 擎羊、陀罗于两邻宫相夹。
            return false;
        }

        private bool 火铃夹命格(PaiPan pan)
        {
            // 火星、铃星在左右邻宫相夹命宫，即为此格。
            return false;
        }

        private bool 刑忌夹印格(PaiPan pan)
        {
            // 天相受化忌和天梁于左右邻宫相夹；或天相受化忌和擎羊于左右邻宫相夹。
            return false;
        }

        private bool 马落空亡格(PaiPan pan)
        {
            // 天马遇地劫、地空同宫或三方冲照。
            return false;
        }

        private bool 两重华盖格(PaiPan pan)
        {
            // 禄存、化禄同时坐命，遇地劫、地空同宫。
            return false;
        }

        private bool 禄逢冲破格(PaiPan pan)
        {
            // 禄存或化禄坐命，在三方四正中，有被地劫、地空冲破。
            return false;
        }

        private bool 泛水桃花格(PaiPan pan)
        {
            // 贪狼坐命在子宫。廉贞，贪狼坐命于亥宫，遇陀罗同宫。
            return false;
        }

        private bool 风流彩杖格(PaiPan pan)
        {
            // 在寅宫，贪狼坐命，遇陀罗同宫。
            return false;
        }

        private void initFuncsTable()
        {
            gejuFuncs = new GeJuName[72]
            {
                极向离明格,
                君臣庆会格,
                紫府同宫格,
                紫府朝垣格,
                巨机同宫格,
                善荫朝纲格,
                机月同梁格,
                日丽中天格,
                日照雷门格,
                日月同宫格,
                日月并明格,
                明珠出海格,
                巨日同宫格,
                阳梁昌禄格,
                贪武同行格,
                将星得地格,
                财禄夹马格,
                廉贞文武格,
                财荫夹印格,
                雄宿朝垣格,
                府相朝垣格,
                月朗天门格,
                月生沧海格,
                三合火铃贪格,
                三合火贪格,
                三合铃贪格,
                石中隐玉格,
                禄马配印格,
                禄马交驰格,
                寿星入庙格,
                七杀朝斗格,
                英星入庙格,
                文桂文华格,
                文星拱命格,
                紫府夹命格,
                日月夹命格,
                左右夹命格,
                昌曲夹命格,
                左右同宫格,
                辅拱文星格,
                双禄朝垣格,
                三奇嘉会格,
                权禄巡逢格,
                科权禄夹格,
                甲第登科格,
                科名会禄格,
                坐贵向贵格,
                天乙拱命格,
                火羊格,
                铃陀格,
                擎羊入庙格,
                马头带剑格,
                极居卯酉格,
                巨机化酉格,
                日月反背格,
                梁马飘荡格,
                贞杀同宫格,
                刑囚印格,
                巨逢四煞格,
                命无正曜格,
                命里逢空格,
                空劫夹命格,
                文星遇夹格,
                羊陀夹忌格,
                羊陀夹命格,
                火铃夹命格,
                刑忌夹印格,
                马落空亡格,
                两重华盖格,
                禄逢冲破格,
                泛水桃花格,
                风流彩杖格
            };
        }

        
    }
}
