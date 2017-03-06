using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class DaShisWords
    {

        public DaShi GetDaShi(BasicGong gong, DAL dal)
        {
            DaShi result = new DaShi();

            if (gong.Name == GongIndex.命宫)
            {
                string id = gong.ZhuXing[0].Id.ToString();

                result.MingZhongTeDian = dal.s24.Find(s => s.id == gong.ZhuXing[0].Id.ToString()).items[gong.SelfGong.Zhi - 1].text;

                if (gong.ZhuXing.Count == 2)
                {

                    result.MingZhongTeDian += "\n";
                    result.MingZhongTeDian += dal.s24.Find(s => s.id == gong.ZhuXing[1].Id.ToString()).items[gong.SelfGong.Zhi - 1].text;
                    id += ("#" + gong.ZhuXing[1].Id.ToString());
                }

                result.JianYi = dal.s25.Find(s => s.id == id).text;
            }
            else
            {
                var data = GetData(gong.Name, dal);
                result.MingZhongTeDian = data.Find(d => d.id == gong.ZhuXing[0].Id.ToString()).dizhis[gong.SelfGong.Zhi - 1].contents[0].text;

                result.JianYi = GetJianYi(gong.Name);
            }

            return result;
        }

        private ziwei_data_s31 GetData(GongIndex index, DAL dal)
        {
            switch (index)
            {
                case GongIndex.兄弟宫:
                    return dal.s31;
                case GongIndex.夫妻宫:
                    return dal.s32;
                case GongIndex.子女宫:
                    return dal.s33;
                case GongIndex.财帛宫:
                    return dal.s34;
                case GongIndex.疾厄宫:
                    return dal.s35;
                case GongIndex.迁移宫:
                    return dal.s36;
                case GongIndex.仆役宫:
                    return dal.s37;
                case GongIndex.事业宫:
                    return dal.s38;
                case GongIndex.田宅宫:
                    return dal.s39;
                case GongIndex.福德宫:
                    return dal.s40;
                case GongIndex.父母宫:
                    return dal.s41;
                default:
                    return null;
            }
        }

        private string GetJianYi(GongIndex index)
        {
            switch (index)
            {
                case GongIndex.兄弟宫:
                    return "亲情无价，能成为兄弟姊妹需要无限的缘分。所以，当兄弟姊妹遇到困难时，如果您是有能力，请伸出援手吧。";
                case GongIndex.夫妻宫:
                    return "夫妻生活是门学问，需要夫妻双方努力去维系，和谐的夫妻生活关键是知进退，多关心谅解对方，迎合伴侣的感情态度可以有效加强婚姻美满度。婚姻感情需要需要清楚自身的爱情态度，找出自己在感情方面的不足之处，选择真正适合自己的对象，可以查看自身的婚姻感情分析。想要知道伴侣的感情态度就需要结合伴侣的命理信息来分析";
                case GongIndex.子女宫:
                    return "“养儿一百岁，长忧九十九。”关注自己子女成长是每个父母的责任，但您的教育方式是否真适合自己子女呢？建议可以从子女性格方面下手，针对他们的性格进行教育，这样可以事半功倍。";
                case GongIndex.财帛宫:
                    return "财富的好坏虽然命中有定数，但缺乏行动努力一切都变得不现实。但命中财运不好怎么办？就需要看流年的运程，运势不好的年份需要走得慢一点，稳中求胜；运势好的年运可以加快步伐，挑战各种机遇。至于无法留下贮蓄怎么办？自己没法留可以交给其它人帮忙保管，像爸妈、婚姻伴侣都可以，又或者把生活必须外的钱在银行设个定期存款，减低流动性。";
                case GongIndex.疾厄宫:
                    return "需要关注自身健康情况，注意保养容易患病的部分，每年的身体检查肯定是必不可少的。预防胜于治疗，注意好自己的作息时间和饮食习惯，有时间再做适量的运动，保持健康其实很容易。";
                case GongIndex.仆役宫:
                    return "生活中无法避免认识朋友、同事、上司，想要和他们和谐相处应该针对他们的性格下手，了解他们的性格特点，投其所好，这有助于人际交往发展。";
                case GongIndex.事业宫:
                    return "事业成就高低和努力是密不可分，但并不意味着您努力了就可以有收获，关键是努力的方向需要正确的。所以您需要选择适合自己的事业和方向发展，这可以令您更容易发挥自身能力，获得成功。";
                case GongIndex.父母宫:
                    return "“养儿一百岁，长忧九十九。”同样的道理，没有父母是不关系自己的子女的，对于父母您需要给予更多的关爱。年老容易滋生孤独感觉，陪父母聚餐聊天是个不错的做法，当然离乡发展的朋友可以电话关心一下，给爸妈报个平安。您也可以帮父母建档测算一下，看看每年有哪些方面是需要特别注意的，避免引发严重的问题。";
                default:
                    return string.Empty;
            }
        }
    }



}
