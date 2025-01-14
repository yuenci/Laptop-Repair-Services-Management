﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using miniSys0._3.Controls.MainArea;

namespace miniSys0._3.Controls
{
    public partial class UC_main : UserControl
    {
        public UC_main uc_main;
        private Color newsFore = Color.Black;
        public static ChromiumWebBrowser WebBrowser;
        public static ChromiumWebBrowser WebBrowser1;
        public static ChromiumWebBrowser WebBrowser2;

        public UC_main()
        {
            InitializeComponent();
            Main.main.prepareData();
            InitializeChromeForMainLineChart();
            InitializeChromeForMainPieChart();
            CefinitStatus();

 
            initsunnyUI();
            InitTheme();

            initName();
            initDataBanner();
            initShortcut();

            initNewsDataToGlobal();
            InitNewsEvent();
            initNoticesStyle();
            InitNoticeEvent();
            initNoticeDataToGlobal();
            InitDocEvent();


            initReader();
            uc_main = this;
        }

        public void InitTheme()
        {
            if (User_type.user_theme == "dark")
            {
                newsFore = Color.White;
                dynamic[] panels = { uiUserControl2 , uiUserControl3 , uiUserControl4 ,
                uiUserControl5,uiUserControl6,uiUserControl7 };

                foreach (dynamic pan in panels)
                {
                    pan.FillColor = Color.FromArgb(28, 47, 70);
                    pan.RectColor = Color.FromArgb(28, 47, 70);
                    pan.BackColor = Color.FromArgb(28, 47, 70);
                }
                dynamic[] lables = { name_lable ,label3,BannerLabel1,label6,BannerLabel2,label8,
                                        BannerLabel3,label10,BannerLabel4,label14,shortcutText1,
                                        shortcutText2,shortcutText3,label15,ratioLabel,
                                        noticeText1,noticeText2,noticeText3,noticeText4,noticeText5,
                                        label19, doc1,doc2,doc3,doc4,label16,
                                        news1,news2,news3,news4,news5,
                                        newslabel1,newslabel2,newslabel3,newslabel4,newslabel5
                                    };
                foreach (var lable in lables)
                {
                    lable.ForeColor = Color.White;
                }
            }
        }
        
        void initsunnyUI()
        {
            upperTriangle.ForeColor = Color.Red;
            upperTriangle.FillColor = Color.Transparent;

            newsTopBar.RectColor = Color.Transparent;
            newsTopBar.FillColor = Color.FromArgb(242, 243, 245);
            news1.MarkColor = Color.FromArgb(242, 243, 245);
            news2.MarkColor = Color.FromArgb(242, 243, 245);
            news3.MarkColor = Color.FromArgb(242, 243, 245);
            news4.MarkColor = Color.FromArgb(242, 243, 245);
            news5.MarkColor = Color.FromArgb(242, 243, 245);

            shortcutButton1.FillColor = Color.FromArgb(242, 243, 245);
            shortcutButton2.FillColor = Color.FromArgb(242, 243, 245);
            shortcutButton3.FillColor = Color.FromArgb(242, 243, 245);
            shortcutButton1.SymbolColor  = Color.Black;
            shortcutButton2.SymbolColor = Color.Black;
            shortcutButton3.SymbolColor = Color.Black;
            shortcutButton1.SymbolHoverColor = Color.Black;
            shortcutButton2.SymbolHoverColor = Color.Black;
            shortcutButton3.SymbolHoverColor = Color.Black;

            shortcutButton1.RectColor = Color.Transparent;
            shortcutButton2.RectColor = Color.Transparent;
            shortcutButton3.RectColor = Color.Transparent;

            refreshlButton1.FillColor = Color.White;
            refreshlButton1.FillHoverColor= Color.FromArgb(242, 243, 245);
            refreshlButton1.SymbolColor = Color.Black;
            refreshlButton1.SymbolHoverColor = Color.Black;
            refreshlButton1.SymbolPressColor = Color.Black;
            refreshlButton1.RectColor = Color.Transparent;
            refreshlButton1.RectHoverColor = Color.Transparent;
            refreshlButton1.RectPressColor = Color.Transparent;
            refreshlButton2.FillColor = Color.White;
            refreshlButton2.FillHoverColor = Color.FromArgb(242, 243, 245);
            refreshlButton2.SymbolColor = Color.Black;
            refreshlButton2.SymbolHoverColor = Color.Black;
            refreshlButton2.SymbolPressColor = Color.Black;
            refreshlButton2.RectColor = Color.Transparent;
            refreshlButton2.RectHoverColor = Color.Transparent;
            refreshlButton2.RectPressColor = Color.Transparent;
        }
        
