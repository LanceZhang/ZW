using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZYWC.ZW.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
        }
    }
}
