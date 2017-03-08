﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;

namespace ZYWC.ZW.Core.Analysis.BusinessLogic
{
    public class PaiPanFormat
    {
        private DAL dal;
        public PaiPanFormat(DAL dal)
        {
            this.dal = dal;
        }
        public string FormatHtml(PaiPan pan)
        {
            var datas = parseGong(pan);

            var sb = new StringBuilder();
            sb.Append(FormatHead(pan));
            sb.Append("<table border=1 cols=1 width=175 CELLSPACING=0 CELLPADDING=0>");
            sb.Append("<tbody><tr>");

            sb.Append(FormatCell(datas.First(d => d.zhiStr == "巳")));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "午")));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "未")));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "申")));

            sb.Append("</tr><tr>");

            sb.Append(FormatCell(datas.First(d => d.zhiStr == "辰")));
            sb.Append(FormatCenter(pan));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "酉")));

            sb.Append("</tr><tr>");

            sb.Append(FormatCell(datas.First(d => d.zhiStr == "卯")));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "戌")));

            sb.Append("</tr><tr>");

            sb.Append(FormatCell(datas.First(d => d.zhiStr == "寅")));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "丑")));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "子")));
            sb.Append(FormatCell(datas.First(d => d.zhiStr == "亥")));

            sb.Append("</tr></tbody>");
            sb.Append("</table>");
            sb.Append(FormatFoot(pan));

            return sb.ToString();
        }

        public IList<CellData> parseGong(PaiPan pan)
        {
            List<CellData> datas = new List<CellData>();
            foreach (Gong g in pan.Gongs)
            {
                CellData cd = new CellData();
                cd.zhiStr = g.ZhiString;
                if (g.Is_Shen)
                {
                    cd.gongName.Add("身宫");
                }
                cd.gongName.Add(g.Name);
                cd.ganStr = g.GanString;

                cd.daXian = string.Format("{0}-{1}", g.DaXian_From, g.DaXian_To);

                foreach (var s in g.Stars)
                {
                    if (dal.Dic_ZhuXing.ContainsKey(s.Name))
                        cd.zhuXing.Add(s);
                    else if (dal.Dic_JiXing.ContainsKey(s.Name) || dal.Dic_XiongXing.ContainsKey(s.Name))
                    {
                        cd.fuXing.Add(s);
                        if (dal.Dic_XiongXing.ContainsKey(s.Name))
                            cd.xiongXing.Add(s);
                    }
                    else if (s.Type == Star.StarType.博士十二 || s.Type == Star.StarType.年前十二 || s.Type == Star.StarType.岁前十二)
                        cd.s2Xing.Add(s);
                    else if (s.Type == Star.StarType.长生十二)
                        cd.changSheng = s;
                    else
                        cd.s1Xing.Add(s);
                }

                datas.Add(cd);
            }
            return datas;
        }

        private static string FormatCenter(PaiPan pan)
        {
            ChineseCalendar tt = new ChineseCalendar(DateTime.Now);
            var sb = new StringBuilder();

            sb.Append("<td colspan=2 rowspan=2>");
            sb.Append("<table width=350 border=0 height=200 valign = top><tr>");
            // 天盘
            sb.Append(@"<td height=100 width=30>
                    <table width=50 border=0 cellpadding=0 cellspacing=0 valign = top>
					  <tr><td height=20><font id=titlefont>&nbsp;中</font></td></tr>
					  <tr><td height=20><font id=titlefont>&nbsp;州</font></td></tr>
					  <tr><td height=20><font id=titlefont>&nbsp;派</font></td></tr>
					  <tr><td height=20><font id=titlefont>&nbsp;紫</font></td></tr>
					  <tr><td height=20><font id=titlefont>&nbsp;微</font></td></tr>
					  <tr><td height=20><font id=titlefont>&nbsp;斗</font></td></tr>
					  <tr><td height=20><font id=titlefont>&nbsp;數</font></td></tr>
                      <tr><td><font id=m10>&nbsp;天</font></td></tr>
                      <tr><td><font id=m10>&nbsp;盤</font></td></tr>
                    </table></td>");

            sb.Append(@"<td><table width=30 border=0 cellpadding=0 cellspacing=0>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               </table></td>");

            // 现行 大限
            sb.Append(@"<td><table width=30 border=0 cellpadding=0 cellspacing=0>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td><font id=m11>現</font></td></tr>
              <tr><td><font id=m11>行</font></td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td><font id=m11>大</font></td></tr>
              <tr><td><font id=m11>限</font></td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              </table></td>");

            // 年龄
            sb.AppendFormat(@"<td><table width=30 border=0 cellpadding=0 cellspacing=0>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td><font id=m11>{0}</font></td></tr>
              <tr><td><font id=m11>{1}</font></td></tr>
              <tr><td><font id=m11>年</font></td></tr>
              <tr><td><font id=m11>{2}</font></td></tr>
              <tr><td><font id=m11>岁</font></td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              </table></td>", tt.GanZhiYearString.Substring(0, 1),
                          tt.GanZhiYearString.Substring(1, 1),
                          tt.ChineseYear - pan.birthday.ChineseYear);

            // 身主
            sb.AppendFormat(@"<td><table width=30 border=0 cellpadding=0 cellspacing=0>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>身</font></td></tr>
               <tr><td><font id=m11>主</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>{0}</font></td></tr>
               <tr><td><font id=m11>{1}</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               </table></td>", pan.ShenZhu.Substring(0, 1),
                             pan.ShenZhu.Substring(1, 1));

            // 命主
            sb.AppendFormat(@"<td><table width=30 border=0 cellpadding=0 cellspacing=0 valign=top>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>命</font></td></tr>
               <tr><td><font id=m11>主</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>{0}</font></td></tr>
               <tr><td><font id=m11>{1}</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               </table></td>", pan.MingZhu.Substring(0, 1),
                             pan.MingZhu.Substring(1, 1));

            // 五行局
            sb.AppendFormat(@"<td><table width=30 border=0 cellpadding=0 cellspacing=0>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>{0}</font></td></tr>
               <tr><td><font id=m11>{1}</font></td></tr>
               <tr><td><font id=m11>{2}</font></td></tr>
               </table></td>", pan.WuXingJu.Substring(0, 1),
                             pan.WuXingJu.Substring(1, 1),
                             pan.WuXingJu.Substring(2, 1));

            // 生日
            sb.AppendFormat(@"<td><table width=60 border=0 cellpadding=0 cellspacing=0>
               <tr><td align=center>&nbsp;</td></tr>
               <tr><td><font id=m11>{5}年</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td align=center><font id=m11>{0}</font></td></tr>
               <tr><td align=center><font id=m11>{1}</font></td></tr>
               <tr><td align=center><font id=m11>年</font></td></tr>
               <tr><td align=center><font id=m11></font></td></tr>
               <tr><td align=center><font id=m11>{2}</font></td></tr>
               <tr><td align=center><font id=m11>月</font></td></tr>
               <tr><td align=center><font id=m11>{3}</font></td></tr>
               <tr><td align=center><font id=m11>日</font></td></tr>
               <tr><td align=center><font id=m11>{4}</font></td></tr>
               <tr><td align=center><font id=m11>时</font></td></tr>
               </table></td>", pan.birthday.GanZhiYearString.Substring(0, 1),
                          pan.birthday.GanZhiYearString.Substring(1, 1),
                          pan.birthday.Date.Month,
                          pan.birthday.Date.Day,
                          pan.birthday.GanZhiHourString.Substring(1, 1),
                          pan.birthday.Date.Year);

            // 性别
            sb.AppendFormat(@"<td ><table width='30' border='0' cellpadding='0' cellspacing='0'>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>{0}</font></td></tr>
               <tr><td><font id=m11>{1}</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               </table></td>", (pan.birthday.ChineseYear % 2 == 0) ? "阳" : "阴",
                            pan.IsMale ? "男" : "女");

            sb.Append("</tr></table>");
            sb.Append("</td>");

            return sb.ToString();
        }

        private static string FormatCell(CellData data)
        {
            var sb = new StringBuilder();


            sb.Append("<td>");
            // 单元格上半部
            sb.Append("  <table width=175 border=0 height=70 cellpadding=0 cellspacing=0><tr>");
            // 上左
            sb.Append("    <td height=42 rowspan=2 width=65>");
            sb.Append("      <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>");
            sb.Append("        <tr><td><font ID=m10></font></td></tr>");
            sb.Append("        <tr><td><font ID=m10></font></td></tr>");
            sb.Append("        <tr><td>&nbsp;</td></tr>");
            sb.Append("      </table>");
            sb.Append("    </td>");
            // 上中
            sb.Append("    <td height=49 rowspan=2 width=35 valign=top>");
            sb.Append("      <table width=100% border=0 cellpadding=0 cellspacing=0>");
            sb.Append("        <tr><td align=center><font ID=mb11><b>" + data.GetZhuXingLine1() + "</b></font></td></tr>");
            sb.Append("        <tr><td align=center><font ID=mb11><b>" + data.GetZhuXingLine2() + "</b></font></td></tr>");
            sb.Append("        <tr><td align=center><font ID=mb11>" + data.GetZhuXingLine3() + "</font></td></tr>");
            sb.Append("      </table>");
            sb.Append("    </td>");
            // 上右
            sb.Append("    <td height=19 rowspan=2 width=67>");
            sb.Append("      <table width=100% border=0 cellpadding=0 cellspacing=0>");
            sb.Append("        <tr><td align=RIGHT><font ID=m10>" + data.GetFuXingLine1() + "</font></td></tr>");
            sb.Append("        <tr><td align=RIGHT><font ID=m10>" + data.GetFuXingLine2() + "</font></td></tr>");
            sb.Append("        <tr><td align=RIGHT><font ID=m10>" + data.GetFuXingLine3() + "</font></td></tr>");
            sb.Append("        <tr><td align=RIGHT><font ID=m10>" + data.GetFuXingLine4() + "</font></td></tr>");
            sb.Append("      </table>");
            sb.Append("    </td>");

            sb.Append("  </tr><tr></tr></table>");

            // 单元格下半部
            sb.Append("<table width=175 border=0 cellpadding=0 cellspacing=0>");
            sb.Append("  <tr><td colspan=3><font ID=m10>" + data.GetS1XingLine1() + "</font></td></tr>");
            sb.Append("  <tr><td colspan=3><font ID=m10>" + data.GetS1XingLine2() + "</font></td></tr>");
            sb.Append("  <tr valign=bottom>");
            sb.Append("    <td><font ID=m10>" + data.GetS2XingLine1() + "</font></td>");
            sb.Append("    <td><Center><font id=m10>" + data.daXian + "</font>&nbsp;&nbsp;</Center></td>");
            sb.Append("    <td align=RIGHT><font ID=m10>  " + data.GetGongNameLine1() + "</font></td>");
            sb.Append("  </tr>");
            sb.Append("  <tr valign=bottom>");
            sb.Append("    <td><font ID=m10>" + data.GetS2XingLine2() + "</font></td>");
            sb.Append("    <td><Center><font ID=m10>" + data.changSheng.Name + "</font>&nbsp;&nbsp;</Center></td>");
            sb.Append("    <td align=RIGHT><font ID=m10>  " + data.GetGongNameLine2() + "</font></td>");
            sb.Append("  </tr>");
            sb.Append("</table>");

            sb.Append("</td>");

            return sb.ToString();
        }

        private static string FormatHead(PaiPan pan)
        {
            return (@"<html>
                    <head>

                    <title>斗數星盤</title>
                    <meta http-equiv='Content-Type' content='text/html; charset=big5'>

                    <STYLE>
                     #m9 {font-family:'細明體'; font-size: 9pt}
                     #m10 {font-family:'細明體'; font-size: 10pt}
                     #m11 {font-family:'細明體'; font-size: 11pt}
                     #mb11 {font-family:'細明體'; font-size: 11pt; font-weight: bold}
                     #titlefont {font-family:'細明體'; font-size: 18pt; font-weight: bold}
                    </STYLE>


                    <SCRIPT LANGUAGE='JavaScript1.2'>
                    function printpage() {
                    window.print();
                    }

                    </SCRIPT>
                    </head>

                    <div id=contentstart>

                    <body marginheight='0' marginwidth='0' bgcolor=white>

                    <table width = '720' border='0' CELLSPACING='0' CELLPADDING='0' bgcolor=white>

                    </table>


                    <table bgcolor=white BORDER=0 WIDTH='720' cols='4'>
                      <tr><td nowarp colspan=1>");
        }

        private static string FormatFoot(PaiPan pan)
        {
            return (@"</td>
                </table>
                </td>
                </tr>
                </Table>
                </div>

                </body>
                </html>");
        }
    }

    public class CellData
    {
        public string zhiStr { get; set; }
        public IList<Star> zhuXing { get; set; }
        public IList<Star> fuXing { get; set; }
        public IList<Star> xiongXing { get; set; }
        public IList<Star> s1Xing { get; set; }
        // 博士年前岁前
        public IList<Star> s2Xing { get; set; }
        public Star huaXing { get; set; }
        // 长生
        public Star changSheng { get; set; }
        public IList<string> gongName { get; set; }
        public string ganStr { get; set; }
        public string daXian { get; set; }

        public CellData()
        {
            zhuXing = new List<Star>();
            fuXing = new List<Star>();
            xiongXing = new List<Star>();
            s1Xing = new List<Star>();
            s2Xing = new List<Star>();
            gongName = new List<string>();
        }

        public string GetZhuXingLine1()
        {
            var sb = new StringBuilder(2);

            foreach (var s in zhuXing)
            {
                sb.AppendFormat("{0}", s.Name.ToCharArray()[0]);
            }

            return sb.ToString();
        }
        public string GetZhuXingLine2()
        {
            var sb = new StringBuilder(2);

            foreach (var s in zhuXing)
            {
                sb.AppendFormat("{0}", s.Name.ToCharArray()[1]);
            }

            return sb.ToString();
        }
        public string GetZhuXingLine3()
        {
            var sb = new StringBuilder(2);

            foreach (var s in zhuXing)
            {
                if (string.IsNullOrEmpty(s.Hua))
                {
                    sb.Append("&nbsp;&nbsp;");
                }
                else
                {
                    sb.Append(s.Hua);
                }
            }

            return sb.ToString();
        }

        public string GetFuXingLine1()
        {
            var sb = new StringBuilder();
            foreach (var star in fuXing)
            {
                var t = xiongXing.FirstOrDefault(s => s.Name == star.Name);
                if (t == null)
                    sb.Append("&nbsp;&nbsp;");
                else
                    sb.Append("▲");
            }
            return sb.ToString();
        }

        public string GetFuXingLine2()
        {
            var sb = new StringBuilder();
            foreach (var star in fuXing)
            {
                sb.Append(star.Name.Substring(0, 1));
            }
            return sb.ToString();
        }
        public string GetFuXingLine3()
        {
            var sb = new StringBuilder();
            foreach (var star in fuXing)
            {
                sb.Append(star.Name.Substring(1, 1));
            }
            return sb.ToString();
        }
        public string GetFuXingLine4()
        {
            var sb = new StringBuilder();
            foreach (var star in fuXing)
            {
                if (string.IsNullOrEmpty(star.Hua))
                    sb.Append("&nbsp;&nbsp;");
                else
                    sb.Append(star.Hua);
            }
            return sb.ToString();
        }

        public string GetS1XingLine1()
        {
            var sb = new StringBuilder();
            foreach (var s in s1Xing)
            {
                sb.Append(s.Name.Substring(0, 1));
            }
            return sb.ToString();
        }
        public string GetS1XingLine2()
        {
            var sb = new StringBuilder();
            foreach (var s in s1Xing)
            {
                sb.Append(s.Name.Substring(1, 1));
            }
            return sb.ToString();
        }
        public string GetS2XingLine1()
        {
            var sb = new StringBuilder();
            foreach (var s in s2Xing)
            {
                sb.Append(s.Name.Substring(0, 1));
            }
            return sb.ToString();
        }
        public string GetS2XingLine2()
        {
            var sb = new StringBuilder();
            foreach (var s in s2Xing)
            {
                sb.Append(s.Name.Substring(1, 1));
            }
            return sb.ToString();
        }

        public string GetGongNameLine1()
        {
            var sb = new StringBuilder();
            foreach (var g in gongName)
            {
                sb.Append(g.Substring(0, 1));
            }
            sb.Append(ganStr);
            return sb.ToString();
        }
        public string GetGongNameLine2()
        {
            var sb = new StringBuilder();
            foreach (var g in gongName)
            {
                sb.Append(g.Substring(1, 1));
            }
            sb.Append(zhiStr);
            return sb.ToString();
        }
    }
}