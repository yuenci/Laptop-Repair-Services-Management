﻿using miniSys0._3.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sunny.UI.UIAvatar;

namespace miniSys0._3.Controls.MainArea
{
    public partial class UC_UserInfo : UserControl
    {
        public UC_UserInfo()
        {
            InitializeComponent();

            InitUserInfoBar();
            InitDeviceCard();
            InitTheme();
            string[] staffIDArray = { "Sta000001", "Sta000004", "Sta000037", "Sta000063" };
            InitRlatedStaff(staffIDArray);
            setAvatar();

            uiAvatar1.Visible = false;
            InitAvatar();

        }


        public void InitTheme()
        {
            if (User_type.user_deparment =="Customer")
            {
                ButtonUserPost.Visible = false;
                ButtonUserDepart.Visible = false;
                ButtonUserCoutry.Visible = false;
            }

            if (User_type.user_theme == "dark")
            {
                this.BackColor = Color.FromArgb(28, 47, 70);
                uiUserControl1.FillColor = Color.FromArgb(28, 47, 70);
                uiUserControl3.FillColor = Color.FromArgb(28, 47, 70);
                uiUserControl1.RectColor = Color.FromArgb(55, 55, 57);
                uiUserControl3.RectColor = Color.FromArgb(55, 55, 57);
                uiUserControl4.FillColor = Color.FromArgb(28, 47, 70);

                dynamic[] lable = { label1 , label2};
                foreach (var item in lable)
                {
                    item.ForeColor = Color.White;
                }

                uC_StaffCard11.BackColor = Color.FromArgb(55, 55, 57);
                uC_StaffCard12.BackColor = Color.FromArgb(55, 55, 57);
                uC_StaffCard13.BackColor = Color.FromArgb(55, 55, 57);
                uC_StaffCard14.BackColor = Color.FromArgb(55, 55, 57);
            }
        }

        private void InitUserInfoBar()
        {
            picContainer.FillColor = User_type.LogoBkg;
            Console.WriteLine(User_type.user_ID);
            UserFirstLeeter.Text = User_type.user_name.Substring(0, 1);
            UserFirstLeeter.ForeColor = User_type.LogoFore;

            ButtonEditPhoto.Parent = pictureBg;
            ButtonEditPhoto.Location = new Point(615, 82);
            LableUsername.Parent = pictureBg;
            LableUsername.Location = new Point(523, 115);
            LableUsername.Text = User_type.user_name;

            if (User_type.user_deparment != "Customer")
            {
                ButtonUserPost.FillColor = Color.Transparent;
                ButtonUserDepart.FillColor = Color.Transparent;
                ButtonUserCoutry.FillColor = Color.Transparent;
                ButtonUserPost.RectDisableColor = Color.Transparent;
                ButtonUserDepart.RectDisableColor = Color.Transparent;
                ButtonUserCoutry.RectDisableColor = Color.Transparent;

                ButtonUserPost.Text = User_type.user_post;
                ButtonUserPost.Parent = pictureBg;
                ButtonUserPost.Location = new Point(250, 150);

                ButtonUserDepart.Text = User_type.user_deparment;
                ButtonUserDepart.Parent = pictureBg;
                ButtonUserDepart.Location = new Point(490, 150);     

                ButtonUserCoutry.Text = User_type.user_Country;
                ButtonUserCoutry.Parent = pictureBg;
                ButtonUserCoutry.Location = new Point(660, 150);
            }
        }
        
