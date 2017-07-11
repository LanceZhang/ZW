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

            #endregion

            DateTime dateTime = this.dpBirthDate.Value;
            ChineseCalendar cc = new ChineseCalendar(dateTime);
            var pan = new PaiPan(cc, this.ckMan.Checked);

            eg = new Engine(@".\Data\");

            frmPan f1 = new frmPan();
            f1.htmlText = eg.PaiPanFormat.FormatHtml(pan, 1);
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




        private BasicGong SanFangSiZheng(PaiPan pan, string name)
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
            //string refer = "https://so.m.sm.cn/s?q=%E5%85%AB%E5%AD%97%E7%9C%8B%E5%A9%9A%E5%A7%BB&from=wy930931";


            //var sp = refer.Split('=', '&');

            //MessageBox.Show(System.Web.HttpUtility.UrlDecode(sp[1], System.Text.Encoding.UTF8));

            //HttpClient httpClient = new HttpClient();
            //HttpContent content = new StringContent(@"{ order_guid: '2017061415140995991252'}");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //httpClient.PostAsync(new Uri("http://weixin.mp.12ystar.com/SendResult"), content).ContinueWith(
            //(requestTask) =>
            //{
            //    // Get HTTP response from completed task. 
            //    HttpResponseMessage response = requestTask.Result;

            //    // Check that response was successful or throw exception 
            //    response.EnsureSuccessStatusCode();

            //    // Read response asynchronously as JsonValue and write out top facts for each country 
            //    response.Content.ReadAsAsync<string>().ContinueWith(
            //        (readTask) =>
            //        {
            //            MessageBox.Show(readTask.Result);
            //        });
            //});






            //string serviceAddress = "http://weixin.mp.12ystar.com/shance/SendResult";
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(serviceAddress);
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //string strContent = @"{ order_guid: '2017061415140995991252' }";
            //using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            //{
            //    dataStream.Write(strContent);
            //    dataStream.Close();
            //}
            
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //using (StreamReader dataStream = new StreamReader(response.GetResponseStream()))
            //{
            //    var result = dataStream.ReadToEnd();
            //    MessageBox.Show(result);
            //}
        }

    }
}
