﻿using System;
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
    public partial class UC_TaskCards : UserControl
    {
        public UC_TaskCards()
        {
            InitializeComponent();
            InitCurmbs();
        }

        private void InitCurmbs()
        {
            urC_Crumbs1.crumbText.Text = "Card view";
            urC_Crumbs1.crumbsHome.Text = " / Table /   Card view";
        }
    }
}