        private void initName()
        {
            string greet = $"Welcome back，{User_type.user_name}";
            name_lable.Text = greet;
        }
        
        public  static  dynamic getDataReader(string sql)
        {
            string connStr = AppSetting.DBString;

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //string sql = $"SELECT TOP 5 Title, Views FROM Articles ORDER BY  Views DESC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dynamic[] connTools = { conn , dr };
            return connTools;
        }

        public static List<int> getOneWeekOrderNum()
        {
            string allsql = "";
            for (int i = 0; i < 7; i++)
            {
                var sqlpart = $"select COUNT(*) from Orders where DateDiff(dd,Time,getdate())={i};";
                allsql += sqlpart;
            }
            dynamic[] connTools2 = getDataReader(allsql);
            SqlDataReader dr2 = connTools2[1];
            SqlConnection conn2 = connTools2[0];
            /*if (dr2.Read())
            {
                BannerLabel3.Text = dr2[0].ToString();
                Console.WriteLine(dr2.FieldCount);
                //BannerLabel4.Text = dr2[1].ToString();
            }*/
            List<int> result = new List<int>();
            do
            {
                dr2.Read();
                result.Add(int.Parse(dr2[0].ToString()));
            }
            while (dr2.NextResult());
            dr2.Close();
            conn2.Close();
            return result;
        }

        public static List<int> getOnemonthratio()
        {
            string allsql = "";
            for (int i = 0; i < 8; i++)
            {
                var sqlpart = $"select COUNT(*) from Orders where month(Time) = month(getdate()) and " +
                    $"year(Time) = year(getdate()) and Service_type = 'Ser00{i+1}';";
                allsql += sqlpart;
            }
            dynamic[] connTools2 = getDataReader(allsql);
            SqlDataReader dr2 = connTools2[1];
            SqlConnection conn2 = connTools2[0];
            List<int> result = new List<int>();
            do
            {
                dr2.Read();
                result.Add(int.Parse(dr2[0].ToString()));
            }
            while (dr2.NextResult());
            dr2.Close();
            conn2.Close();
            return result;
        }
        
        private void initDataBanner()
        {

            //allOrders
            dynamic[] connTools = getDataReader("SELECT COUNT(*) from Orders");
            SqlDataReader dr = connTools[1];
            SqlConnection conn = connTools[0];
            if (dr.Read())
            {
                BannerLabel1.Text = dr[0].ToString();
            }
            dr.Close();
            conn.Close();

            // servicing
            string sql = "WITH A AS(SELECT DISTINCT OrderID from Schedule WhERE Status = 'Finished'),";
            sql += "B AS(SELECT DISTINCT OrderID from Schedule)";
            sql += "select count(*) from B where (select count(1) as num from A where A.OrderID = B.OrderID) = 0";



            dynamic[] connTools1 = getDataReader(sql);
            SqlDataReader dr1 = connTools1[1];
            SqlConnection conn1 = connTools1[0];
            if (dr1.Read())
            {
                BannerLabel2.Text = dr1[0].ToString();
            }
            dr1.Close();
            conn1.Close();


            //todays and yestordays and a weeks
            List<int> weekOrderNum = getOneWeekOrderNum();
            //today
            int orderToday = weekOrderNum[0];
            BannerLabel3.Text = orderToday.ToString();
            //yesterday
            int orderYesterday = weekOrderNum[1];

            Console.WriteLine($"today{orderToday}");
            Console.WriteLine($"yesterday{orderYesterday}");

            if (orderYesterday> orderToday)
            {
                upperTriangle.Symbol = 67;
                if (orderToday == 0)
                {
                    BannerLabel4.Text = "0%";
                }
                else
                {
                    BannerLabel4.Text = (100 * (orderToday - orderYesterday) / orderToday).ToString() + "%";
                }
                
            }
            else
            {
                try
                {
                    BannerLabel4.Text = (100 * (orderToday - orderYesterday) / orderToday).ToString() + "%";
                }
                catch
                {
                    BannerLabel4.Text = "0";
                }
                
            }


        }

