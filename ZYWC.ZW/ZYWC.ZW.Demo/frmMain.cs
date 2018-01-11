using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZYWC.ZW.Core;
using ZYWC.ZW.Core.Analysis;
using ZYWC.ZW.Core.Analysis.BusinessLogic;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Demo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.dpBirthDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dpLiuDate.CustomFormat = "yyyy-MM-dd HH:mm";
            //btnUtil.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = this.dpBirthDate.Value;
            ChineseCalendar cc = new ChineseCalendar(dateTime);
            this.txtBrithday.Text = "阳历：" + cc.DateString
                + " \n属相：" + cc.AnimalString
                + " \n农历：" + cc.ChineseDateTimeString
                + " \n节气：" + cc.ChineseTwentyFourDay
                + " \n节日：" + cc.ChineseCalendarHoliday + " " + cc.DateHoliday
                + " \n前一个节气：" + cc.ChineseTwentyFourPrevDay
                + " \n后一个节气：" + cc.ChineseTwentyFourNextDay
                + " \n干支：" + cc.GanZhiDateTimeString
                + " \n星期：" + cc.WeekDayStr
                + " \n星宿：" + cc.ChineseConstellation
                + " \n星座：" + cc.Constellation
                + " \n八字：" + cc.BaziString
                + " \n八字序号：" + cc.BaziIndex.ToList().ToCSV(",");


            PaiPan pan = new PaiPan(cc, this.ckMan.Checked);
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + pan.Test;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateTime = this.dpBirthDate.Value;
            ChineseCalendar cc = new ChineseCalendar(dateTime);
            PaiPan pan = new PaiPan(cc, this.ckMan.Checked);

            ChineseCalendar cliu = new ChineseCalendar(this.dpLiuDate.Value);


            pan.Liu(cliu);


            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + pan.TestLiu;


        }


        Engine eg = null;

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateTime = this.dpBirthDate.Value;
            ChineseCalendar cc = new ChineseCalendar(dateTime);

            var pan = new PaiPan(cc, this.ckMan.Checked);

            eg = new Engine(@".\Data\");

            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.MingAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.GeJuAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.FuMuAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.FuQiAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.JiaoYouAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.JiEAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.QianYiAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.ShiYeAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.TianZhaiAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.XiongDiAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.ZiNvAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.CaiBoAnalyzer.GetResult(pan).ToString();
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.FudeAnalyzer.GetResult(pan).ToString();
        }

        private void btnGeJu_Click(object sender, EventArgs e)
        {
            DateTime dateTime = this.dpBirthDate.Value;
            ChineseCalendar cc = new ChineseCalendar(dateTime);
            PaiPan pan = new PaiPan(cc, this.ckMan.Checked);
            var eg = new Engine(@".\Data\");

            this.txtBrithday.Text = eg.GeJuAnalyzer.GetResult(pan).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //TestAiqingScore();
            //return;
            eg = new Engine(@".\Data\");

            #region 穷举命盘

            //Dictionary<string, int> dic = new Dictionary<string, int>();

            //DateTime dt = DateTime.Now.AddYears(-60);

            //for (int i = 0; i < 260000; i++)
            //{
            //    ChineseCalendar cc = new ChineseCalendar(dt);
            //    var pan = new PaiPan(cc, this.ckMan.Checked);

            //    string key = string.Empty;

            //    var star = pan.MingGong.Stars.Where(s => s.Type == Star.StarType.主星).ToList();
            //    if (star.Count == 0)
            //    {
            //        star = pan.Gongs.First(g => g.Name == "迁移宫").Stars.Where(s => s.Type == Star.StarType.主星).ToList();
            //    }

            //    if (star.Count == 2)
            //    {
            //        key = string.Format("{0}#{1}", star[0].Name, star[1].Name);
            //    }
            //    else
            //    {
            //        key = star[0].Name;
            //    }

            //    if (dic.ContainsKey(key))
            //    {
            //        dic[key]++;
            //    }
            //    else
            //    {
            //        dic.Add(key, 1);
            //    }

            //    dt = dt.AddHours(2);
            //}

            //StringBuilder sb = new StringBuilder();
            //foreach (var item in dic.OrderBy(d => d.Key.Length))
            //{
            //    sb.AppendLine(string.Format("{0}:\t\t{1}", item.Key, item.Value));
            //}

            //this.txtBrithday.Text = sb.ToString();

            #endregion

            #region 流年财运

            //pan.Liu(new ChineseCalendar(DateTime.Now));

            //var dt = new DateTime(1985, 1, 1, 2, 0, 0);
            //var dt2 = new DateTime(2049, 12, 30, 0, 0, 0);

            //var rets = eg.LiuNianAnalyzer.GetLiuNianInfo(pan, GongIndex.财帛宫);
            //var sss= eg.GetStarGuardStone("紫微");
            //dt = new DateTime(1996, 1, 1, 0, 0, 0);

            //for (; dt < dt2; dt = dt.AddYears(1))
            //{
            //    cc = new ChineseCalendar(dt);
            //    pan.Liu(cc);
            //    var score = eg.LiuNianAnalyzer.GetLiuNianCaiboScore(pan);
            //    this.txtBrithday.Text += string.Format("{0}:{1}\n", dt.Year, score);
            //}

            //var dt = new DateTime(1982, 11, 3, 6, 1, 0);
            //ChineseCalendar dtc = new ChineseCalendar(dt);
            //var ppan = new PaiPan(dtc, true);
            //var caiboMing = ppan.Gongs.First(g => g.Name == GongIndex.财帛宫.ToString());
           // var score = eg.LiuNianAnalyzer.CaiboScore(ppan, caiboMing);
            #endregion

            DateTime dateTime = this.dpBirthDate.Value;
            ChineseCalendar cc = new ChineseCalendar(dateTime);
            ChineseCalendar2 cc2 = new ChineseCalendar2(dateTime);
            var pan = new PaiPan(cc, this.ckMan.Checked);

            

            frmPan f1 = new frmPan();
            f1.htmlText = eg.PaiPanFormat.FormatHtml(pan, 1, cc2);
            f1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lblVersion.Text = "version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }


        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d">double 型数字</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ConvertIntToDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //解流年盘

            DateTime dateTime = this.dpBirthDate.Value;
            ChineseCalendar cc = new ChineseCalendar(dateTime);
            var pan = new PaiPan(cc, this.ckMan.Checked);

            eg = new Engine(@".\Data\");

            pan.Liu(new ChineseCalendar(this.dpLiuDate.Value));


            StringBuilder sb = new StringBuilder();

            foreach (GongIndex g_index in (GongIndex[])System.Enum.GetValues(typeof(GongIndex)))
            {
                var gong = pan.Gongs.First(g => g.LiuName == g_index.ToString());

                var stars = gong.Stars.Where(s => s.Type == Star.StarType.主星).ToList();
                if (stars.Count == 0)
                {
                    var sfsz = SanFangSiZheng(pan, gong.Name);
                    stars = sfsz.DuiZhaoGong.Stars.Where(s => s.Type == Star.StarType.主星).ToList();
                }

                var infos = eg.LiuNianAnalyzer.GetLiuNianInfo(stars.Select(s => s.Name).ToArray(), g_index);


                sb.AppendLine(string.Format("【{0}】", g_index.ToString()));
                sb.AppendLine("");
                foreach (var info in infos)
                {
                    sb.AppendLine(info.title);
                    sb.AppendLine(info.text);
                    sb.AppendLine("");
                }
                sb.AppendLine("");
                sb.AppendLine("");
            }



            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + sb.ToString();

        }




        public static BasicGong SanFangSiZheng(PaiPan pan, string name)
        {
            //三方四正
            var model = new BasicGong();
            model.SelfGong = pan.Gongs.First(g => g.Name == name);

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

        private void button6_Click(object sender, EventArgs e)
        {
            var birth = new DateTime(2018, 1, 1, 15, 0, 0);
            List<string> rets = new List<string>();
            var cc = new ChineseCalendar(birth);
            if (!string.IsNullOrEmpty(cc.ChineseTwentyFourDay))
            {
                rets.Add(cc.ChineseTwentyFourDay);
            }
            else
            {
                rets.Add(cc.ChineseTwentyFourPrevDay);
                rets.Add(cc.ChineseTwentyFourNextDay);
            }
            
        }

        void TestAiqingScore()
        {
            var asa = new AiqingScoreAnalyzer();
            var dt1 = new DateTime(1980, 1, 1, 0, 0, 0);
            var dt2 = new DateTime(1980, 2, 1, 0, 0, 0);
            var sb = new StringBuilder();
            for (var dt = dt1; dt < dt2; dt = dt.AddHours(2))
            {
                var dtc = new ChineseCalendar(dt);
                var pan = new PaiPan(dtc, true);
                var score = asa.GetScore(pan);
                sb.AppendLine(score.ToString());
            }
            this.txtBrithday.Text = sb.ToString();
        }

        private void btnUtil_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlg.FileName, Encoding.Default);
                string line;
                var sb = new StringBuilder();
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line)){
                        //HandleLine(line);
                    }
                }

                this.txtBrithday.Text = sb.ToString();
            }
        }
        

    }

    public class AiqingScoreAnalyzer
    {
        public int GetScore(PaiPan pan)
        {
            var mingGong = pan.Gongs.First(g => g.Name == GongIndex.命宫.ToString());
            var fuqiGong = pan.Gongs.First(g => g.Name == GongIndex.夫妻宫.ToString());
            var sfsz = frmMain.SanFangSiZheng(pan, fuqiGong.Name);
            // 主星
            List<Star> zhuxing = fuqiGong.Stars.Where(s => s.Type == Star.StarType.主星).ToList();
            if (zhuxing == null || zhuxing.Count == 0)
            {
                zhuxing = new List<Star>();
                var duiStars = sfsz.DuiZhaoGong.Stars.Where(s => s.Type == Star.StarType.主星);
                foreach (var star in duiStars)
                {
                    var s = new Star(star.Name, star.Type);
                    if (star.LiangDu != null)
                    {
                        int ld = (int)star.LiangDu;
                        ld -= 2;
                        if (ld < -3)
                            ld = -3;
                        s.LiangDu = ld;
                    }
                    zhuxing.Add(s);
                }
            }

            float totalScore = 0;

            // 主星得分
            if (zhuxing.Count == 1)
            {
                int liandu = (int)zhuxing[0].LiangDu;
                totalScore = fuqiZhuXingScore[zhuxing[0].Name] * liangduWeight[liandu];
            }
            else if (zhuxing.Count == 2)
            {
                float liandu = (liangduWeight[(int)zhuxing[0].LiangDu] + liangduWeight[(int)zhuxing[1].LiangDu]) / 2;
                int score = 0;
                bool exist = fuqiZhuXingScore.TryGetValue(zhuxing[0].Name + zhuxing[1].Name, out score);
                if (!exist)
                    exist = fuqiZhuXingScore.TryGetValue(zhuxing[1].Name + zhuxing[0].Name, out score);
                if (!exist)
                    return 0;
                totalScore = score * liandu;
            }

            foreach (var star in mingGong.Stars)
            {
                int score = 0;
                bool exist = mingXingScore.TryGetValue(star.Name, out score);
                if (exist)
                    totalScore += score;
            }

            foreach (var star in fuqiGong.Stars)
            {
                int score = 0;
                bool exist = fuqiXingScore.TryGetValue(star.Name, out score);
                if (exist)
                    totalScore += score;
            }

            return (int)totalScore;
        }

        private static Dictionary<string, int> fuqiZhuXingScore = new Dictionary<string, int>() 
        { 
            {"紫微",70},
            {"天机",70},
            {"太阳",80},
            {"武曲",60},
            {"天同",80},
            {"廉贞",60},
            {"天府",80},
            {"太阴",90},
            {"贪狼",70},
            {"巨门",60},
            {"天相",90},
            {"天梁",80},
            {"七杀",60},
            {"破军",70},
            {"紫微破军",70},
            {"紫微天府",75},
            {"紫微贪狼",70},
            {"紫微天相",80},
            {"紫微七杀",65},
            {"天机太阴",80},
            {"天机巨门",65},
            {"天机天梁",75},
            {"太阳太阴",85},
            {"太阳巨门",70},
            {"太阳天梁",80},
            {"武曲七杀",60},
            {"武曲天相",75},
            {"武曲破军",65},
            {"武曲天府",70},
            {"武曲贪狼",65},
            {"天同巨门",70},
            {"天同天梁",80},
            {"天同太阴",85},
            {"廉贞天府",70},
            {"廉贞贪狼",65},
            {"廉贞天相",75},
            {"廉贞七杀",60},
            {"廉贞破军",65}
        };

        private static Dictionary<int, float> liangduWeight = new Dictionary<int, float>()
        {
            {3, 1.5f},
            {2, 1.2f},
            {1, 1f},
            {0, 1f},
            {-1, 0.8f},
            {-2, 0.7f},
            {-3, 0.5f}
        };

        private static Dictionary<string, int> mingXingScore = new Dictionary<string, int>()
        {
            {"贪狼",40},
            {"廉贞",35},
            {"红鸾",20},
            {"天喜",20},
            {"天姚",10},
            {"咸池",10},
            {"沐浴",10},
            {"寡宿",-20},
            {"孤辰",-20},
        };

        private static Dictionary<string, int> fuqiXingScore = new Dictionary<string, int>()
        {
            {"贪狼",40},
            {"廉贞",35},
            {"红鸾",20},
            {"天喜",20},
            {"天姚",10},
            {"咸池",10},
            {"沐浴",10},
            {"寡宿",-20},
            {"孤辰",-20},
        };
    }
}
