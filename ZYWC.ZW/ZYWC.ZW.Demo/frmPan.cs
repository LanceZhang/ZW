using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZYWC.ZW.Core.Analysis;
using ZYWC.ZW.Core.Analysis.BusinessLogic;
using ZYWC.ZW.Core.Analysis.Data;
using ZYWC.ZW.Core.Analysis.Model;
using ZYWC.ZW.Core;

namespace ZYWC.ZW.Demo
{
    public partial class frmPan : Form
    {
        public string htmlText { get; set; }
        public frmPan()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.DocumentText = htmlText;
            return;

            #region demo
            this.webBrowser1.DocumentText = @"


<html>
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

<SCRIPT ID=clientEventHandlersJS LANGUAGE=javascript>
//   alert ('sky = ' + 5 + ' earth = ' + 12 + ' month = ' + 1 + ' day = ' + 1 + ' hour = ' + 1 + ' gender = ' + 0);
//   alert ('rslp = ' + 3 + ' rsbp = ' + 3 + 'gwChart = ' + 0);
// alert ('Today =  ' + );
</script>
<table width = '720' border='0' CELLSPACING='0' CELLPADDING='0' bgcolor=white>

</table>


<table bgcolor=white BORDER=0 WIDTH='720' cols='4'>
  <tr><td nowarp colspan=1>
       <table border=1 cols=1 width=175 CELLSPACING=0 CELLPADDING=0>
        <tr>

          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b>天</b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b>機</b></font></td></tr>
                    <tr><td align=center><font ID=mb11>祿</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>天</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>馬</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>天天&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>巫虛&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>伏歲歲</font></td>
                  <td><Center><font id=m10>95-104</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  田辛</font></td></tr>
              <tr><td><font ID=m10>兵破驛</font></td>
                  <td><Center><font ID=m10>臨官</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  宅巳</font></td></tr>
            </table>
          </td>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b>紫</b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b>微</b></font></td></tr>
                    <tr><td align=center><font ID=mb11>科</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>台天截&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>輔廚空&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>大龍息</font></td>
                  <td><Center><font id=m10>85-94</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  事壬</font></td></tr>
              <tr><td><font ID=m10>耗德神</font></td>
                  <td><Center><font ID=m10>冠帶</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  業午</font></td></tr>
            </table>
          </td>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b></b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b></b></font></td></tr>
                    <tr><td align=center><font ID=mb11></font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>天天截&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>哭使空&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>病白華</font></td>
                  <td><Center><font id=m10>75-84</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  交癸</font></td></tr>
              <tr><td><font ID=m10>符虎蓋</font></td>
                  <td><Center><font ID=m10>沐浴</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  友末</font></td></tr>
            </table>
          </td>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b>破</b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b>軍</b></font></td></tr>
                    <tr><td align=center><font ID=mb11>&nbsp;&nbsp;</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>天</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>鉞</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>解天旬劫&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>神福空煞&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>喜天劫</font></td>
                  <td><Center><font id=m10>65-74</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  遷甲</font></td></tr>
              <tr><td><font ID=m10>神德煞</font></td>
                  <td><Center><font ID=m10>長生</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  移申</font></td></tr>
            </table>
          </td>

</tr>
          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b>七</b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b>殺</b></font></td></tr>
                    <tr><td align=center><font ID=mb11>&nbsp;&nbsp;</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;&nbsp;&nbsp;▲</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>文左擎</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>曲輔羊</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>三天紅大月&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>台官鸞耗德&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>官小攀</font></td>
                  <td><Center><font id=m10>105-114</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  福庚</font></td></tr>
              <tr><td><font ID=m10>符耗鞍</font></td>
                  <td><Center><font ID=m10>帝旺</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  德辰</font></td></tr>
            </table>
          </td>



          <td colspan=2 rowspan=2>

<!-- Palace 0 information  -->

     <table width=350 border=0 height=200 valign = top>
      <tr><td height=100 width=30>
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
                    </table></td>

          <td><table width=30 border=0 cellpadding=0 cellspacing=0>
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
            </table></td>

          <td><table width=30 border=0 cellpadding=0 cellspacing=0>
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
            </table></td>

          <td><table width=30 border=0 cellpadding=0 cellspacing=0>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td><font id=m11>丁</font></td></tr>
              <tr><td><font id=m11>酉</font></td></tr>
              <tr><td><font id=m11>年</font></td></tr>
              <tr><td><font id=m11>83</font></td></tr>
              <tr><td><font id=m11>歲</font></td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
              <tr><td>&nbsp;</td></tr>
            </table></td>

