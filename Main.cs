﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using miniSys0._3.Controls;
using System.IO;
using miniSys0._3.Controls.MainArea;
using CefSharp.WinForms;
using miniSys0._3.Controls.Navmenu;

namespace miniSys0._3
{

    public partial class Main : Form
    {
        public static Main main;
        public Main()
        {
            InitializeComponent();
            main = this;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitCef();
            InitProfile();
            InitReader();
            InitTheme();

            Init_search_box();


            //left bat
            addNavMenu();
            searchBox.Hide();
            //topbar
            randomLogoColor();

            //insert data to js to prepare first time load
            prepareData();

            // main area loading

            add_UC_Mainto_Panel();
            //add_UC_UserInfo();
            //add_UC_UserSetting();
            //add_UC_registration();
            //add_UC_Payment();
            //add_task_cards();
            //add_task_table();
            //add_Cus_OrderDetails();
            //add_UC_ServiceReport();
            //add_UC_IncomeAnalysis();
            //add_UC_Cus_dashboard();



        }
        Point mPoint;
        private void InitCef()
        {
            var setting = new CefSettings();
            setting.MultiThreadedMessageLoop = true;
            CefSharp.Cef.Initialize(setting);
        }

        private void InitTheme()
        {
            if (User_type.user_theme == "dark")
            {
                this.BackColor = Color.FromArgb(18, 31, 43);
                panelTop.BackColor = Color.FromArgb(28, 47, 70);
                label1.ForeColor = Color.White;
                uiUserControl1.BackColor = Color.FromArgb(28, 47, 70);
                uiUserControl1.FillColor = Color.FromArgb(28, 47, 70);
                uiUserControl1.RectColor = Color.FromArgb(28, 47, 70);
                copyRight.ForeColor = Color.FromArgb(22, 93, 255);

                //uiUserControl2.BackColor = Color.FromArgb(28, 47, 70);
                navMenuPanel.BackColor = Color.FromArgb(28, 47, 70);
            }
            else if (User_type.user_theme == "light")
            {
                this.BackColor = Color.FromArgb(247, 248, 250);
                panelTop.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                uiUserControl1.BackColor = Color.White;
                uiUserControl1.FillColor = Color.White;
                uiUserControl1.RectColor = Color.Gainsboro;
                copyRight.ForeColor = Color.Black;

                //uiUserControl2.BackColor = Color.FromArgb(28, 47, 70);
                navMenuPanel.BackColor = Color.White;
            }
        }
        private void InitReader()
        {
            Reader reader = new Reader();
        }
        private void InitProfile()
        {
            this.profile.Text = User_type.user_name.Substring(0, 1);
            searchBox.Visible = false;
        }
        private void drag_down(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void drag_move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);

