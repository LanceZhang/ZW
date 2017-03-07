using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZYWC.ZW.Core;
using ZYWC.ZW.Core.Analysis;
using ZYWC.ZW.Core.Analysis.BusinessLogic;
using ZYWC.ZW.Core.Analysis.Data;

namespace ZYWC.ZW.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
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
            this.txtBrithday.Text = this.txtBrithday.Text + "\n\n" + eg.GeJuAnalyzer.GetResult(pan).ToString();
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
            Dictionary<string, int> dic = new Dictionary<string, int>();

            DateTime dt = DateTime.Now.AddYears(-60);

            for (int i = 0; i < 260000; i++)
            {
                ChineseCalendar cc = new ChineseCalendar(dt);
                var pan = new PaiPan(cc, this.ckMan.Checked);

                string key = string.Empty;

                var star = pan.MingGong.Stars.Where(s => s.Type == Star.StarType.主星).ToList();
                if (star.Count == 0)
                {
                    star = pan.Gongs.First(g => g.Name == "迁移宫").Stars.Where(s => s.Type == Star.StarType.主星).ToList();
                }

                if (star.Count == 2)
                {
                    key = string.Format("{0}#{1}", star[0].Name, star[1].Name);
                }
                else
                {
                    key = star[0].Name;
                }

                if (dic.ContainsKey(key))
                {
                    dic[key]++;
                }
                else
                {
                    dic.Add(key, 1);
                }

                dt = dt.AddHours(2);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in dic.OrderBy(d => d.Key.Length))
            {
                sb.AppendLine(string.Format("{0}:\t\t{1}", item.Key, item.Value));
            }

            this.txtBrithday.Text = sb.ToString();
        }

    }
}
