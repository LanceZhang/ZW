using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYWC.ZW.Core
{
    public class PaiPan
    {
        #region 基础数据

        private static string ganStr = "甲乙丙丁戊己庚辛壬癸";
        private static string[] _gongName = { "命  宫", "父母宫", "福德宫", "田宅宫", "官禄宫", "仆役宫", "迁移宫", "疾厄宫", "财帛宫", "子女宫", "夫妻宫", "兄弟宫" }; //从命宫顺排
        private static string[] _wuXingJu = { "木三局", "金四局", "水二局", "火六局", "土五局" };
        private static int[] _wuXingJuNum = { 3, 4, 2, 6, 5 };
        private static int[] _wuXingChangsheng = { 12, 6, 3, 9, 9 };

        private static Dictionary<string, int[]> _liangdu = new Dictionary<string, int[]>();
        private static Dictionary<string, string> _yuexizhuxing = new Dictionary<string, string>();
        private static Dictionary<string, string> _nianxizhuxing = new Dictionary<string, string>();
        private static Dictionary<string, string> _shixizhuxing = new Dictionary<string, string>();
        private static Dictionary<string, string> _nianganxizhuxing = new Dictionary<string, string>();
        private static Dictionary<string, string> _huoxing = new Dictionary<string, string>();
        private static Dictionary<string, string> _lingxing = new Dictionary<string, string>();
        private static Dictionary<string, string> _jiangqian12 = new Dictionary<string, string>();
        private static Dictionary<string, string> _suiqian12 = new Dictionary<string, string>();
        private static Dictionary<string, string> _xunkongxing = new Dictionary<string, string>();

        private static Dictionary<string, int> _xiaoxian = new Dictionary<string, int>();

        private static Dictionary<string, string[]> _mingshenzhuxing = new Dictionary<string, string[]>();
        private static Dictionary<string, string[]> _sihuaxing = new Dictionary<string, string[]>();


        private static string[] _boshi12 = { "博士", "力士", "青龙", "小耗", "将军", "奏书", "飞廉", "喜神", "病符", "大耗", "伏兵", "官符" }; //禄存星所在宫打头，阳男阴女顺行，阴男阳女逆行
        private static string[] _changsheng12 = { "长生", "沐浴", "冠带", "临官", "帝旺", "衰", "病", "死", "墓", "绝", "胎", "养" }; //由五行局确定

        #endregion

        #region 内部变量

        private Gong[] _xingGong = {
                                   new Gong(1)
                                   ,new Gong(2)
                                   ,new Gong(3)
                                   ,new Gong(4)
                                   ,new Gong(5)
                                   ,new Gong(6)
                                   ,new Gong(7)
                                   ,new Gong(8)
                                   ,new Gong(9)
                                   ,new Gong(10)
                                   ,new Gong(11)
                                   ,new Gong(12)
                                   };  //12宫位 对应地支


        private ChineseCalendar calendar;

        private ChineseCalendar liu_calendar;

        #endregion

        #region 属性

        public string 五行局
        {
            get
            {
                int gan = (命宫.干 + 1) / 2;

                int zhi = 命宫.支 % 6;
                if (zhi == 0)
                    zhi = 6;
                zhi = (zhi + 1) / 2;

                int index = (gan + zhi) % 5;
                if (index == 0)
                    index = 5;

                return _wuXingJu[index - 1];
            }
        }

        public Gong 命宫
        {
            get
            {
                return this._xingGong.First(g => g.is_命);
            }
        }

        public string 命主
        {
            get { return _mingshenzhuxing["命主"][命宫.支 - 1]; }
        }

        public string 身主
        {
            get { return _mingshenzhuxing["身主"][this.calendar.BaziIndex[1]]; }
        }

        #endregion

        #region 构造函数


        static PaiPan()
        {
            _liangdu.Add("紫微", new int[] { -1, 3, 3, 2, 1, 2, 3, 3, 2, 2, 1, 2 });
            _liangdu.Add("天机", new int[] { 3, -3, 1, 2, 0, -1, 3, -3, 1, 2, 0, -1 });
            _liangdu.Add("太阳", new int[] { -3, -2, 2, 3, 2, 2, 3, 1, 0, -1, -3, -3 });
            _liangdu.Add("武曲", new int[] { 2, 3, 1, 0, 3, -1, 2, 3, 1, 0, 3, -1 });
            _liangdu.Add("天同", new int[] { 2, -2, 0, 3, -1, 3, -3, -2, 2, -1, -1, 3 });
            _liangdu.Add("廉贞", new int[] { -1, 0, 3, -1, 0, -3, -1, 0, 3, -1, 0, -3 });
            _liangdu.Add("天府", new int[] { 3, 3, 3, 1, 2, 1, 2, 3, 1, 2, 2, 1 });
            _liangdu.Add("太阴", new int[] { 3, 3, -2, -3, -3, -3, -3, -3, 0, 2, 2, 3 });
            _liangdu.Add("贪狼", new int[] { 2, 3, -1, 1, 3, -3, 2, 3, -1, 0, 3, -3 });
            _liangdu.Add("巨门", new int[] { 2, -2, 3, 3, -1, -1, 2, -1, 3, 3, -1, 2 });
            _liangdu.Add("天相", new int[] { 3, 3, 3, -3, -1, 1, 1, 1, 3, -3, 1, 1 });
            _liangdu.Add("天梁", new int[] { 3, 2, 3, 2, 3, -3, 3, 2, -3, 1, 3, -3 });
            _liangdu.Add("七杀", new int[] { 2, 3, 3, 2, 1, -1, 2, 3, 3, 2, 3, -1 });
            _liangdu.Add("破军", new int[] { 3, 2, 1, -3, 2, -1, 3, 2, 1, -3, 2, -1 });
            _liangdu.Add("火星", new int[] { -3, 1, 3, 0, -3, 1, 3, 0, -3, 1, 3, 0 });
            _liangdu.Add("铃星", new int[] { -3, 1, 3, 0, -3, 1, 3, 0, -3, 1, 3, 0 });
            _liangdu.Add("擎羊", new int[] { 2, 3, 0, -3, 3, 0, -3, 3, 0, 2, 3, });
            _liangdu.Add("陀罗", new int[] { 0, 3, -3, 0, 3, -3, 0, 3, -3, 0, 3, -3 });
            _liangdu.Add("文昌", new int[] { 1, 3, -3, 2, 1, 3, -3, 0, 1, 3, -3, 0 });
            _liangdu.Add("文曲", new int[] { 1, 3, -1, 2, 1, 3, -3, 2, 1, 3, -3, 2 });


            _yuexizhuxing.Add("左辅", "辰巳午未申酉戌亥子丑寅卯");
            _yuexizhuxing.Add("右弼", "戌酉申未午巳辰卯寅丑子亥");
            _yuexizhuxing.Add("阴煞", "寅子戌申午辰寅子戌申午辰");
            _yuexizhuxing.Add("天刑", "酉戌亥子丑寅卯辰巳午未申");
            _yuexizhuxing.Add("天姚", "丑寅卯辰巳午未申酉戌亥子");
            _yuexizhuxing.Add("天月", "戌巳辰寅未卯亥未寅午戌寅");
            _yuexizhuxing.Add("天巫", "巳申亥寅巳申亥寅巳申亥寅");


            _nianxizhuxing.Add("天喜", "酉申未午巳辰卯寅丑子亥戌");
            _nianxizhuxing.Add("天虚", "午未申酉戌亥子丑寅卯辰巳");
            _nianxizhuxing.Add("天哭", "午巳辰卯寅丑子亥戌酉申未");
            _nianxizhuxing.Add("天德", "酉戌亥子丑寅卯辰巳午未申");
            _nianxizhuxing.Add("红鸾", "卯寅丑子亥戌酉申未午巳辰");
            _nianxizhuxing.Add("龙池", "辰巳午未申酉戌亥子丑寅卯");
            _nianxizhuxing.Add("凤阁", "戌酉申未午巳辰卯寅丑子亥");
            _nianxizhuxing.Add("孤辰", "寅寅巳巳巳申申申亥亥亥寅");
            _nianxizhuxing.Add("寡宿", "戌戌丑丑丑辰辰辰未未未戌");
            _nianxizhuxing.Add("破碎", "巳丑酉巳丑酉巳丑酉巳丑酉");
            _nianxizhuxing.Add("大耗", "未午酉申亥戌丑子卯寅巳辰");//chong
            _nianxizhuxing.Add("华盖", "辰丑戌未辰丑戌未辰丑戌未");
            _nianxizhuxing.Add("解神", "戌酉申未午巳辰卯寅丑子亥");//?
            _nianxizhuxing.Add("咸池", "酉午卯子酉午卯子酉午卯子");
            _nianxizhuxing.Add("劫杀", "巳寅亥申巳寅亥申巳寅亥申");//wu
            _nianxizhuxing.Add("天马", "寅亥申巳寅亥申巳寅亥申巳");//?
            _nianxizhuxing.Add("蜚廉", "申酉戌巳午未寅卯辰亥子丑");

            _shixizhuxing.Add("文昌", "戌酉申未午巳辰卯寅丑子亥");
            _shixizhuxing.Add("文曲", "辰巳午未申酉戌亥子丑寅卯");
            _shixizhuxing.Add("天空", "亥戌酉申未午巳辰卯寅丑子");
            _shixizhuxing.Add("地劫", "亥子丑寅卯辰巳午未申酉戌");
            _shixizhuxing.Add("台辅", "午未申酉戌亥子丑寅卯辰巳");
            _shixizhuxing.Add("封诰", "寅卯辰巳午未申酉戌亥子丑");

            _nianganxizhuxing.Add("擎羊", "卯辰午未午未酉戌子丑");
            _nianganxizhuxing.Add("陀罗", "丑寅辰巳辰巳未申戌亥");
            _nianganxizhuxing.Add("天钺", "未申酉酉未申未寅巳巳");
            _nianganxizhuxing.Add("天魁", "丑子亥亥丑子丑午卯卯");
            _nianganxizhuxing.Add("禄存", "寅卯巳午巳午申酉亥子");
            _nianganxizhuxing.Add("天福", "酉申子亥卯寅午巳午巳");
            _nianganxizhuxing.Add("天官", "未辰巳寅卯酉亥酉戌午");
            _nianganxizhuxing.Add("正空", "申未辰卯子酉午巳寅丑");//?
            _nianganxizhuxing.Add("副空", "酉午巳寅丑申未辰卯子");//?

            _mingshenzhuxing.Add("命主", new string[] { "贪狼", "巨门", "禄存", "文曲", "廉贞", "武曲", "破军", "武曲", "廉贞", "文曲", "禄存", "巨门" });
            _mingshenzhuxing.Add("身主", new string[] { "铃星", "天相", "天梁", "天同", "文昌", "天机", "火星", "天相", "天梁", "天同", "文昌", "天机" });

            _sihuaxing.Add("禄", new string[] { "廉贞", "天机", "天同", "太阴", "贪狼", "武曲", "太阳", "巨门", "天梁", "破军" });
            _sihuaxing.Add("权", new string[] { "破军", "天梁", "天机", "天同", "太阴", "贪狼", "武曲", "太阳", "紫微", "巨门" });
            _sihuaxing.Add("科", new string[] { "武曲", "紫微", "文昌", "天机", "右弼", "天梁", "太阴", "文曲", "左辅", "太阴" });
            _sihuaxing.Add("忌", new string[] { "太阳", "太阴", "廉贞", "巨门", "天机", "文曲", "天同", "文昌", "武曲", "贪狼" });

            _huoxing.Add("寅午戌", "丑寅卯辰巳午未申酉戌亥子");
            _huoxing.Add("申子辰", "寅卯辰巳午未申酉戌亥子丑");
            _huoxing.Add("巳酉丑", "卯辰巳午未申酉戌亥子丑寅");
            _huoxing.Add("亥卯未", "酉戌亥子丑寅卯辰巳午未申");

            _lingxing.Add("寅午戌", "卯辰巳午未申酉戌亥子丑寅");
            _lingxing.Add("申子辰", "戌亥子丑寅卯辰巳午未申酉");
            _lingxing.Add("巳酉丑", "戌亥子丑寅卯辰巳午未申酉");
            _lingxing.Add("亥卯未", "戌亥子丑寅卯辰巳午未申酉");

            _xiaoxian.Add("寅午戌", 5);
            _xiaoxian.Add("申子辰", 11);
            _xiaoxian.Add("巳酉丑", 8);
            _xiaoxian.Add("亥卯未", 2);

            _jiangqian12.Add("将星", "子酉午卯子酉午卯子酉午卯");
            _jiangqian12.Add("攀鞍", "丑戌未辰丑戌未辰丑戌未辰");
            _jiangqian12.Add("岁驿", "寅亥申巳寅亥申巳寅亥申巳");
            _jiangqian12.Add("息神", "卯子酉午卯子酉午卯子酉午");
            _jiangqian12.Add("华盖", "辰丑戌未辰丑戌未辰丑戌未");
            _jiangqian12.Add("劫煞", "巳寅亥申巳寅亥申巳寅亥申");
            _jiangqian12.Add("灾煞", "午卯子酉午卯子酉午卯子酉");
            _jiangqian12.Add("天煞", "未辰丑戌未辰丑戌未辰丑戌");
            _jiangqian12.Add("指背", "申巳寅亥申巳寅亥申巳寅亥");
            _jiangqian12.Add("咸池", "酉午卯子酉午卯子酉午卯子");
            _jiangqian12.Add("月煞", "戌未辰丑戌未辰丑戌未辰丑");
            _jiangqian12.Add("亡神", "亥申巳寅亥申巳寅亥申巳寅");

            _suiqian12.Add("岁建", "子丑寅卯辰巳午未申酉戌亥");
            _suiqian12.Add("晦气", "丑寅卯辰巳午未申酉戌亥子");
            _suiqian12.Add("丧门", "寅卯辰巳午未申酉戌亥子丑");
            _suiqian12.Add("贯索", "卯辰巳午未申酉戌亥子丑寅");
            _suiqian12.Add("官符", "辰巳午未申酉戌亥子丑寅卯");
            _suiqian12.Add("小耗", "巳午未申酉戌亥子丑寅卯辰");
            _suiqian12.Add("大耗", "午未申酉戌亥子丑寅卯辰巳");
            _suiqian12.Add("龙德", "未申酉戌亥子丑寅卯辰巳午");
            _suiqian12.Add("白虎", "申酉戌亥子丑寅卯辰巳午未");
            _suiqian12.Add("天德", "酉戌亥子丑寅卯辰巳午未申");
            _suiqian12.Add("吊客", "戌亥子丑寅卯辰巳午未申酉");
            _suiqian12.Add("病符", "亥子丑寅卯辰巳午未申酉戌");

            _xunkongxing.Add("戌亥", "子丑寅卯辰巳午未申酉");
            _xunkongxing.Add("申酉", "戌亥子丑寅卯辰巳午未");
            _xunkongxing.Add("午未", "申酉戌亥子丑寅卯辰巳");
            _xunkongxing.Add("辰巳", "午未申酉戌亥子丑寅卯");
            _xunkongxing.Add("寅卯", "辰巳午未申酉戌亥子丑");
            _xunkongxing.Add("子丑", "寅卯辰巳午未申酉戌亥");


        }

        public PaiPan(ChineseCalendar cal, bool sex)
        {
            #region 清空初始化

            calendar = cal;

            for (int i = 0; i < _xingGong.Length; i++)
            {
                int pre = i - 1;
                if (pre < 0)
                {
                    pre = 11;
                }

                int next = i + 1;
                if (next > 11)
                {
                    next = 0;
                }

                _xingGong[i].Previous = _xingGong[pre];
                _xingGong[i].Next = _xingGong[next];
            }

            int month = cal.ChineseMonth;
            int hour = cal.ChineseHour;

            #endregion

            //立命
            int m = 2 + (month - 1) - (hour - 1);
            if (m < 0)
                m = 12 + m;
            int 命_index = _xingGong[m].支;

            Gong gong = _xingGong[命_index - 1];
            gong.is_命 = true;
            gong.宫名 = "命  宫";


            //安12宫
            for (int i = 1; i < _gongName.Length; i++)
            {
                gong = gong.Next;
                gong.宫名 = _gongName[i];
            }


            //安身
            int n = 2 + (month - 1) + (hour - 1);
            if (n > 11)
                n = n - 12;
            int 身_index = _xingGong[n].支;
            _xingGong[身_index - 1].is_身 = true;


            //安12宫干
            int yearGan = cal.BaziIndex[0] + 1;
            int start = (yearGan % 5 * 2 + 1) - 1; //五虎遁月
            string tmpGan = ganStr.Substring(start) + ganStr.Substring(0, start + 2);//凑齐12位 

            gong = _xingGong[2];//从寅开始
            for (int i = 0; i < tmpGan.Length; i++)
            {
                gong.干Str = tmpGan[i].ToString();
                gong = gong.Next;
            }


            //定紫薇
            int jushu = _wuXingJuNum[_wuXingJu.ToList().IndexOf(五行局)];
            int shang = cal.ChineseDay / jushu;

            if (cal.ChineseDay % jushu != 0)
            {
                int bu = (shang + 1) * jushu - cal.ChineseDay;
                if (bu % 2 == 1)
                    bu = bu * -1;

                shang = shang + 1 + bu;

            }

            if (shang >= 12)
                shang = shang - 12;
            else if (shang < 0)
                shang = shang + 12;

            gong = _xingGong[shang + 1];
            gong.天星.Add(new Star("紫微", Star.StarType.主星));


            //紫薇诸星：紫微天機星逆行，隔一陽武天同行，天同隔二是廉貞
            gong = gong.Previous;
            gong.天星.Add(new Star("天机", Star.StarType.主星));

            gong = gong.Previous.Previous;
            gong.天星.Add(new Star("太阳", Star.StarType.主星));

            gong = gong.Previous;
            gong.天星.Add(new Star("武曲", Star.StarType.主星));

            gong = gong.Previous;
            gong.天星.Add(new Star("天同", Star.StarType.主星));

            gong = gong.Previous.Previous.Previous;
            gong.天星.Add(new Star("廉贞", Star.StarType.主星));


            //天府星：与紫薇以日出日落轴对称
            gong = _xingGong[shang + 1];
            int tianfu = 0;

            if (gong.支 < 6)
                tianfu = 6 - gong.支;
            else
                tianfu = 18 - gong.支;

            gong = _xingGong.First(t => t.支 == tianfu);
            gong.天星.Add(new Star("天府", Star.StarType.主星));


            //天府诸星：天府太陰順貪狼，巨門天相與天梁，七殺空三是破軍
            gong = gong.Next;
            gong.天星.Add(new Star("太阴", Star.StarType.主星));

            gong = gong.Next;
            gong.天星.Add(new Star("贪狼", Star.StarType.主星));

            gong = gong.Next;
            gong.天星.Add(new Star("巨门", Star.StarType.主星));

            gong = gong.Next;
            gong.天星.Add(new Star("天相", Star.StarType.主星));

            gong = gong.Next;
            gong.天星.Add(new Star("天梁", Star.StarType.主星));

            gong = gong.Next;
            gong.天星.Add(new Star("七杀", Star.StarType.主星));

            gong = gong.Next.Next.Next.Next;
            gong.天星.Add(new Star("破军", Star.StarType.主星));


            //安生月系诸星
            foreach (var star in _yuexizhuxing)
            {
                _xingGong.First(g => g.支Str == star.Value[month - 1].ToString()).天星.Add(new Star(star.Key, Star.StarType.月系));
            }


            //安生年支系诸星
            foreach (var star in _nianxizhuxing)
            {
                _xingGong.First(g => g.支Str == star.Value[cal.BaziIndex[1]].ToString()).天星.Add(new Star(star.Key, Star.StarType.年系));
            }


            //安时系诸星
            foreach (var star in _shixizhuxing)
            {
                _xingGong.First(g => g.支Str == star.Value[cal.BaziIndex[7]].ToString()).天星.Add(new Star(star.Key, Star.StarType.时系));
            }


            //安年干系诸星
            foreach (var star in _nianganxizhuxing)
            {
                if (star.Key == "正空") // && cal.BaziIndex[0] % 2 == 0) || (star.Key == "副空" && cal.BaziIndex[0] % 2 == 1)) //注：表中正副空亡均为截空星，天干阳性入阳宫、天干阴性入阴宫均属正空亡，凶性大；阳入阴、阴入阳均为副空，凶性小。
                {

                }
                else if (star.Key == "副空")
                {

                }
                _xingGong.First(g => g.支Str == star.Value[cal.BaziIndex[0]].ToString()).天星.Add(new Star(star.Key, Star.StarType.年干系));
            }


            //安四化
            foreach (var star in _sihuaxing)
            {
                var xg = _xingGong.First(g => g.天星.Exists(s => s.星名 == star.Value[cal.BaziIndex[0]].ToString()));
                xg.天星.Find(s => s.星名 == star.Value[cal.BaziIndex[0]].ToString()).化 = star.Key;
            }


            //安火铃
            foreach (var huo in _huoxing)
            {
                if (huo.Key.Contains(cal.BaziString[1]))
                    _xingGong.First(g => g.支Str == huo.Value[cal.BaziIndex[7]].ToString()).天星.Add(new Star("火星", Star.StarType.火铃));
            }

            foreach (var ling in _lingxing)
            {
                if (ling.Key.Contains(cal.BaziString[1]))
                    _xingGong.First(g => g.支Str == ling.Value[cal.BaziIndex[7]].ToString()).天星.Add(new Star("铃星", Star.StarType.火铃));
            }


            //安三台星
            gong = _xingGong.First(g => g.天星.Exists(s => s.星名 == "左辅"));
            int i_santai = (gong.支 + cal.ChineseDay - 2) % 12;
            _xingGong[i_santai].天星.Add(new Star("三台", Star.StarType.其它));


            //安八座星
            gong = _xingGong.First(g => g.天星.Exists(s => s.星名 == "右弼"));
            int i_bazuo = (gong.支 - cal.ChineseDay) % 12;
            if (i_bazuo < 0)
                i_bazuo += 12;
            _xingGong[i_bazuo].天星.Add(new Star("八座", Star.StarType.其它));


            //安天贵星
            gong = _xingGong.First(g => g.天星.Exists(s => s.星名 == "文曲"));
            int i_tiangui = (gong.支 + cal.ChineseDay - 2 - 1) % 12;
            if (i_tiangui < 0)
                i_tiangui += 12;
            _xingGong[i_tiangui].天星.Add(new Star("天贵", Star.StarType.其它));


            //安恩光星
            gong = _xingGong.First(g => g.天星.Exists(s => s.星名 == "文昌"));
            int i_enguang = (gong.支 + cal.ChineseDay - 2 - 1) % 12;
            if (i_enguang < 0)
                i_enguang += 12;
            _xingGong[i_enguang].天星.Add(new Star("恩光", Star.StarType.其它));


            //安天才星
            gong = _xingGong.First(g => g.is_命);
            int i_tiancai = (gong.支 + cal.BaziIndex[1] - 1) % 12;
            if (i_tiancai < 0)
                i_tiancai += 12;
            _xingGong[i_tiancai].天星.Add(new Star("天才", Star.StarType.其它));


            //安天寿星
            gong = _xingGong.First(g => g.is_身);
            int i_tianshou = (gong.支 + cal.BaziIndex[1] - 1) % 12;
            if (i_tianshou < 0)
                i_tianshou += 12;
            _xingGong[i_tianshou].天星.Add(new Star("天寿", Star.StarType.其它));


            //安天伤、天使星
            _xingGong.First(g => g.宫名 == "仆役宫").天星.Add(new Star("天伤", Star.StarType.其它));
            _xingGong.First(g => g.宫名 == "疾厄宫").天星.Add(new Star("天使", Star.StarType.其它));


            //安生年博士十二神
            gong = _xingGong.First(g => g.天星.Exists(s => s.星名 == "禄存"));
            for (int i = 0; i < _boshi12.Length; i++)
            {
                gong.天星.Add(new Star(_boshi12[i], Star.StarType.博士十二));

                if (sex == (cal.ChineseYear % 2 == 0))  //阳男阴女顺行，阴男阳女逆行
                {
                    gong = gong.Next;
                }
                else
                {
                    gong = gong.Previous;
                }
            }


            //安长生十二神
            int i_changsheng = _wuXingChangsheng[_wuXingJu.ToList().IndexOf(五行局)];
            gong = _xingGong.First(g => g.支 == i_changsheng);
            for (int i = 0; i < _changsheng12.Length; i++)
            {
                gong.天星.Add(new Star(_changsheng12[i], Star.StarType.长生十二));

                if (sex)  //男顺，女逆
                    gong = gong.Next;
                else
                    gong = gong.Previous;
            }


            //定大限
            gong = _xingGong.First(xg => xg.is_命);
            int i_daxian = _wuXingJuNum[_wuXingJu.ToList().IndexOf(五行局)] - 1;

            for (int i = 0; i < 9; i++)
            {
                gong.大限From = i_daxian + 1;
                i_daxian = i_daxian + 10;
                gong.大限To = i_daxian;

                if (sex == (cal.ChineseYear % 2 == 0))  //阳男阴女顺行，阴男阳女逆行
                    gong = gong.Next;
                else
                    gong = gong.Previous;
            }


            //起小限
            foreach (var xiao in _xiaoxian)
            {
                if (xiao.Key.Contains(cal.BaziString[1]))
                    gong = _xingGong.First(g => g.支 == xiao.Value);
            }
            for (int i = 1; i < 84; i++)
            {
                gong.小限.Add(i);

                if (sex)  //男顺，女逆
                    gong = gong.Next;
                else
                    gong = gong.Previous;
            }


            //安生年将前十二星
            foreach (var star in _jiangqian12)
            {
                _xingGong.First(g => g.支Str == star.Value[cal.BaziIndex[1]].ToString()).天星.Add(new Star(star.Key, Star.StarType.年前十二));
            }


            //安生年岁前十二星
            foreach (var star in _suiqian12)
            {
                _xingGong.First(g => g.支Str == star.Value[cal.BaziIndex[1]].ToString()).天星.Add(new Star(star.Key, Star.StarType.岁前十二));
            }


            //安生年旬空星
            foreach (var star in _xunkongxing)
            {
                if (star.Value[cal.BaziIndex[0]] == cal.BaziString[1])
                {
                    string zhi = string.Empty;

                    if (cal.ChineseYear % 2 == 0)
                        zhi = star.Key[0].ToString();
                    else
                        zhi = star.Key[1].ToString();

                    _xingGong.First(g => g.支Str == zhi).天星.Add(new Star("旬空", Star.StarType.其它));
                    break;
                }
            }


            //主星亮度
            foreach (var xg in _xingGong)
            {
                foreach (var star in xg.天星)
                {
                    if (_liangdu.ContainsKey(star.星名))
                    {
                        star.亮度 = _liangdu[star.星名][xg.支 - 1];
                    }
                }
            }

        }

        public string Test
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Format("命宫在:{0}", 命宫.支Str));
                sb.AppendLine(string.Format("身宫在:{0}", _xingGong.First(g => g.is_身).支Str));

                sb.AppendLine(string.Format("命主:{0}", 命主));
                sb.AppendLine(string.Format("身主:{0}", 身主));

                sb.AppendLine(string.Format("五行局:{0}", 五行局));

                for (int i = 0; i < _xingGong.Length; i++)
                {
                    Gong g = _xingGong[i];

                    sb.AppendLine(string.Format("{0}在：{1}\t干为：{2} {4}~{5}\t{6}\t天星：{3}", g.宫名, g.支Str, g.干Str, g.天星.Select(s => string.Format("{0}{1}{2}", s.星名, s.亮度Str, s.化Str)).ToCSV(","), g.大限From, g.大限To, g.小限.ToCSV(",")));
                }

                return sb.ToString();
            }
        }

        public string TestLiu
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Format("大运:{0}岁", (liu_calendar.ChineseYear - calendar.ChineseYear)));

                for (int i = 0; i < _xingGong.Length; i++)
                {
                    Gong g = _xingGong[i];

                    sb.AppendLine(string.Format("运{0}在：{1}\t干为：{2} \t天星：{3}", g.大限宫名, g.支Str, g.干Str, g.天星.Select(s => string.Format("{0}{1}", s.星名, s.亮度Str)).ToCSV(",")));
                }

                sb.AppendLine(string.Empty);
                sb.AppendLine(string.Format("流年:{0}", liu_calendar.ChineseDateTimeString));

                for (int i = 0; i < _xingGong.Length; i++)
                {
                    Gong g = _xingGong[i];

                    sb.AppendLine(string.Format("流{0}在：{1}\t干为：{2} \t天星：{3}", g.流年宫名, g.支Str, g.干Str, g.天星.Select(s => string.Format("{0}{1}{2}", s.星名, s.亮度Str, s.流化Str)).ToCSV(",")));
                }

                return sb.ToString();
            }
        }

        public void Liu(ChineseCalendar liu_cal)
        {
            liu_calendar = liu_cal;

            int old = this.liu_calendar.ChineseYear - this.calendar.ChineseYear;


            //大限
            var gong = _xingGong.FirstOrDefault(g => g.大限From <= old && g.大限To > old);
            if (gong == null)
                gong = _xingGong.First(g => g.is_命);

            gong.大限宫名 = "命  宫";

            for (int i = 1; i < _gongName.Length; i++)
            {
                gong = gong.Next;
                gong.大限宫名 = _gongName[i];
            }


            //流年
            int zhi = this.liu_calendar.BaziIndex[1];
            gong = _xingGong.First(g => g.支 == zhi + 1);

            gong.流年宫名 = "命  宫";

            for (int i = 1; i < _gongName.Length; i++)
            {
                gong = gong.Next;
                gong.流年宫名 = _gongName[i];
            }

            //流年四化
            foreach (var star in _sihuaxing)
            {
                var xg = _xingGong.First(g => g.天星.Exists(s => s.星名 == star.Value[this.liu_calendar.BaziIndex[0]].ToString()));
                xg.天星.Find(s => s.星名 == star.Value[this.liu_calendar.BaziIndex[0]].ToString()).流化 = star.Key;
            }
        }


        #endregion
    }
}