        private void initNewsDataToGlobal()
        {
            dynamic[] connTools = getDataReader("SELECT TOP 5 ArticlelD,Title, PosterID,Time,Url,Views,Likes FROM Articles WHERE TYPE ='News' ORDER BY  Views DESC");
            SqlDataReader dr = connTools[1];
            SqlConnection conn = connTools[0];
            dynamic[] newsList = { news1, news2 , news3 , news4 , news5 };
            dynamic[] newsLableList = { newslabel1, newslabel2, newslabel3, newslabel4, newslabel5 };
            for (int i = 0; dr.Read(); i++)
            {
                var title ="";
                var text = ""; 
                if (dr["Title"].ToString().Length > 30)
                {
                    ArticlesInfo.titleParaList[i] = "[News]" + dr["Title"].ToString();
                    title = dr["Title"].ToString().Substring(0, 30);
                    text = (i+1).ToString() + "      " + title + "...";
                }
                else
                {
                    ArticlesInfo.titleParaList[i] = "[News]" + dr["Title"].ToString();
                    title = dr["Title"].ToString();
                    text = (i + 1).ToString() + "      " + title;
                }
                newsList[i].Text = text;
                newsLableList[i].Text = dr["Views"].ToString();

                ArticlesInfo.ArticlelDList[i] = dr["ArticlelD"].ToString();
                ArticlesInfo.posterParaList[i] = dr["PosterID"].ToString();
                //
                ArticlesInfo.viewsParaList[i] = dr["Views"].ToString();
                ArticlesInfo.likesParaList[i] = dr["Likes"].ToString();
                ArticlesInfo.timeParaList[i] = dr["Time"].ToString();
                ArticlesInfo.urlParaList[i] = dr["Url"].ToString();
            }
            dr.Close();
            conn.Close();

            for (int i = 0; i < 5; i++)
            {
                string posterId = ArticlesInfo.posterParaList[i];
                dynamic[] connTools2 = getDataReader($"SELECT Name, Post FROM Staff WHERE StaffID ='{posterId}'");
                SqlDataReader dr2 = connTools2[1];
                SqlConnection conn2 = connTools2[0];
                if (dr2.Read())
                {
                    ArticlesInfo.posterParaList[i] = dr2["Name"].ToString();
                    ArticlesInfo.staffpostParaList[i] = dr2["Post"].ToString();
                }
                dr2.Close();
                conn2.Close();

                //
            }

        }

        private void noticeStyle(dynamic noticeObj,string type)
        {
            if (type == "Activity")
            {
                noticeObj.Text = "Activity";
                noticeObj.FillDisableColor = Color.FromArgb(255, 247, 232);
                noticeObj.ForeDisableColor = Color.FromArgb(255, 125, 0);
            }
            else if (type == "Message")
            {
                noticeObj.Text = "Message";
                noticeObj.FillDisableColor = Color.WhiteSmoke;
                noticeObj.ForeDisableColor = Color.FromArgb(15, 198, 194);
            }
            else if (type == "Advice")
            {
                noticeObj.Text = "Advice";
                noticeObj.FillDisableColor = Color.FromArgb(255, 247, 232);
                noticeObj.ForeDisableColor = Color.FromArgb(22, 93, 255);
            }
            else
            {
                Console.WriteLine("error");
            }
        }