        private void InitDeviceCard()
        {
            this.macLabel.Parent = this.pictureBoxMacbook;
            macLabel.Location = new Point(55, 25);

            this.iphonrLabel.Parent = this.pictureBoxIphone;
            iphonrLabel.Location = new Point(55, 25);

            ButtonEdit1.Parent = this.pictureBoxIphone;
            ButtonEdit1.Location = new Point(30, 180);
            ButtonEdit2.Parent = this.pictureBoxMacbook;
            ButtonEdit2.Location = new Point(30, 180);
            buttonGarbage1.Parent = this.pictureBoxIphone;
            buttonGarbage1.Location = new Point(150, 180);
            buttonGarbage2.Parent = this.pictureBoxMacbook;
            buttonGarbage2.Location = new Point(150, 180);

            ButtonEdit1.Hide();
            ButtonEdit2.Hide();
            buttonGarbage1.Hide();
            buttonGarbage2.Hide();

            
        }
        
        
        private void InitRlatedStaff(string[] stuffArry)
        {
            if (stuffArry.Length != 4)
            {
                throw new MyException("staff number has mistake");
            }

            uC_StaffCard11.pictureHead.Image = Resources.head1;
            uC_StaffCard12.pictureHead.Image = Resources.head2;
            uC_StaffCard13.pictureHead.Image = Resources.head3;
            uC_StaffCard14.pictureHead.Image = Resources.head4;

            dynamic[] staffCardObjArray = { uC_StaffCard11, uC_StaffCard12, uC_StaffCard13, uC_StaffCard14 };

            //staffNameLable
            //deparNameLable

            string allsql = "";
            for (int i = 0; i < 4; i++)
            {
                var sqlpart = $"select Name,Post from Staff where StaffID = '{stuffArry[i]}';";
                allsql += sqlpart;
            }
            dynamic[] connTools2 = UC_main.getDataReader(allsql);
            SqlDataReader dr2 = connTools2[1];
            SqlConnection conn2 = connTools2[0];
            int ii = 0;
            do
            {
                dr2.Read();
                staffCardObjArray[ii].nameLabel.Text = dr2["Name"].ToString();
                staffCardObjArray[ii].postLabel.Text = dr2["Post"].ToString();
                ii++;

            }
            while (dr2.NextResult()); //next method
            dr2.Close();
            conn2.Close();
        }
        

        #region Phone and Mac card init
        private void phone_hover(object sender, EventArgs e)
        {
            ButtonEdit1.Show();
            buttonGarbage1.Show();
        }

        
        private async void phone_leave(object sender, EventArgs e)
        {
            var result = sleepForms(3000);
            string rrr = await result;
            ButtonEdit1.Hide();
            buttonGarbage1.Hide();
        }

        
        private async void macCard_leave(object sender, EventArgs e)
        {
            var result = sleepForms(3000);
            string rrr = await result;
            ButtonEdit2.Hide();
            buttonGarbage2.Hide();
        }

        
        private Task<string> sleepForms(int ms)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(ms);
                return "";
            });

            return task;
        }


        private void mac_hover(object sender, EventArgs e)
        {
            ButtonEdit2.Show();
            buttonGarbage2.Show();
        }


        private async void mac_leave(object sender, EventArgs e)
        {
            var result = sleepForms(2000);
            string rrr = await result;
            ButtonEdit2.Hide();
            buttonGarbage2.Hide();
        }


        #endregion


        private void ButtonEditPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Please choose a picture";
            dialog.Filter = "Picture file(*.gif;*.jpg;*.jpeg;*.png)|*.gif;*.jpg;*.jpeg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imageFilePath = AppSetting.path + "\\Html\\Avatars";

                // get the image url
                string avatarFilePath = FileProcess.CopyToFile(dialog.FileName, imageFilePath);

                // update the picture
                ChangeAvatarToImage(avatarFilePath);
                Main.main.ChangeAvatarToImage(avatarFilePath);

                //update the cache
                User_type.user_avatarPath = avatarFilePath;

                //update the db
                SQLCursor.UpdateAvatar(User_type.user_ID, FileProcess.AvatarID);
            }
        }


        private void ChangeAvatarToImage(string avatarFilePath)
        {
            uiAvatar1.Visible = true;
            uiAvatar1.Icon = UIIcon.Image;
            uiAvatar1.Image = Image.FromFile(avatarFilePath);
            uiAvatar1.Size = new Size(70, 70);
            uiAvatar1.AvatarSize = 70;
            uiAvatar1.Location = new Point(564, 29);

            UserFirstLeeter.Visible = false;

        }
        private void InitAvatar()
        {
            if (User_type.user_avatarPath != "")
            {
                ChangeAvatarToImage(User_type.user_avatarPath);
            }
        }

        private void setAvatar()
        {
            uiAvatar1.Parent = pictureBg;
        }

    }
}
