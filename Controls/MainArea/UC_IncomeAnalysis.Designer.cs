﻿namespace miniSys0._3.Controls.MainArea
{
    partial class UC_IncomeAnalysis
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
            this.urC_Crumbs1 = new miniSys0._3.Controls.Others.UrC_Crumbs();
            this.refreshlButton2 = new Sunny.UI.UISymbolButton();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.ok = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // urC_Crumbs1
            // 
            this.urC_Crumbs1.BackColor = System.Drawing.SystemColors.Control;
            this.urC_Crumbs1.Location = new System.Drawing.Point(0, 4);
            this.urC_Crumbs1.Name = "urC_Crumbs1";
            this.urC_Crumbs1.Size = new System.Drawing.Size(289, 35);
            this.urC_Crumbs1.TabIndex = 0;
            // 
            // refreshlButton2
            // 
            this.refreshlButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshlButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(93)))), ((int)(((byte)(255)))));
            this.refreshlButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.refreshlButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.refreshlButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshlButton2.Location = new System.Drawing.Point(1087, 2);
            this.refreshlButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.refreshlButton2.Name = "refreshlButton2";
            this.refreshlButton2.RectColor = System.Drawing.Color.Transparent;
            this.refreshlButton2.RectDisableColor = System.Drawing.Color.Transparent;
            this.refreshlButton2.RectHoverColor = System.Drawing.Color.Transparent;
            this.refreshlButton2.RectPressColor = System.Drawing.Color.Transparent;
            this.refreshlButton2.RectSelectedColor = System.Drawing.Color.Transparent;
            this.refreshlButton2.Size = new System.Drawing.Size(35, 35);
            this.refreshlButton2.Style = Sunny.UI.UIStyle.Custom;
            this.refreshlButton2.Symbol = 57386;
            this.refreshlButton2.TabIndex = 5;
            this.refreshlButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshlButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.refreshlButton2.Click += new System.EventHandler(this.refreshlButton2_Click);
            // 
            // chartPanel
            // 
            this.chartPanel.Location = new System.Drawing.Point(0, 43);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(1125, 675);
            this.chartPanel.TabIndex = 4;
            // 
            // ok
            // 
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(93)))), ((int)(((byte)(255)))));
            this.ok.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ok.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ok.Font = new System.Drawing.Font(".萍方-简", 12F, System.Drawing.FontStyle.Bold);
            this.ok.Location = new System.Drawing.Point(967, 4);
            this.ok.MinimumSize = new System.Drawing.Size(1, 1);
            this.ok.Name = "ok";
            this.ok.RectColor = System.Drawing.Color.Transparent;
            this.ok.RectHoverColor = System.Drawing.Color.Transparent;
            this.ok.RectPressColor = System.Drawing.Color.Transparent;
            this.ok.RectSelectedColor = System.Drawing.Color.Transparent;
            this.ok.Size = new System.Drawing.Size(100, 35);
            this.ok.Style = Sunny.UI.UIStyle.Custom;
            this.ok.TabIndex = 6;
            this.ok.Text = "Table view";
            this.ok.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ok.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // UC_IncomeAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.ok);
            this.Controls.Add(this.refreshlButton2);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.urC_Crumbs1);
            this.Name = "UC_IncomeAnalysis";
            this.Size = new System.Drawing.Size(1125, 720);
            this.ResumeLayout(false);

        }

        #endregion

        private Others.UrC_Crumbs urC_Crumbs1;
        private Sunny.UI.UISymbolButton refreshlButton2;
        private System.Windows.Forms.Panel chartPanel;
        private Sunny.UI.UIButton ok;
    }
}