        private void initNoticesStyle()
        {
            notice1.RectDisableColor = Color.Transparent;
            notice2.RectDisableColor = Color.Transparent;
            notice3.RectDisableColor = Color.Transparent;
            notice4.RectDisableColor = Color.Transparent;
            notice5.RectDisableColor = Color.Transparent;


            dynamic[] connTools = getDataReader("select top 5 Title,Type,ArticlelD,PosterID," +
                "Views,Likes,Time,Url" +
                " from Articles Order by Time desc");
            SqlDataReader dr = connTools[1];
            SqlConnection conn = connTools[0];

            dynamic[] moticeList = { notice1, notice2, notice3, notice4, notice5 };
            dynamic[] noticeTextList = { noticeText1 , noticeText2, noticeText3, noticeText4 , noticeText5 };

            for (int i = 0; i < 5; i++)
            {
                dr.Read();
                string title = dr["Title"].ToString();
                string type = dr["Type"].ToString();
                noticeTextList[i].Text = title.ToString().Substring(0, 18) + "...";
                if (type == "Activity")
                {
                    noticeStyle(moticeList[i], "Activity");
                }
                else if (type == "Message")
                {
                    noticeStyle(moticeList[i], "Message");
                }
                else if (type == "Advice")
                {
                    noticeStyle(moticeList[i], "Advice");
                }

                NoticeInfo.ArticlelDList[i] = dr["ArticlelD"].ToString();
                NoticeInfo.titleParaList[i] = $"[{type}]{title}";
                NoticeInfo.posterParaList[i] = dr["PosterID"].ToString();
                //
                NoticeInfo.viewsParaList[i] = dr["Views"].ToString();
                NoticeInfo.likesParaList[i] = dr["Likes"].ToString();
                NoticeInfo.timeParaList[i] = dr["Time"].ToString();
                NoticeInfo.urlParaList[i] = dr["Url"].ToString();
            }


            dr.Close();
            conn.Close();

        }

        private void initShortcut()
        {

            if (User_type.user_deparment == "Receptionist")
            {
                shortcutButton1.Symbol = 62004;
                shortcutButton2.Symbol = 105;
                shortcutButton3.Symbol = 62144;
                shortcutButton1.SymbolSize = 28;
                shortcutButton2.SymbolSize = 24;
                shortcutButton3.SymbolSize = 26;
                shortcutText1.Text = "Register";
                shortcutText2.Text = "Receipt";
                shortcutText3.Text = "Profile";

            }
            else if (User_type.user_deparment == "Technician")
            {
                shortcutButton1.Symbol = 57397;
                shortcutButton2.Symbol = 61670;
                shortcutButton3.Symbol = 62144;
                shortcutButton1.SymbolSize = 24;
                shortcutButton2.SymbolSize = 30;
                shortcutButton3.SymbolSize = 26;
                shortcutText1.Text = "Requests";
                shortcutText2.Text = "Describe";
                shortcutText3.Text = "Profile";
            }
            else if (User_type.user_deparment == "Customer")
            {
                shortcutButton1.Symbol = 57397;
                shortcutButton2.Symbol = 61670;
                shortcutButton3.Symbol = 62144;
                shortcutButton1.SymbolSize = 24;
                shortcutButton2.SymbolSize = 30;
                shortcutButton3.SymbolSize = 26;
                shortcutText1.Text = "Requests";
                shortcutText2.Text = "Describe";
                shortcutText3.Text = "Profile";
            }
            else if (User_type.user_deparment == "Admin")
            {
                shortcutButton1.Symbol = 57608;
                shortcutButton2.Symbol = 57580;
                shortcutButton3.Symbol = 105;
                shortcutButton1.SymbolSize = 28;
                shortcutButton2.SymbolSize = 28;
                shortcutButton3.SymbolSize = 28;
                shortcutText1.Text = "Register";
                shortcutText2.Text = "Report";
                shortcutText3.Text = "Income";
            }
            
        }


        //stop right click
        public class MenuHandler : IContextMenuHandler
        {
            public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
            {
                model.Clear();
            }
            public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
            {
                return false;
            }
            public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
            {
            }
            public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
            {
                return false;
            }
        }
        
        
        private void InitializeChromeForMainLineChart()
        {
            /*if (User_type.loginStatus != "Login" || User_type.ifCefInit==false)
            {
                Console.WriteLine(User_type.ifCefInit.ToString());
                var setting = new CefSettings();
                setting.MultiThreadedMessageLoop = true;
                CefSharp.Cef.Initialize(setting);
            }*/
            string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + $"Html\\mainLineChart.html";
            WebBrowser = new ChromiumWebBrowser(path);
            WebBrowser.Dock = DockStyle.Fill;//铺满                                                                  
            WebBrowser.Dock = DockStyle.Fill;//设置停靠方式
            //WebBrowser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true; //交互数据
            WebBrowser.MenuHandler = new MenuHandler();//阻止右键
            this.lineChartPanel.Controls.Add(WebBrowser);

            //refreshlButton.PerformClick();

        }
        
