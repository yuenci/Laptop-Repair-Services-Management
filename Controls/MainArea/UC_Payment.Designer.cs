﻿namespace miniSys0._3.Controls.MainArea
{
    partial class UC_Payment
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Container = new Sunny.UI.UIUserControl();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.brand = new Sunny.UI.UITextBox();
            this.method = new Sunny.UI.UIComboBox();
            this.type = new Sunny.UI.UIComboBox();
            this.model = new Sunny.UI.UITextBox();
            this.name = new Sunny.UI.UITextBox();
            this.resetButton = new Sunny.UI.UIButton();
            this.submitButton = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.switch1 = new Sunny.UI.UISwitch();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.label1 = new System.Windows.Forms.Label();
            this.urC_Crumbs1 = new miniSys0._3.Controls.Others.UrC_Crumbs();
            this.Container.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Container
            // 
            this.Container.BackColor = System.Drawing.Color.White;
            this.Container.Controls.Add(this.contentPanel);
            this.Container.Controls.Add(this.label1);
            this.Container.FillColor = System.Drawing.Color.White;
            this.Container.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Container.Location = new System.Drawing.Point(4, 58);
            this.Container.MinimumSize = new System.Drawing.Size(1, 1);
            this.Container.Name = "Container";
            this.Container.RectColor = System.Drawing.Color.White;
            this.Container.Size = new System.Drawing.Size(1118, 659);
            this.Container.Style = Sunny.UI.UIStyle.Custom;
            this.Container.TabIndex = 2;
            this.Container.Text = "uiUserControl1";
            this.Container.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Container.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.label2);
            this.contentPanel.Controls.Add(this.brand);
            this.contentPanel.Controls.Add(this.method);
            this.contentPanel.Controls.Add(this.type);
            this.contentPanel.Controls.Add(this.model);
            this.contentPanel.Controls.Add(this.name);
            this.contentPanel.Controls.Add(this.resetButton);
            this.contentPanel.Controls.Add(this.submitButton);
            this.contentPanel.Controls.Add(this.uiLabel5);
            this.contentPanel.Controls.Add(this.uiLabel4);
            this.contentPanel.Controls.Add(this.switch1);
            this.contentPanel.Controls.Add(this.uiLabel3);
            this.contentPanel.Controls.Add(this.uiLabel2);
            this.contentPanel.Controls.Add(this.uiLabel1);
            this.contentPanel.Location = new System.Drawing.Point(0, 61);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1115, 578);
            this.contentPanel.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "--";
            // 
            // brand
            // 
            this.brand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.brand.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.brand.Location = new System.Drawing.Point(415, 277);
            this.brand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.brand.MinimumSize = new System.Drawing.Size(1, 16);
            this.brand.Name = "brand";
            this.brand.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.brand.ShowText = false;
            this.brand.Size = new System.Drawing.Size(245, 40);
            this.brand.Style = Sunny.UI.UIStyle.Custom;
            this.brand.TabIndex = 10;
            this.brand.Text = "Customer\'s computer Brand";
            this.brand.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.brand.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // method
            // 
            this.method.DataSource = null;
            this.method.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.method.FillColor = System.Drawing.Color.White;
            this.method.FilterMaxCount = 50;
            this.method.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.method.Items.AddRange(new object[] {
            "Credit Card",
            "Paypal",
            "Cash",
            "Check"});
            this.method.Location = new System.Drawing.Point(415, 352);
            this.method.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.method.MinimumSize = new System.Drawing.Size(63, 0);
            this.method.Name = "method";
            this.method.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.method.Size = new System.Drawing.Size(555, 40);
            this.method.Style = Sunny.UI.UIStyle.Custom;
            this.method.TabIndex = 11;
            this.method.Text = "Select a Payment Method";
            this.method.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.method.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // type
            // 
            this.type.DataSource = null;
            this.type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.type.FillColor = System.Drawing.Color.White;
            this.type.FilterMaxCount = 50;
            this.type.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.type.Items.AddRange(new object[] {
            "Remove virus, malware or spyware",
            "Troubleshot and fix computer running slow",
            "Laptop screen replacement",
            "Laptop keyboard replacement",
            "Laptop battery replacement",
            "Operating System Format and Installation",
            "Data backup and recovery",
            "Internet connectivity issues"});
            this.type.Location = new System.Drawing.Point(415, 138);
            this.type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.type.MinimumSize = new System.Drawing.Size(63, 0);
            this.type.Name = "type";
            this.type.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.type.Size = new System.Drawing.Size(553, 40);
            this.type.Style = Sunny.UI.UIStyle.Custom;
            this.type.TabIndex = 10;
            this.type.Text = "Select a service type";
            this.type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.type.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // model
            // 
            this.model.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.model.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.model.Location = new System.Drawing.Point(725, 277);
            this.model.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.model.MinimumSize = new System.Drawing.Size(1, 16);
            this.model.Name = "model";
            this.model.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.model.ShowText = false;
            this.model.Size = new System.Drawing.Size(245, 40);
            this.model.Style = Sunny.UI.UIStyle.Custom;
            this.model.TabIndex = 9;
            this.model.Text = "Customer\'s computer model";
            this.model.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.model.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // name
            // 
            this.name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.name.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.name.Location = new System.Drawing.Point(415, 63);
            this.name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.name.MinimumSize = new System.Drawing.Size(1, 16);
            this.name.Name = "name";
            this.name.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.name.ShowText = false;
            this.name.Size = new System.Drawing.Size(553, 40);
            this.name.Style = Sunny.UI.UIStyle.Custom;
            this.name.TabIndex = 8;
            this.name.Text = "Enter customer\'s name";
            this.name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // resetButton
            // 
            this.resetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetButton.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resetButton.Location = new System.Drawing.Point(643, 467);
            this.resetButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(100, 35);
            this.resetButton.Style = Sunny.UI.UIStyle.Custom;
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Reset";
            this.resetButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resetButton.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            //this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitButton.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submitButton.Location = new System.Drawing.Point(415, 467);
            this.submitButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 35);
            this.submitButton.Style = Sunny.UI.UIStyle.Custom;
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submitButton.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            //this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(157, 361);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(162, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "Payment Method:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(167, 280);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(152, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 4;
            this.uiLabel4.Text = "Computer model:";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // switch1
            // 
            this.switch1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.switch1.ActiveText = "Yes";
            this.switch1.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.switch1.InActiveText = "No";
            this.switch1.Location = new System.Drawing.Point(415, 213);
            this.switch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.switch1.Name = "switch1";
            this.switch1.Size = new System.Drawing.Size(75, 29);
            this.switch1.Style = Sunny.UI.UIStyle.Custom;
            this.switch1.TabIndex = 3;
            this.switch1.Text = "uiSwitch1";
            this.switch1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(145, 208);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(174, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "Urgent:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(145, 134);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(174, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "Service type:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(145, 71);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(174, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Customer name:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(".萍方-简", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Receipt generating Form";
            // 
            // urC_Crumbs1
            // 
            this.urC_Crumbs1.BackColor = System.Drawing.Color.Transparent;
            this.urC_Crumbs1.Location = new System.Drawing.Point(0, 4);
            this.urC_Crumbs1.Name = "urC_Crumbs1";
            this.urC_Crumbs1.Size = new System.Drawing.Size(300, 35);
            this.urC_Crumbs1.TabIndex = 1;
            // 
            // UC_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.Container);
            this.Controls.Add(this.urC_Crumbs1);
            this.Name = "UC_Payment";
            this.Size = new System.Drawing.Size(1125, 720);
            this.Container.ResumeLayout(false);
            this.Container.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Others.UrC_Crumbs urC_Crumbs1;
        private Sunny.UI.UIUserControl Container;
        public System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIButton resetButton;
        private Sunny.UI.UIButton submitButton;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UISwitch switch1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox method;
        private Sunny.UI.UIComboBox type;
        private Sunny.UI.UITextBox model;
        private Sunny.UI.UITextBox name;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox brand;
    }
}
