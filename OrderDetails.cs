﻿using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniSys0._3
{
    public partial class OrderDetails : UIForm
    {
        private string orderIDCache;

        public OrderDetails()
        {
            InitializeComponent();
            InitTheme();
        }
        private void InitTheme()
        {
            line1.BackColor = Color.Transparent; 
            line2.BackColor = Color.Transparent;
            line3.BackColor = Color.Transparent;
            line1.FillColor = Color.Transparent;
            line2.FillColor = Color.Transparent;
            line3.FillColor = Color.Transparent;
            line1.LineColor = Color.FromArgb(22, 93, 255);
            line2.LineColor = Color.FromArgb(22, 93, 255);
            line3.LineColor = Color.FromArgb(22, 93, 255);

            finishBtn.FillColor = Color.FromArgb(22,93,255);
            finishBtn.FillHoverColor = Color.FromArgb(64, 18, 255);
            finishBtn.FillPressColor = Color.FromArgb(64, 18, 255);
            delectBtn.RectColor = Color.Transparent;


            delectBtn.FillColor = Color.FromArgb(245,63,63);
            delectBtn.FillHoverColor = Color.FromArgb(247,101,96);
            delectBtn.FillPressColor = Color.FromArgb(247, 101, 96);
            finishBtn.RectColor = Color.Transparent;

            if (User_type.user_theme == "dark")
            {
                this.BackColor = Color.FromArgb(18, 31, 43);
                TitleColor = Color.FromArgb(28, 47, 70);
                TitleForeColor = Color.White;
                ControlBoxForeColor = Color.White;
                rectColor = Color.FromArgb(55, 55, 57);
                /*uiLine2.LineColor = Color.FromArgb(55, 55, 57);
                textBox.FillColor = Color.FromArgb(55, 55, 57);*/


                dynamic[] lable = { uiLabel20, uiLabel1, orderID, uiLabel2, receptionist, uiLabel7, 
                    technician, uiLabel8, model, uiLabel3, receiveTime, uiLabel4, serviceType, 
                    uiLabel5, status, status4, status4Time, status3, status3Time, status2,uiLabel19,
                    status2Time, status1, status1Time, uiLabel21, uiLabel22, name, uiLabel25, 
                    country, uiLabel23, phone, uiLabel26, address, uiLabel24, 
                    email, uiLabel27, regtime };
                foreach (var item in lable)
                {
                    item.ForeColor = Color.White;
                }

                dynamic[] contaners = { uiUserControl1, uiUserControl2, uiUserControl3 };
                foreach (var item in contaners)
                {
                    item.BackColor = Color.FromArgb(55, 55, 57);
                    item.FillColor = Color.FromArgb(55, 55, 57);
                    item.RectColor = Color.Transparent;
                }
            }
        }
        private void ifDeleteShow()
        {
            finishBtn.Hide();
            delectBtn.Hide();

            if (User_type.user_deparment == "Receptionist" && ifLastOrderFinish() != true)
            {
                delectBtn.Show();
            }
            if (User_type.user_deparment == "Technician" && ifLastOrderFinish() != true)
            {
                finishBtn.Show();
            }
        }
        
        private bool ifLastOrderFinish()
        {
            string sql = $"Select * FROM Schedule Where OrderID = '{orderIDCache}'";
            dynamic[] data = SQLCursor.Query(sql);
            if (data.Length == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Init(string orderId)
        {
            // order info
            orderID.Text = orderId;
            orderIDCache = orderId;
            dynamic[] data = SQLCursor.Query("select Orders.Model, Customer.Name,Service.Type,Orders.Time ,Staff.Name " +
                "From Orders " +
                "Inner Join Customer On Customer.CustomerID = Orders.CustomerID  " +
                "Inner join Service On Service.ServiceID = Orders.Service_type  " +
                "Inner join Staff On Staff.StaffID = Orders.ReceptionistID  " +
                $"Where OrderID = '{orderId}';");

            receptionist.Text = data[4];
            model.Text = data[0];
            receiveTime.Text = data[3];
            serviceType.Text = data[2];
            string customerName = data[1];

            if (SQLCursor.ifCurrentOrderNotStart(orderId))
            {
                // order staff
                dynamic[] data2 = SQLCursor.Query($"select TOP 1  Schedule.Status" +
                $" From Schedule " +
                $"Where OrderID ='{orderId}' Order by Time DESC");
                technician.Text = "None";
                status.Text = statusStr(data2[0]);
                //Console.WriteLine(statusStr(data2[1]));
            }
            else
            {
                // order staff
                dynamic[] data2 = SQLCursor.Query($"select TOP 1 Staff.Name,Schedule.Status" +
                $" From Schedule " +
                $"Inner join Staff On Staff.StaffID = Schedule.TechnicianID " +
                $"Where OrderID ='{orderId}' Order by Time DESC");
                technician.Text = data2[0];
                status.Text = statusStr(data2[1]);
                //Console.WriteLine(statusStr(data2[1]));
            }
            
            
            // customer info
            initCusInfo(customerName);

            ifDeleteShow();
        }

        private string statusStr(string status)
        {
            if (status =="Order")
            {
                line1.LineColor = Color.FromArgb(242, 243, 245);
                line2.LineColor = Color.FromArgb(242, 243, 245);
                line3.LineColor = Color.FromArgb(242, 243, 245);
                dot1.FillColor = Color.FromArgb(64, 128, 255);
                dot2.FillColor= Color.FromArgb(242, 243, 245);
                dot3.FillColor = Color.FromArgb(242, 243, 245);
                dot4.FillColor = Color.FromArgb(242, 243, 245);

                status2.Visible = false;
                status2Time.Visible = false;
                status3.Visible = false;
                status3Time.Visible = false;
                status4.Visible = false;
                status4Time.Visible = false;

                status1Time.Text = getTime("Order");

                return "Accept order";
            }
            else if (status == "Progress")
            {

                line2.LineColor = Color.FromArgb(242, 243, 245);
                line3.LineColor = Color.FromArgb(242, 243, 245);
                dot1.FillColor = Color.FromArgb(64, 128, 255);
                dot2.FillColor = Color.FromArgb(64, 128, 255);
                dot3.FillColor = Color.FromArgb(242, 243, 245);
                dot4.FillColor = Color.FromArgb(242, 243, 245);

                status3.Visible = false;
                status3Time.Visible = false;
                status4.Visible = false;
                status4Time.Visible = false;

                status1Time.Text = getTime("Order");
                status2Time.Text = getTime("Progress");

                return "Start repairing";
            }
            else if (status == "Completed")
            {

                line3.LineColor = Color.FromArgb(242, 243, 245);
                dot1.FillColor = Color.FromArgb(64, 128, 255);
                dot2.FillColor = Color.FromArgb(64, 128, 255);
                dot3.FillColor = Color.FromArgb(64, 128, 255);
                dot4.FillColor = Color.FromArgb(242, 243, 245);

                status4.Visible = false;
                status4Time.Visible = false;

                status1Time.Text = getTime("Order");
                status2Time.Text = getTime("Progress");
                status3Time.Text = getTime("Completed");


                return "Complete repair";
            }
            else if (status == "Finished")
            {
                status1Time.Text = getTime("Order");
                status2Time.Text = getTime("Progress");
                status3Time.Text = getTime("Completed");
                status4Time.Text = getTime("Finished");

                dot1.FillColor = Color.FromArgb(64, 128, 255);
                dot2.FillColor = Color.FromArgb(64, 128, 255);
                dot3.FillColor = Color.FromArgb(64, 128, 255);
                dot4.FillColor = Color.FromArgb(64, 128, 255);
                return "Order finish";
            }
            else
            {
                return null;
            }
        }

        private string getTime(string type)
        {
            if (type == "Order")
            {
                string time =  SQLCursor.Query("Select  TOP 1 Time from Schedule Where " +
                    $"OrderID ='{orderIDCache}' " +
                    "And Status = 'Order';")[0];

                return time;
            }
            else if (type == "Progress")
            {
                string time = SQLCursor.Query("Select TOP 1 Time from Schedule Where " +
                                    $"OrderID ='{orderIDCache}' " +
                                    "And Status = 'Progress';")[0];

                return time;
            }
            else if (type == "Completed")
            {

                string time = SQLCursor.Query("Select  TOP 1 Time from Schedule Where " +
                                    $"OrderID ='{orderIDCache}' " +
                                    "And Status = 'Completed';")[0];

                return time;
            }
            else if (type == "Finished")
            {
                string time = SQLCursor.Query("Select TOP 1 Time from Schedule Where " +
                    $"OrderID ='{orderIDCache}' " +
                    "And Status = 'Finished';")[0];

                return time;
            }
            else
            {
                return null;
            }
        }
        
        private void initCusInfo(string cusName)
        {
            dynamic[] data = SQLCursor.Query(" select Phone_number,Email,Country,Address,Regtime From Customer " +
                $"Where Name = '{cusName}';");
            name.Text = cusName;
            phone.Text = data[0];
            email.Text = data[1];
            country.Text = data[2];
            address.Text = data[3];
            regtime.Text = data[4];
        }

        private void delectBtn_Click(object sender, EventArgs e)
        {

            DialogResult Asterisk = System.Windows.Forms.MessageBox.Show("Do you want delete this order?",
                                 "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (Asterisk == DialogResult.OK)
            {
                string sql = $"DELETE FROM Orders WHERE OrderID ='{orderIDCache}'" +
                   $"DELETE FROM Schedule WHERE OrderID ='{orderIDCache}'";

                NotificationForm messageBoxForm = new NotificationForm("success", "Delete successfully");
                messageBoxForm.ShowDialog();
            }
               
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            //orderIDCache
            string sql = $"SELECT Price FROM Orders WHERE  OrderID  = '{orderIDCache}';";
            dynamic[] data = SQLCursor.Query(sql);

            string CurrentPrice = data[0];

            string ServicePrice = SQLCursor.GetServicePriceFromOrderID(orderIDCache);

            if (CurrentPrice == ServicePrice)
            {
                closedTheOrder();
            }
            else
            {
                DialogResult Asterisk = System.Windows.Forms.MessageBox.Show($"Service type and price do not match.\n\r Payable: {ServicePrice}, paid: {CurrentPrice}.\n\r Are you sure you want to end the order?",
                                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (Asterisk == DialogResult.OK)
                {
                    

                    closedTheOrder();
                }
            }
        }

        private void closedTheOrder()
        {
            if (SQLCursor.ifCurrentOrderFinishRepair(orderIDCache))
            {
                string sql1 = "Select Top 1 TechnicianID From Schedule " +
                    $"Where OrderID = '{orderIDCache}'";
                Console.WriteLine(sql1);
                string technicianID = SQLCursor.Query(sql1)[0];

                string time = DateTime.Now.ToString();
                string ScheduleID = SQLCursor.AddOneToLastID("ScheduleID", "Schedule");

                string sql2 = $"INSERT INTO Schedule VALUES('{ScheduleID}','Finished','{time}'," +
                    $"'{technicianID}','{orderIDCache}');";
                SQLCursor.Execute(sql2);


                NotificationForm messageBoxForm = new NotificationForm("success", "Finish successfully");
                messageBoxForm.ShowDialog();

                Init(orderIDCache);

                line3.LineColor = Color.FromArgb(22, 93, 255);
            }
            else
            {
                NotificationForm messageBoxForm = new NotificationForm("warning", "This order has not been repaired, cannot be finished.");
                messageBoxForm.ShowDialog();
            }
            
        }
    }
    
         
}