          <td><table width=30 border=0 cellpadding=0 cellspacing=0>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>身</font></td></tr>
               <tr><td><font id=m11>主</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>天</font></td></tr>
               <tr><td><font id=m11>機</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
            </table></td>

          <td><table width=30 border=0 cellpadding=0 cellspacing=0 valign=top>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>命</font></td></tr>
               <tr><td><font id=m11>主</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>巨</font></td></tr>
               <tr><td><font id=m11>門</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
            </table></td>

          <td><table width=30 border=0 cellpadding=0 cellspacing=0>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>土</font></td></tr>
               <tr><td><font id=m11>五</font></td></tr>
               <tr><td><font id=m11>局</font></td></tr>
            </table></td>

          <td><table width=60 border=0 cellpadding=0 cellspacing=0>
               <tr><td align=center>&nbsp;</td></tr>
               <tr><td><font id=m11>1935年</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td align=center><font id=m11>乙</font></td></tr>
               <tr><td align=center><font id=m11>亥</font></td></tr>
               <tr><td align=center><font id=m11>年</font></td></tr>
               <tr><td align=center><font id=m11></font></td></tr>
               <tr><td align=center><font id=m11>1</font></td></tr>
               <tr><td align=center><font id=m11>月</font></td></tr>
               <tr><td align=center><font id=m11>1</font></td></tr>
               <tr><td align=center><font id=m11>日</font></td></tr>
               <tr><td align=center><font id=m11>子</font></td></tr>
               <tr><td align=center><font id=m11>時</font></td></tr>
            </table></td>

          <td ><table width='30' border='0' cellpadding='0' cellspacing='0'>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td><font id=m11>陰</font></td></tr>
               <tr><td><font id=m11>男</font></td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
               <tr><td>&nbsp;</td></tr>
            </table></td>
        </tr>
      </table>
    </td>

<!- Palace 0 information end>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b></b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b></b></font></td></tr>
                    <tr><td align=center><font ID=mb11></font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>▲</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>火</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>星</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>恩天天旬破&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>光刑傷空碎&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>蜚吊災</font></td>
                  <td><Center><font id=m10>55-64</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  疾乙</font></td></tr>
              <tr><td><font ID=m10>廉客煞</font></td>
                  <td><Center><font ID=m10>養  </font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  厄酉</font></td></tr>
            </table>
          </td>

</tr>
          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td><font ID=mb11><b>太天</b></font></td></tr>
                    <tr><td><font ID=mb11>陽梁</b></font></td></tr>
                    <tr><td><font ID=mb11>&nbsp;&nbsp;權</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>祿</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>存</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>天龍&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>貴池&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>博官將</font></td>
                  <td><Center><font id=m10>115-124</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  父己</font></td></tr>
              <tr><td><font ID=m10>士符星</font></td>
                  <td><Center><font ID=m10>衰  </font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  母卯</font></td></tr>
            </table>
          </td>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td><font ID=mb11><b>廉天</b></font></td></tr>
                    <tr><td><font ID=mb11>貞府</b></font></td></tr>
                    <tr><td><font ID=mb11>&nbsp;&nbsp;&nbsp;&nbsp;</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;&nbsp;&nbsp;▲</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>文右鈴</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>昌弼星</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>八天天寡&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>座喜月宿&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>奏病天</font></td>
                  <td><Center><font id=m10>45-54</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  財丙</font></td></tr>
              <tr><td><font ID=m10>書符煞</font></td>
                  <td><Center><font ID=m10>胎  </font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  帛戌</font></td></tr>
            </table>
          </td>

</tr>
          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td><font ID=mb11><b>武天</b></font></td></tr>
                    <tr><td><font ID=mb11>曲相</b></font></td></tr>
                    <tr><td><font ID=mb11>&nbsp;&nbsp;&nbsp;&nbsp;</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>▲</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>陀</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>羅</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>封孤陰&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>誥辰煞&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>力貫亡</font></td>
                  <td><Center><font id=m10>5-14</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>身命戊</font></td></tr>
              <tr><td><font ID=m10>士索神</font></td>
                  <td><Center><font ID=m10>病  </font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>宮宮寅</font></td></tr>
            </table>
          </td>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td><font ID=mb11><b>天巨</b></font></td></tr>
                    <tr><td><font ID=mb11>同門</b></font></td></tr>
                    <tr><td><font ID=mb11>&nbsp;&nbsp;&nbsp;&nbsp;</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>天天天蜚&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>才姚壽廉&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>青喪月</font></td>
                  <td><Center><font id=m10>15-24</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  兄己</font></td></tr>
              <tr><td><font ID=m10>龍門煞</font></td>
                  <td><Center><font ID=m10>死  </font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  弟丑</font></td></tr>
            </table>
          </td>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>子</font></td></tr>
                    <tr><td><font ID=m10>斗</font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b>貪</b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b>狼</b></font></td></tr>
                    <tr><td align=center><font ID=mb11>&nbsp;&nbsp;</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>天</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>魁</font></td></tr>
                    <tr><td align=RIGHT><font ID=m10>&nbsp;&nbsp;</font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>咸天&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>池空&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>小晦咸</font></td>
                  <td><Center><font id=m10>25-34</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  夫戊</font></td></tr>
              <tr><td><font ID=m10>耗氣池</font></td>
                  <td><Center><font ID=m10>墓  </font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  妻子</font></td></tr>
            </table>
          </td>


