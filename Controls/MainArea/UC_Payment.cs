﻿using miniSys0._3.Controls.Others;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniSys0._3.Controls.MainArea
{
    public partial class UC_Payment : UserControl
    {
        public UC_Payment()
        {
            InitializeComponent();
            InitCurmbs();
            Initcontent();
        }
        private void InitCurmbs()
        {
            urC_Crumbs1.crumbText.Text = "Payment";
            urC_Crumbs1.crumbsHome.Text = " / Form / Payment";
        }

        private void Initcontent()
        {
            UC_ReciptSubmit uc = new UC_ReciptSubmit();
            AddUserControl.Add(uc, contentPanel);
        }


    }
}