        private async void refreshlButton_Click(object sender, EventArgs e)
        {
            Main.main.prepareData();
            await WebBrowser.GetBrowser().MainFrame.EvaluateScriptAsync("refresh()");
            
        }

        
        private void InitializeChromeForMainPieChart()
        {
            /* var setting1 = new CefSettings();
             setting1.MultiThreadedMessageLoop = true;
             CefSharp.Cef.Initialize(setting1);*/
            string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + $"Html\\mainPieChart.html";
            WebBrowser1 = new ChromiumWebBrowser(path);
            WebBrowser1.Dock = DockStyle.Fill;//铺满                                                                  
            WebBrowser1.Dock = DockStyle.Fill;//设置停靠方式
            //WebBrowser1.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true; //交互数据
            WebBrowser1.MenuHandler = new MenuHandler();//阻止右键
            this.pieChartPanel.Controls.Add(WebBrowser1);

            //refreshlButton.PerformClick();

        }
        
        private void CefinitStatus()
        {
            if (User_type.ifCefInit == false)
            {
                User_type.ifCefInit = true;
            }
        }
        
        private async void refreshlButton2_Click(object sender, EventArgs e)
        {
            Main.main.prepareData();
            await WebBrowser1.GetBrowser().MainFrame.EvaluateScriptAsync("refresh1()");
            
        }

        #region hover and leave color

        private void news_hover(object sender, EventArgs e)
        {
           

            if (sender.Equals(news1)) {
                news1.ForeColor = Color.FromArgb(51, 112, 255);
                newslabel1.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(news2))
            {
                news2.ForeColor = Color.FromArgb(51, 112, 255);
                newslabel2.ForeColor = Color.FromArgb(51, 112, 255);

            }
            else if (sender.Equals(news3))
            {
                news3.ForeColor = Color.FromArgb(51, 112, 255);
                newslabel3.ForeColor = Color.FromArgb(51, 112, 255);

            }
            else if (sender.Equals(news4))
            {
                news4.ForeColor = Color.FromArgb(51, 112, 255);
                newslabel4.ForeColor = Color.FromArgb(51, 112, 255);

            }
            else if (sender.Equals(news5))
            {
                news5.ForeColor = Color.FromArgb(51, 112, 255);
                newslabel5.ForeColor = Color.FromArgb(51, 112, 255);

            }
        }

        private void news_leave(object sender, EventArgs e)
        {

            

            if (sender.Equals(news1))
            {
                news1.ForeColor = newsFore;
                newslabel1.ForeColor = newsFore;
            }
            else if (sender.Equals(news2))
            {
                news2.ForeColor = newsFore;
                newslabel2.ForeColor = newsFore;
            }
            else if (sender.Equals(news3))
            {
                news3.ForeColor = newsFore;
                newslabel3.ForeColor = newsFore;
            }
            else if (sender.Equals(news4))
            {
                news4.ForeColor = newsFore;
                newslabel4.ForeColor = newsFore;
            }
            else if (sender.Equals(news5))
            {
                news5.ForeColor = newsFore;
                newslabel5.ForeColor = newsFore;
            }
        }

        private void InitNewsEvent()
        {
            dynamic[] newsObj = { news1 , news2, news3, news4, news5  };
            foreach (var item in newsObj)
            {
                item.MouseHover += new EventHandler(news_hover);
                item.MouseLeave += new EventHandler(news_leave);
            }
        }

        private void notice_hover(object sender, EventArgs e)
        {


            if (sender.Equals(noticeText1))
            {
                noticeText1.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(noticeText2))
            {
                noticeText2.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(noticeText3))
            {
                noticeText3.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(noticeText4))
            {
                noticeText4.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(noticeText5))
            {
                noticeText5.ForeColor = Color.FromArgb(51, 112, 255);
            }
        }