          <td ><table width=175 border=0 height=70 cellpadding=0 cellspacing=0>
              <tr><td height=42 rowspan=2 width=65>
                  <table width=100% border=0 cellpadding=0 cellspacing=0 vspace=0 hspace=0>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td><font ID=m10>  </font></td></tr>
                    <tr><td>&nbsp;</td></tr>
                  </table></td>

                <td height=49 rowspan=2 width=35 valign=top>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>

                    <tr><td align=center><font ID=mb11><b>太</b></font></td></tr>
                    <tr><td align=center><font ID=mb11><b>陰</b></font></td></tr>
                    <tr><td align=center><font ID=mb11>忌</font></td></tr>

                  </table></td>
                <td height=19 rowspan=2 width=67>
                  <table width=100% border=0 cellpadding=0 cellspacing=0>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                    <tr><td align=RIGHT><font ID=m10></font></td></tr>
                  </table></td></tr>
              <tr></tr></table>
            <table width=175 border=0 cellpadding=0 cellspacing=0>
              <tr><td colspan=3><font ID=m10>地地年鳳&nbsp;</font></td></tr>
              <tr><td colspan=3><font ID=m10>空劫解閣&nbsp;</font></td></tr>
              <tr valign=bottom><td><font ID=m10>將太指</font></td>
                  <td><Center><font id=m10>35-44</font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  子丁</font></td></tr>
              <tr><td><font ID=m10>軍歲背</font></td>
                  <td><Center><font ID=m10>絕  </font>&nbsp;&nbsp;</Center></td>
                  <td align=RIGHT><font ID=m10>  女亥</font></td></tr>
            </table>
          </td>



</table>
</td>
</tr>
</Table>
</div>

<a href='javascript:printpage();'>列印</a><br>
<a href='javascript:history.go(-1)'>返回前頁</a>

</body>
</html>

";
            #endregion


        }
    }

    /*
    public class CellData
    {
        public string zhiStr { get; set; }
        public IList<Star> zhuXing {get;set;}
        public IList<Star> fuXing {get;set;}
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

            foreach(var s in zhuXing)
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
                if(string.IsNullOrEmpty(s.Hua))
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
            foreach(var star in fuXing)
            {
                var t = xiongXing.FirstOrDefault(s => s.Name==star.Name);
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
                sb.Append(star.Name.Substring(0,1));
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
                if(string.IsNullOrEmpty(star.Hua))
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
            foreach(var g in gongName)
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

    public static class MingPanFormat
    {
        public static string FormatHtml(PaiPan pan)
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

        public static IList<CellData> parseGong(PaiPan pan)
        {
            var dal = new DAL(@".\Data\");
            List<CellData> datas = new List<CellData>();
            foreach(Gong g in pan.Gongs)
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

                foreach(var s in g.Stars)
                {
                    if (dal.Dic_ZhuXing.ContainsKey(s.Name))
                        cd.zhuXing.Add(s);
                    else if (dal.Dic_JiXing.ContainsKey(s.Name) || dal.Dic_XiongXing.ContainsKey(s.Name))
                        cd.fuXing.Add(s);
                    else if (dal.Dic_XiongXing.ContainsKey(s.Name))
                        cd.xiongXing.Add(s);
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
               </table></td>",pan.birthday.GanZhiYearString.Substring(0, 1), 
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
               </table></td>", (pan.birthday.ChineseYear%2==0)?"阳":"阴",
                            pan.IsMale?"男":"女");

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
            sb.Append("        <tr><td align=center><font ID=mb11><b>"+data.GetZhuXingLine1()+"</b></font></td></tr>");
            sb.Append("        <tr><td align=center><font ID=mb11><b>"+data.GetZhuXingLine2()+"</b></font></td></tr>");
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
            sb.Append("    <td><Center><font id=m10>"+data.daXian+"</font>&nbsp;&nbsp;</Center></td>");
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
    */
}
