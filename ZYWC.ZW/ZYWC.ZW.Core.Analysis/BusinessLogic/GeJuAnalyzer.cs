using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class GeJuAnalyzer
    {
        private delegate string GeJuName(PaiPan pan);
        private DAL dal = null;
        public GeJuAnalyzer(DAL dal)
        {
            this.dal = dal;
        }

        public IList<s26_minggonggeju> GeJuFromPaiPan(PaiPan pan)
        {
            var rets = new List<s26_minggonggeju>();

            CheckGeJu(pan, rets, 极向离明格);
            CheckGeJu(pan, rets, 君臣庆会格);
            CheckGeJu(pan, rets, 紫府同宫格);
            CheckGeJu(pan, rets, 紫府朝垣格);
            CheckGeJu(pan, rets, 巨机同宫格);
            CheckGeJu(pan, rets, 善荫朝纲格);
            CheckGeJu(pan, rets, 机月同梁格);
            CheckGeJu(pan, rets, 日丽中天格);
            CheckGeJu(pan, rets, 日照雷门格);
            CheckGeJu(pan, rets, 日月同宫格);
            CheckGeJu(pan, rets, 日月并明格);
            CheckGeJu(pan, rets, 明珠出海格);
            CheckGeJu(pan, rets, 巨日同宫格);
            CheckGeJu(pan, rets, 阳梁昌禄格);
            CheckGeJu(pan, rets, 贪武同行格);
            CheckGeJu(pan, rets, 将星得地格);
            CheckGeJu(pan, rets, 财禄夹马格);
            CheckGeJu(pan, rets, 廉贞文武格);
            CheckGeJu(pan, rets, 财荫夹印格);
            CheckGeJu(pan, rets, 雄宿朝垣格);
            CheckGeJu(pan, rets, 府相朝垣格);
            CheckGeJu(pan, rets, 月朗天门格);
            CheckGeJu(pan, rets, 月生沧海格);
            CheckGeJu(pan, rets, 三合火铃贪格);
            CheckGeJu(pan, rets, 三合火贪格);
            CheckGeJu(pan, rets, 三合铃贪格);
            CheckGeJu(pan, rets, 石中隐玉格);
            CheckGeJu(pan, rets, 禄马配印格);
            CheckGeJu(pan, rets, 禄马交驰格);
            CheckGeJu(pan, rets, 寿星入庙格);
            CheckGeJu(pan, rets, 七杀朝斗格);
            CheckGeJu(pan, rets, 英星入庙格);
            CheckGeJu(pan, rets, 文桂文华格);
            CheckGeJu(pan, rets, 文星拱命格);
            CheckGeJu(pan, rets, 紫府夹命格);
            CheckGeJu(pan, rets, 日月夹命格);
            CheckGeJu(pan, rets, 左右夹命格);
            CheckGeJu(pan, rets, 昌曲夹命格);
            CheckGeJu(pan, rets, 左右同宫格);
            CheckGeJu(pan, rets, 辅拱文星格);
            CheckGeJu(pan, rets, 双禄朝垣格);
            CheckGeJu(pan, rets, 三奇嘉会格);
            CheckGeJu(pan, rets, 权禄巡逢格);
            CheckGeJu(pan, rets, 科权禄夹格);
            CheckGeJu(pan, rets, 甲第登科格);
            CheckGeJu(pan, rets, 科名会禄格);
            CheckGeJu(pan, rets, 坐贵向贵格);
            CheckGeJu(pan, rets, 天乙拱命格);
            CheckGeJu(pan, rets, 火羊格);
            CheckGeJu(pan, rets, 铃陀格);
            CheckGeJu(pan, rets, 擎羊入庙格);
            CheckGeJu(pan, rets, 马头带剑格);
            CheckGeJu(pan, rets, 极居卯酉格);
            CheckGeJu(pan, rets, 巨机化酉格);
            CheckGeJu(pan, rets, 日月反背格);
            CheckGeJu(pan, rets, 梁马飘荡格);
            CheckGeJu(pan, rets, 贞杀同宫格);
            CheckGeJu(pan, rets, 刑囚印格);
            CheckGeJu(pan, rets, 巨逢四煞格);
            CheckGeJu(pan, rets, 命无正曜格);
            CheckGeJu(pan, rets, 命里逢空格);
            CheckGeJu(pan, rets, 空劫夹命格);
            CheckGeJu(pan, rets, 文星遇夹格);
            CheckGeJu(pan, rets, 羊陀夹忌格);
            CheckGeJu(pan, rets, 羊陀夹命格);
            CheckGeJu(pan, rets, 火铃夹命格);
            CheckGeJu(pan, rets, 刑忌夹印格);
            CheckGeJu(pan, rets, 马落空亡格);
            CheckGeJu(pan, rets, 两重华盖格);
            CheckGeJu(pan, rets, 禄逢冲破格);
            CheckGeJu(pan, rets, 泛水桃花格);
            CheckGeJu(pan, rets, 风流彩杖格);

            return rets;
        }

        private void CheckGeJu(PaiPan pan, IList<s26_minggonggeju> rets, GeJuName geFunc)
        {
            var name = geFunc(pan);
            if (string.IsNullOrEmpty(name))
                return;

            var ge = dal.s26.FirstOrDefault(g => g.gejuname == name);
            if(ge != null)
                rets.Add(ge);
        }

        private static string 极向离明格(PaiPan pan)
        {
            // 紫薇在午宫坐命
            var gong = pan.Gongs.First(g => g.ZhiString == "午");        // 午宫
            var star = gong.Stars.FirstOrDefault(s => s.Name == "紫薇");  
            if (star != null && gong.Is_Ming)                            // 紫薇 坐命
                return "极向离明格";
            return null;
        }

        private static string 君臣庆会格(PaiPan pan)
        {
            // 命宫有紫微星，且于三方四正中有 至少有左辅、右弼任何一星加会或同宫，或两星于两临宫相夹。
            return "君臣庆会格";
        }

        private static string 紫府同宫格(PaiPan pan)
        {
            // 安命在寅或申宫，紫薇天府同宫。
            return "紫府同宫格";
        }

        private static string 紫府朝垣格(PaiPan pan)
        {
            // 紫薇、天府于三方四正照命。
            return "紫府朝垣格";
        }

        private static string 巨机同宫格(PaiPan pan)
        {
            // 巨门、天机二星在卯宫或酉宫坐命，且无化忌同宫。
            return "巨机同宫格";
        }

        private static string 善荫朝纲格(PaiPan pan)
        {
            // 天机、天梁二星同时在辰或戌宫守命，为此格。
            return "善荫朝纲格";
        }

        private static string 机月同梁格(PaiPan pan)
        {
            // 于三方四正中有天机、太阴、天同、天梁四星交会。
            return "机月同梁格";
        }

        private static string 日丽中天格(PaiPan pan)
        {
            // 太阳在午宫坐命。
            return "日丽中天格";
        }

        private static string 日照雷门格(PaiPan pan)
        {
            // 太阳在卯宫坐命。         日出扶桑格
            return "日照雷门格";
        }

        private static string 日月同宫格(PaiPan pan)
        {
            // 命宫在丑或未，日月二星坐守。
            return "日月同宫格";
        }

        private static string 日月并明格(PaiPan pan)
        {
            // 日月位于三方四正中，且太阳在巳，太阴在酉或太阳在辰，太阴在戌，为本格。
            return "日月并明格";
        }

        private static string 明珠出海格(PaiPan pan)
        {
            // 本宫在未宫，无主星坐命，且太阳在卯宫，太阴在亥宫。此时日月于三方四正中照命。
            return "明珠出海格";
        }

        private static string 巨日同宫格(PaiPan pan)
        {
            // 巨门太阳同时在寅或申宫坐命。
            return "巨日同宫格";
        }

        private static string 阳梁昌禄格(PaiPan pan)
        {
            // 三方四正会齐了太阳、天梁、文昌、禄存四星。
            return "阳梁昌禄格";
        }

        private static string 贪武同行格(PaiPan pan)
        {
            // 命宫在丑或未，武曲、贪狼二星坐守。
            return "贪武同行格";
        }

        private static string 将星得地格(PaiPan pan)
        {
            // 武曲坐命在辰或戌宫。
            return "将星得地格";
        }

        private static string 财禄夹马格(PaiPan pan)
        {
            // 天马守命宫，二左右临宫有武曲与化禄来夹，或为武曲与禄存来夹。
            return "财禄夹马格";
        }

        private static string 廉贞文武格(PaiPan pan)
        {
            // 廉贞坐命，官禄宫为武曲来会，三方四正再会文昌或文曲。
            return "廉贞文武格";
        }

        private static string 财荫夹印格(PaiPan pan)
        {
            // 天相受化禄和天梁在左右临宫相夹。
            return "财荫夹印格";
        }

        private static string 雄宿朝垣格(PaiPan pan)
        {
            // 廉贞在申或寅宫守命。
            return "雄宿朝垣格";
        }

        private static string 府相朝垣格(PaiPan pan)
        {
            // 天府、天相于三方四正照命。
            return "府相朝垣格";
        }

        private static string 月朗天门格(PaiPan pan)
        {
            // 太阴在亥宫守命，为本格。
            return "月朗天门格";
        }

        private static string 月生沧海格(PaiPan pan)
        {
            // 太阴，天同星在子宫坐命。
            return "月生沧海格";
        }

        private static string 三合火铃贪格(PaiPan pan)
        {
            // 贪狼守命，遇火星、铃星俱在命或三方会照。
            return "三合火铃贪格";
        }

        private static string 三合火贪格(PaiPan pan)
        {
            // 贪狼守命，遇火星在命或三方会照。
            return "三合火贪格";
        }

        private static string 三合铃贪格(PaiPan pan)
        {
            // 贪狼守命，遇铃星在命或三方会照。
            return "三合铃贪格";
        }

        private static string 石中隐玉格(PaiPan pan)
        {
            // 巨门在子或午宫坐命。
            return "石中隐玉格";
        }

        private static string 禄马配印格(PaiPan pan)
        {
            // 禄存、天马、天相同宫守命。或为化禄，天马，天相同宫守命。
            return "禄马配印格";
        }

        private static string 禄马交驰格(PaiPan pan)
        {
            // 命宫或三方有禄存、天马或化禄、天马。
            return "禄马交驰格";
        }

        private static string 寿星入庙格(PaiPan pan)
        {
            // 天梁守命，入午宫。
            return "寿星入庙格";
        }

        private static string 七杀朝斗格(PaiPan pan)
        {
            // 七杀于子或午或寅或申宫守命。
            return "七杀朝斗格";
        }

        private static string 英星入庙格(PaiPan pan)
        {
            // 破申守命居子或午宫。
            return "英星入庙格";
        }

        private static string 文桂文华格(PaiPan pan)
        {
            // 文昌、文曲两星在丑或未宫守命。
            return "文桂文华格";
        }

        private static string 文星拱命格(PaiPan pan)
        {
            // 文昌、文曲两星俱在三方四正中。
            return "文星拱命格";
        }

        private static string 紫府夹命格(PaiPan pan)
        {
            // 命宫在寅或申宫，与紫薇与天府来夹。
            return "紫府夹命格";
        }

        private static string 日月夹命格(PaiPan pan)
        {
            // 命宫在丑或未宫，太阳与太阴在左右邻宫相夹。
            return "日月夹命格";
        }

        private static string 左右夹命格(PaiPan pan)
        {
            // 命宫在丑或未宫，左辅与右弼在左右邻宫相夹。
            return "左右夹命格";
        }

        private static string 昌曲夹命格(PaiPan pan)
        {
            // 命宫在丑或未宫，文昌与文曲在左右邻宫相夹。
            return "昌曲夹命格";
        }

        private static string 左右同宫格(PaiPan pan)
        {
            // 命宫在丑或未宫，左辅右弼同宫，为本格。
            return "左右同宫格";
        }

        private static string 辅拱文星格(PaiPan pan)
        {
            // 文昌、文曲在命宫，有辅弼两星在三方四正拱照或左右邻宫相夹。
            return "辅拱文星格";
        }

        private static string 双禄朝垣格(PaiPan pan)
        {
            // 禄存和化禄俱在三方四正中。
            return "双禄朝垣格";
        }

        private static string 三奇嘉会格(PaiPan pan)
        {
            // 化禄、化权、化科俱在三方四正中。
            return "三奇嘉会格";
        }

        private static string 权禄巡逢格(PaiPan pan)
        {
            // 化禄、化权俱在三方四正中。
            return "权禄巡逢格";
        }

        private static string 科权禄夹格(PaiPan pan)
        {
            // 化禄、化权、化科有二星在左右邻宫相夹。
            return "科权禄夹格";
        }

        private static string 甲第登科格(PaiPan pan)
        {
            // 化科在命宫，化权在三方四正会照。
            return "甲第登科格";
        }

        private static string 科名会禄格(PaiPan pan)
        {
            // 化科在命宫，化禄在三方四正会照。
            return "科名会禄格";
        }

        private static string 坐贵向贵格(PaiPan pan)
        {
            // 如坐命天魁且逢或天钺来加会，或坐命天钺，且逢天魁来加会。
            return "坐贵向贵格";
        }

        private static string 天乙拱命格(PaiPan pan)
        {
            // 天魁，天钺俱在三方四正中。
            return "天乙拱命格";
        }

        private static string 火羊格(PaiPan pan)
        {
            // 在三方四正中，四煞只有火星及擎羊，才入格。
            return "火羊格";
        }

        private static string 铃陀格(PaiPan pan)
        {
            // 在三方四正中，四煞只有铃星及陀罗，才入格。
            return "铃陀格";
        }

        private static string 擎羊入庙格(PaiPan pan)
        {
            // 擎羊坐命于丑辰未戌，为本格。
            return "擎羊入庙格";
        }

        private static string 马头带剑格(PaiPan pan)
        {
            // 擎羊坐命午宫，为本格。
            return "马头带剑格";
        }

        private static string 极居卯酉格(PaiPan pan)
        {
            // 紫薇，贪狼同在卯或酉坐命。
            return "极居卯酉格";
        }

        private static string 巨机化酉格(PaiPan pan)
        {
            // 巨门、天机同在酉宫坐命，有化忌同宫。
            return "巨机化酉格";
        }

        private static string 日月反背格(PaiPan pan)
        {
            // 太阳在戌宫坐命，此时太阴在辰宫；或太阴在辰宫坐命，太阳在戌宫。
            return "日月反背格";
        }

        private static string 梁马飘荡格(PaiPan pan)
        {
            // 天梁在巳亥寅申宫坐命，与天马同宫。
            return "梁马飘荡格";
        }

        private static string 贞杀同宫格(PaiPan pan)
        {
            // 廉贞、七杀同在同在丑或未宫守命。
            return "贞杀同宫格";
        }

        private static string 刑囚印格(PaiPan pan)
        {
            // 廉贞、天相在子或午宫坐命，有擎羊同宫。
            return "刑囚印格";
        }

        private static string 巨逢四煞格(PaiPan pan)
        {
            // 巨门守命，且在三方四正中，与羊陀火铃四煞同时有会照或同宫关系。
            return "巨逢四煞格";
        }

        private static string 命无正曜格(PaiPan pan)
        {
            // 命宫里无任何十四颗主星坐命。
            return "命无正曜格";
        }

        private static string 命里逢空格(PaiPan pan)
        {
            // 地劫、地空二星或其中之一星守命。
            return "命里逢空格";
        }

        private static string 空劫夹命格(PaiPan pan)
        {
            // 地劫、地空二星在左右邻宫夹命。
            return "空劫夹命格";
        }

        private static string 文星遇夹格(PaiPan pan)
        {
            // 文昌或文曲守命，遇空劫或火铃或羊陀对星来夹。
            return "文星遇夹格";
        }

        private static string 羊陀夹忌格(PaiPan pan)
        {
            // 化忌坐命，擎羊、陀罗于两邻宫相夹。
            return "羊陀夹忌格";
        }

        private static string 羊陀夹命格(PaiPan pan)
        {
            // 擎羊、陀罗于两邻宫相夹。
            return "羊陀夹命格";
        }

        private static string 火铃夹命格(PaiPan pan)
        {
            // 火星、铃星在左右邻宫相夹命宫，即为此格。
            return "火铃夹命格";
        }

        private static string 刑忌夹印格(PaiPan pan)
        {
            // 天相受化忌和天梁于左右邻宫相夹；或天相受化忌和擎羊于左右邻宫相夹。
            return "刑忌夹印格";
        }

        private static string 马落空亡格(PaiPan pan)
        {
            // 天马遇地劫、地空同宫或三方冲照。
            return "马落空亡格";
        }

        private static string 两重华盖格(PaiPan pan)
        {
            // 禄存、化禄同时坐命，遇地劫、地空同宫。
            return "两重华盖格";
        }

        private static string 禄逢冲破格(PaiPan pan)
        {
            // 禄存或化禄坐命，在三方四正中，有被地劫、地空冲破。
            return "禄逢冲破格";
        }

        private static string 泛水桃花格(PaiPan pan)
        {
            // 贪狼坐命在子宫。廉贞，贪狼坐命于亥宫，遇陀罗同宫。
            return "泛水桃花格";
        }

        private static string 风流彩杖格(PaiPan pan)
        {
            // 在寅宫，贪狼坐命，遇陀罗同宫。
            return "风流彩杖格";
        }            
    }
}