        private void notice_leave(object sender, EventArgs e)
        {



            if (sender.Equals(noticeText1))
            {
                noticeText1.ForeColor = newsFore;
            }
            else if (sender.Equals(noticeText2))
            {
                noticeText2.ForeColor = newsFore;
            }
            else if (sender.Equals(noticeText3))
            {
                noticeText3.ForeColor = newsFore;
            }
            else if (sender.Equals(noticeText4))
            {
                noticeText4.ForeColor = newsFore;
            }
            else if (sender.Equals(noticeText5))
            {
                noticeText5.ForeColor = newsFore;
            }
        }

        private void InitNoticeEvent()
        {
            dynamic[] newsObj = { noticeText1, noticeText2, noticeText3, noticeText4, noticeText5 };
            foreach (var item in newsObj)
            {
                item.MouseHover += new EventHandler(notice_hover);
                item.MouseLeave += new EventHandler(notice_leave);
            }
        }

        private void doc_hover(object sender, EventArgs e)
        {

            if (sender.Equals(doc1))
            {
                doc1.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(doc2))
            {
                doc2.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(doc3))
            {
                doc3.ForeColor = Color.FromArgb(51, 112, 255);
            }
            else if (sender.Equals(doc4))
            {
                doc4.ForeColor = Color.FromArgb(51, 112, 255);
            }
        }

        private void doc_leave(object sender, EventArgs e)
        {

            if (sender.Equals(doc1))
            {
                doc1.ForeColor = newsFore;
            }
            else if (sender.Equals(doc2))
            {
                doc2.ForeColor = newsFore;
            }
            else if (sender.Equals(doc3))
            {
                doc3.ForeColor = newsFore;
            }
            else if (sender.Equals(doc4))
            {
                doc4.ForeColor = newsFore;
            }
        }

        private void InitDocEvent()
        {
            dynamic[] newsObj = { doc1, doc2, doc3, doc4 };
            foreach (var item in newsObj)
            {
                item.MouseHover += new EventHandler(doc_hover);
                item.MouseLeave += new EventHandler(doc_leave);
            }
        }

     
        #endregion


        void initReader()
        {
            Reader readerInst= new Reader();
        }

        private void initArticleData(string type,int  no)
        {
            // create text and store in to js file
            //// para the argurment
            string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) +
                $"Html\\Articles\\script.js";
            string[] lines = System.IO.File.ReadAllLines(path);
            string[] parameter = { "titlePara", "posterPara", "staffpostPara", "viewsPara",
                "likesPara", "timePara", "urlPara", };
            dynamic[] positionParaTemp = { };
            if (type == "news")
            {
                //add 1 to views 
                string views = ArticlesInfo.viewsParaList[no];
                ArticlesInfo.viewsParaList[no] = (int.Parse(views) + 1).ToString();
                add1ToViewsOrLikesToDB("views");

                //store the no of newslab be clicked
                ArticlesInfo.currentnewsLablelD = no;
                dynamic[] positionPara = { ArticlesInfo.titleParaList, ArticlesInfo.posterParaList,
                        ArticlesInfo.staffpostParaList,ArticlesInfo.viewsParaList,
                        ArticlesInfo.likesParaList,ArticlesInfo.timeParaList,
                        ArticlesInfo.urlParaList,};
                positionParaTemp = positionPara;
            }
            else if(type == "notice"){
                //add 1 to views 
                string views = NoticeInfo.viewsParaList[no];
                NoticeInfo.viewsParaList[no] = (int.Parse(views) + 1).ToString();
                add1ToViewsOrLikesToDB("views");

                //Console.WriteLine(NoticeInfo.titleParaList[1]);// string obj

                //store the no of newslab be clicked
                NoticeInfo.currentnoticeLablelD = no;
                dynamic[] positionPara = { NoticeInfo.titleParaList, NoticeInfo.posterParaList,
                        NoticeInfo.staffpostParaList,NoticeInfo.viewsParaList,
                        NoticeInfo.likesParaList,NoticeInfo.timeParaList,
                        NoticeInfo.urlParaList,};
                positionParaTemp = positionPara;
            }
            
            
            for (int i = 0; i < parameter.Length; i++)
            {
                lines[i] = "let " + parameter[i] + $" = \"{positionParaTemp[i][no]}\";";
            }