                if (uniqueInstance != null)
                {
                    uniqueInstance.Location = new Point(this.Location.X + 1080 + e.X - mPoint.X, this.Location.Y + 68 + e.Y - mPoint.Y);
                }
            }
            
        }
        private static FormFloating uniqueInstance;
        private void profile_Click(object sender, EventArgs e)
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new FormFloating();
                int PositionX = this.Location.X;
                int PositionY = this.Location.Y;
                uniqueInstance.StartPosition = FormStartPosition.Manual;
                uniqueInstance.Location = (Point)new Size(PositionX + 1080, PositionY + 68);
                uniqueInstance.Show();
            }
            else
            {
                uniqueInstance.Close();
                uniqueInstance = null;
            }

        }



        private void searchIcon_Click(object sender, EventArgs e)
        {
            searchBox.RectColor = Color.FromArgb(187, 191, 196);
            if (searchBox.Visible && searchBox.Text == "")
            {
                searchBox.Visible = false;
                searchBox_instance.Visible = false;
                empty_search_box_content();

            }
            else if (searchBox.Visible && searchBox.Text == "Type here to search")
            {
                searchBox.Visible = false;
                searchBox_instance.Visible = false;
                empty_search_box_content();
            }
            else if(!searchBox.Visible)
            {
                searchBox.Visible = true;
                searchBox.Focus();
                show_search();
            }
            
        }
        private void empty_search_box_content()
        {
            SearchBox.Instance.uiLabel1.Text = "Go to page";
            SearchBox.Instance.uiLabel4.Text = "Search customer:" ;
            SearchBox.Instance.uiLabel2.Text = "Search staff:"  ;
            SearchBox.Instance.uiLabel3.Text = "Search order:" ;
        }

        private void search_enter(object sender, EventArgs e)
        {
            searchBox.Text = "";
            show_search();
        }

        private void search_leave(object sender, EventArgs e)
        {
            searchBox.Text = "Type here to search";
        }
        private SearchBox searchBox_instance = null;
        private void Init_search_box()
        {
            SearchBox searchBoxForm = new SearchBox();
            searchBox_instance = searchBoxForm;
        }

        private void show_search()
        {
            int PositionX = this.Location.X;
            int PositionY = this.Location.Y;
            searchBox_instance.StartPosition = FormStartPosition.Manual;
            searchBox_instance.Location = (Point)new Size(PositionX + 615, PositionY + 50);
            searchBox_instance.Visible = true;    
        }


        /*void addIcon()
        {
            for (int i = 0; i < receptionistNavMenu.Nodes.Count; i++)
            {
                receptionistNavMenu.ImageList = receptionistNavMenuImageList;
                if (i == 0)
                {
                    //NavMenu.Nodes[i].Text = "\ue901";
                    receptionistNavMenu.Nodes[i].ImageIndex = 0;
                    //NavMenu.Nodes[i].NodeFont = new Font(IconfontHelper.PFCC.Families[0], 15);
                }
            }

            label33.Text = "\ue902 Dashboard";
            label33.Font = new Font(IconfontHelper.PFCC.Families[0], 20);


            foreach (TreeNode item in NavMenu.Nodes)
            {
                item.Text = "lala";
            }
        }*/


        private void node_click(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                /*if (e.Node.Level == 0)
                {
                    //e.Node.Text = "<span style ='color:red'>lalala</span>";
                    //ForeColor = Color.Red;
                    //e.Node.ForeColor = Color.Red;
                    MessageBox.Show(e.Node.Text);
                }*/
                if (e.Node.Level == 1)                              
                {

                    //MessageBox.Show(e.Node.Parent.Text);
                    //e.Node.Parent.Text = "laaa";
                }
            }
        }
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            navMenuPanel.Controls.Clear();
            navMenuPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void addNavMenu()
        {
            /*UC_Test uc = new UC_Test();
            addUserControl(uc);*/


            if (User_type.user_deparment == "Receptionist")
            {
                UC_R_Navmenu uc = new UC_R_Navmenu();
                addUserControl(uc);
            }
            else if (User_type.user_deparment == "Technician")
            {
                UC_T_Navmenu uc = new UC_T_Navmenu();
                addUserControl(uc);
            }
            else if (User_type.user_deparment == "Customer")
            {
                UC_C_Navmenu uc = new UC_C_Navmenu();
                addUserControl(uc);
            }
            else if (User_type.user_deparment == "Admin")
            {
                UC_A_Navmenu uc = new UC_A_Navmenu();
                addUserControl(uc);
            }

        }

        

        void initShortcut()
        {
            /*void addUserControl(UserControl userControl)
            {
                userControl.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(userControl);
                userControl.BringToFront();
            }*/

            /*if (User_type.user_type == "Receptionist")
            {
                UC_R_Shortcut uc = new UC_R_Shortcut();
                addUserControl(uc);
            }
            else if (User_type.user_type == "Technician")
            {
                UC_T_Shortcut uc = new UC_T_Shortcut();
                addUserControl(uc);
            }
            else if (User_type.user_type == "Customer")
            {
                UC_C_Shortcut uc = new UC_C_Shortcut();
                addUserControl(uc);
            }
            else if (User_type.user_type == "Admin")
            {
                UC_A_Shortcut uc = new UC_A_Shortcut();
                addUserControl(uc);
            }
*/
        }
        void randomLogoColor()
        {
            Color[] colorListR = { //6

                ColorTranslator.FromHtml("#F53F3F") , //red
                ColorTranslator.FromHtml("#F77234") , //orange
                ColorTranslator.FromHtml("#FF7D00") , //orange
                //pink
                ColorTranslator.FromHtml("#551DB0") ,
                ColorTranslator.FromHtml("#B010B6"),
                ColorTranslator.FromHtml("#F5319D") ,
             };
            Color[] colorListG = { //5

                //yellow
                ColorTranslator.FromHtml("#9FDB1D"), //yellow
                ColorTranslator.FromHtml("#FADC19") , //yellow
                //green
                ColorTranslator.FromHtml("#FF0000"), //green
                ColorTranslator.FromHtml("#00B42A") , //green
                ColorTranslator.FromHtml("#14C9C9"), //green

                //grey
                ColorTranslator.FromHtml("#86909C")
            };
            Color[] colorListB = { //2

                //blue
                ColorTranslator.FromHtml("#3491FA") ,
                ColorTranslator.FromHtml("#0E42D2"),
            };


            dynamic[] colorList2D = { colorListR , colorListG, colorListB };

            int checkNum(int num)
            {
                int maxNum = -1;
                if (num == 0 || num == 1)
                {
                    maxNum = 6;
                }
                else
                {
                    maxNum = 2;
                }
                return maxNum;
            }

            //LogoFore
            int randomNumber1;
            int randomNumber2;

            Random r1 = new Random();
            randomNumber1 = r1.Next(0, 2);

            Random r2 = new Random();
            randomNumber2 = r2.Next(1, checkNum(randomNumber1));

            User_type.LogoFore = colorList2D[randomNumber1][randomNumber2];

            //LogoBkg
            int randomNumber3;
            int randomNumber4;
            while (true)
            {
                Random r3 = new Random();
                randomNumber3 = r3.Next(0, 2);

                if (randomNumber3!= randomNumber1)
                {
                    break;
                }
            }
            Random r4 = new Random();
            randomNumber4 = r4.Next(1, checkNum(randomNumber3));

            User_type.LogoBkg = colorList2D[randomNumber3][randomNumber4];

            profile.ForeColor = User_type.LogoFore;
            profile.FillColor = User_type.LogoBkg;
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void writeDataToJsFIle(string type, List<int> parameter)
        {
            string fileName = "";
            string Content = "dataset = [";
            if (type == "lineChart")
            {
                fileName = "parameterForLineChart.js";
                for (int i = 6; i >=0; i--)
                {
                    string part = $"{{x: {i + 1},y: {parameter[i]}}},";
                    Content += part;
                }
            } 
            else if (type == "pieChart")
            {
                fileName = "parameterForPieChart.js";
                for (int i = 0; i < parameter.Count; i++)
                {
                    Content += $"{parameter[i]},";
                }
            }
            Content += "]";

            if (User_type.user_theme == "dark")
            {
                Content += "; theme = 'dark';";
            }
            else
            {
                Content += "; theme = 'light';";
            }

            string path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + $"Html\\{fileName}";
            //empty old js file
            FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite);
            fs.Close();
            // add new 
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true, System.Text.Encoding.Default);
            sw.Write(Content);
            sw.Close();
            sw.Dispose();
        }

        private void prepareData()
        {
            List<int> weekOrderNum = UC_main.getOneWeekOrderNum();
            List<int> monthOrderNRatio = UC_main.getOnemonthratio();
            writeDataToJsFIle("lineChart",weekOrderNum);
            writeDataToJsFIle("pieChart",monthOrderNRatio);
        }

        #region
        public string currentMainPage;

        private void addUserControlToMain(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public void add_UC_Mainto_Panel()
        {

            if (User_type.user_deparment == "Customer")
            {
                UC_Cus_dashboard uc = new UC_Cus_dashboard();
                addUserControlToMain(uc);
            }
            else
            {
                UC_main uc = new UC_main();
                addUserControlToMain(uc);
            }
            currentMainPage = "UC_main";
        }

        public void  add_UC_UserInfo()
        {
            UC_UserInfo uc = new UC_UserInfo();
            addUserControlToMain(uc);
            currentMainPage = "UC_UserInfo";
        }

        public void add_UC_UserSetting()
        {
            UC_UserSetting uc = new UC_UserSetting();
            addUserControlToMain(uc);
            currentMainPage = "UC_UserSetting";
        }
        public void add_UC_registration()
        {
            UC_Registration uc = new UC_Registration();
            addUserControlToMain(uc);
            currentMainPage = "UC_Registration";
        }
        public void add_UC_Payment()
        {
            UC_Payment uc = new UC_Payment();
            addUserControlToMain(uc);
            currentMainPage = "UC_Payment";
        }

        public void  add_task_cards()
        {
            UC_TaskCards uc = new UC_TaskCards();
            addUserControlToMain(uc);
            currentMainPage = "UC_TaskCards";
        }

        public void add_Cus_OrderDetails()
        {
            UC_Cus_OrderDetails uc = new UC_Cus_OrderDetails();
            addUserControlToMain(uc);
            currentMainPage = "UC_Cus_OrderDetails";
        }

        public void add_UC_ServiceReport()
        {
            UC_ServiceReport uc = new UC_ServiceReport();
            addUserControlToMain(uc);
            currentMainPage = "UC_ServiceReport";
        }

        public void add_UC_IncomeAnalysis()
        {
            UC_IncomeAnalysis uc = new UC_IncomeAnalysis();
            addUserControlToMain(uc);
            currentMainPage = "UC_IncomeAnalysis";
        }

        public void add_UC_Cus_dashboard()
        {
            UC_Cus_dashboard uc = new UC_Cus_dashboard();
            addUserControlToMain(uc);
            currentMainPage = "UC_Cus_dashboard";
        }

        public void add_task_table()
        {
            UC_TaskList uc = new UC_TaskList();
            addUserControlToMain(uc);
            currentMainPage = "UC_TaskList";
        }
        #endregion

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            if (User_type.user_theme == "light")
            {
                User_type.user_theme = "dark";
                prepareData();
                InitTheme();
                lodaNewMainPage(currentMainPage);
                addNavMenu();
                InitOtherPageTheme();
            }
            else if (User_type.user_theme == "dark")
            {
                User_type.user_theme = "light";
                prepareData();
                InitTheme();
                lodaNewMainPage(currentMainPage);
                addNavMenu();
                InitOtherPageTheme();
            } 
        }
        public bool ifViewProfileExist = false;
        private void InitOtherPageTheme()
        {
            SearchBox.Instance.InitTheme();

            if (ifViewProfileExist)
            {
                ViewProfile.Instance.InitTheme();
            }
        }
        
        private void lodaNewMainPage(string currentControlStr)
        {
            Console.WriteLine(currentControlStr);
            if (currentControlStr == ("UC_main"))
            {
                add_UC_Mainto_Panel();
            }
            else if(currentControlStr == ("UC_UserInfo"))
            {
                add_UC_UserInfo();
            }
            else if (currentControlStr == ("UC_UserSetting"))
            {
                add_UC_UserSetting();
            }
            else if (currentControlStr == ("UC_Registration"))
            {
                add_UC_registration();

            }
            else if (currentControlStr == ("UC_Payment"))
            {
                add_UC_Payment();
            }
            else if (currentControlStr == ("UC_TaskCards"))
            {
                add_task_cards();
            }
            else if (currentControlStr == ("UC_Cus_OrderDetails"))
            {
                add_Cus_OrderDetails();
            }
            else if (currentControlStr == ("UC_ServiceReport"))
            {
                add_UC_ServiceReport();

            }
            else if (currentControlStr == ("UC_IncomeAnalysis"))
            {
                add_UC_IncomeAnalysis();
            }
            else if (currentControlStr == ("UC_Cus_dashboard"))
            {
                add_UC_Cus_dashboard(); 
            }
            else if (currentControlStr == ("UC_TaskList"))
            {
                add_task_table();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            searchBox.RectColor = Color.FromArgb(187, 191, 196);
            if (!searchBox_instance.Visible )
            {
                searchBox_instance.Visible = true;
            }
            if (searchBox.Text!= "Type here to search")
            {
                SearchBox.Instance.uiLabel1.Text = "Go to page: " + searchBox.Text;
                SearchBox.Instance.uiLabel2.Text = "Search customer: " + searchBox.Text;
                SearchBox.Instance.uiLabel3.Text = "Search staff: " + searchBox.Text;
                SearchBox.Instance.uiLabel4.Text = "Search order: " + searchBox.Text;
            }
            
        }
    }


}