            //empty old file
            FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite);
            fs.Close();
            //stor new to js file
            for (int i = 0; i < lines.Length; i++)
            {
                File.AppendAllText(path, lines[i] + Environment.NewLine);
            }

        }
        
        public  void readerShow(string type,int num)
        {
            if (type == "news")
            {
                ArticlesInfo.currentArticleType = "news";

                //init data
                initArticleData("news",num);

                //show lastest views to newLable
                dynamic[] newsLableList = { newslabel1, newslabel2, newslabel3, newslabel4, newslabel5 };
                newsLableList[num].Text = ArticlesInfo.viewsParaList[num];
                //store lastest to views in DB
                add1ToViewsOrLikesToDB("views");

                //accord to the url, open it
                string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"))
                    + $"Html\\Articles\\{ArticlesInfo.urlParaList[num]}";
                Reader.reader.WebBrowser2.Load(path);
                ArticlesInfo.currentArticlelD = ArticlesInfo.ArticlelDList[num];

                Thread.Sleep(100);
                Reader.reader.Show();
            }
            else if (type=="notice")
            {
                ArticlesInfo.currentArticleType = "notice";

                //init data
                initArticleData("notice", num);

                //store lastest to views in DB
                add1ToViewsOrLikesToDB("views");

                //accord to the url, open it
                string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"))
                    + $"Html\\Articles\\{NoticeInfo.urlParaList[num]}";
                Reader.reader.WebBrowser2.Load(path);
                NoticeInfo.currentArticlelD = NoticeInfo.ArticlelDList[num];

                Thread.Sleep(100);
                Reader.reader.Show();
            }
            
        }
        
        public static void add1ToViewsOrLikesToDB(string type)
        {
            string atrID = ArticlesInfo.currentArticlelD;
            string connStr = AppSetting.DBString;

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "";
            if (type=="views")
            {
                sql = $"update Articles set Views=Views+1 where ArticlelD='{atrID}';";
            }else if (type == "likes")
            {
                sql = $"update Articles set Likes=Likes+ 1 where ArticlelD='{atrID}';";
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public static void add1ToViewsOrLikesToDB(string Datatype,string aritcalTpye)
        {
            string atrID = "";
            string connStr = AppSetting.DBString;

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "";
            if (aritcalTpye == "news")
            {
                atrID = ArticlesInfo.currentArticlelD;
                sql = $"update Articles set Likes=Likes+ 1 where ArticlelD='{atrID}';";
            }
            else if(aritcalTpye == "notice")
            {
                atrID = NoticeInfo.currentArticlelD;
                sql = $"update Articles set Likes=Likes+ 1 where ArticlelD='{atrID}';";
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        #region newsButton Click event
        private void news1_Click(object sender, EventArgs e)
        {
            readerShow("news",0);
        }

        private void news2_Click(object sender, EventArgs e)
        {
            readerShow("news", 1);
        }

        private void news3_Click(object sender, EventArgs e)
        {
            readerShow("news", 2);
        }

        private void news4_Click(object sender, EventArgs e)
        {
            readerShow("news", 3);
        }

        private void news5_Click(object sender, EventArgs e)
        {
            readerShow("news", 4);
        }
        #endregion

        #region NoticeButton click event
        private void noticeText1_Click(object sender, EventArgs e)
        {
            readerShow("notice", 0);
        }

        private void noticeText2_Click(object sender, EventArgs e)
        {
            readerShow("notice", 1);
        }

        private void noticeText3_Click(object sender, EventArgs e)
        {
            readerShow("notice", 2);
        }

        private void noticeText4_Click(object sender, EventArgs e)
        {
            readerShow("notice", 3);
        }

        private void noticeText5_Click(object sender, EventArgs e)
        {
            readerShow("notice", 4);
        }
        #endregion

        #region document click event
        private void docShow(string docFileName)
        {
            string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"))
                + $"Html\\Document\\{docFileName}.html";
            Reader.reader.WebBrowser2.Load(path);
            Thread.Sleep(100);
            Reader.reader.Show();
        }
        private void doc1_Click(object sender, EventArgs e)
        {
            docShow("Doc000001");
        }
        

        private void doc2_Click(object sender, EventArgs e)
        {
            docShow("Doc000002");
        }

        private void doc3_Click(object sender, EventArgs e)
        {
            docShow("Doc000003");
        }

        private void doc4_Click(object sender, EventArgs e)
        {
            docShow("Doc000004");
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VideoPlayer videoPlayer = new VideoPlayer();
            videoPlayer.Show();
        }

        private void initNoticeDataToGlobal()
        {
            for (int i = 0; i < 5; i++)
            {
                string posterId = NoticeInfo.posterParaList[i];
                dynamic[] connTools2 = getDataReader($"SELECT Name, Post FROM Staff WHERE StaffID ='{posterId}'");
                SqlDataReader dr2 = connTools2[1];
                SqlConnection conn2 = connTools2[0];
                if (dr2.Read())
                {
                    NoticeInfo.posterParaList[i] = dr2["Name"].ToString();
                    NoticeInfo.staffpostParaList[i] = dr2["Post"].ToString();
                }
                dr2.Close();
                conn2.Close();

                //
            }
        }
        
        public void addUserControlToMain(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            Main.main.mainPanel.Controls.Clear();
            Main.main.mainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }
        
        private void shortcutButton1_Click(object sender, EventArgs e)
        {
            string type = shortcutText1.Text;
            if(type== "Register" )
            {
                UC_Registration uc = new UC_Registration();
                addUserControlToMain(uc);
                Main.main.currentMainPage = "UC_Registration";
            }
            else if (type == "Requests" )
            {
                UC_TaskList uc = new UC_TaskList();
                addUserControlToMain(uc);
                Main.main.currentMainPage = "UC_TaskList";
            }
        }

        private void shortcutButton2_Click(object sender, EventArgs e)
        {
            string type = shortcutText2.Text;
            if (type == "Receipt")
            {
                UC_Payment uc = new UC_Payment();
                addUserControlToMain(uc);
                Main.main.currentMainPage = "UC_Payment";
            }
            else if (type == "Describe")
            {
                UC_TaskCards uc = new UC_TaskCards();
                addUserControlToMain(uc);
                Main.main.currentMainPage = "UC_TaskCards";
            }
            else if (type == "Report")
            {
                UC_ServiceReport uc = new UC_ServiceReport();
                addUserControlToMain(uc);
                Main.main.currentMainPage = "UC_ServiceReport";
            }
        }

        private void shortcutButton3_Click(object sender, EventArgs e)
        {
            string type = shortcutText3.Text;
            if (type == "Profile")
            {
                UC_UserInfo uc = new UC_UserInfo();
                addUserControlToMain(uc);
                Main.main.currentMainPage = "UC_UserInfo";
            }
            else if (type == "Income")
            {
                UC_IncomeAnalysis uc = new UC_IncomeAnalysis();
                addUserControlToMain(uc);
                Main.main.currentMainPage = "UC_IncomeAnalysis";
            }
        }

        private void ratioLabel_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Order ratio of each service in this month", ratioLabel);
        }


        private void readMoreNews_Click(object sender, EventArgs e)
        {
            string path = AppSetting.path + "\\Html\\Articles\\newsMore.html";
            Reader.reader.WebBrowser2.Load(path);

            Thread.Sleep(100);
            Reader.reader.Show();
        }

        private void readMoreNotice_Click(object sender, EventArgs e)
        {
            string path = AppSetting.path + "\\Html\\Articles\\noticeMore.html";
            Reader.reader.WebBrowser2.Load(path);

            Thread.Sleep(100);
            Reader.reader.Show();
        }

        private void readMoreDoc_Click(object sender, EventArgs e)
        {
            string path = AppSetting.path + "\\Html\\Document\\docMore.html";
            Reader.reader.WebBrowser2.Load(path);

            Thread.Sleep(100);
            Reader.reader.Show();
        }
    }

    class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
        //throw new MyException("Sql statement has mistakes");
    }
}
