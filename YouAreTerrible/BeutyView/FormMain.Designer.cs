﻿namespace BeutyView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ресурсыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.магазиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьМагазинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.движениеРесурсовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьДокументНаПередачуРусрсовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьМагазинToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ресурсыToolStripMenuItem,
            this.магазиныToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // ресурсыToolStripMenuItem
            // 
            this.ресурсыToolStripMenuItem.Name = "ресурсыToolStripMenuItem";
            this.ресурсыToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ресурсыToolStripMenuItem.Text = "Ресурсы";
            this.ресурсыToolStripMenuItem.Click += new System.EventHandler(this.ресурсыToolStripMenuItem_Click);
            // 
            // магазиныToolStripMenuItem
            // 
            this.магазиныToolStripMenuItem.Name = "магазиныToolStripMenuItem";
            this.магазиныToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.магазиныToolStripMenuItem.Text = "Магазины";
            this.магазиныToolStripMenuItem.Click += new System.EventHandler(this.магазиныToolStripMenuItem_Click);
            // 
            // пополнитьМагазинToolStripMenuItem
            // 
            this.пополнитьМагазинToolStripMenuItem.Name = "пополнитьМагазинToolStripMenuItem";
            this.пополнитьМагазинToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.пополнитьМагазинToolStripMenuItem.Text = "Пополнить магазин";
            this.пополнитьМагазинToolStripMenuItem.Click += new System.EventHandler(this.пополнитьМагазинToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.движениеРесурсовToolStripMenuItem,
            this.сформироватьДокументНаПередачуРусрсовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            this.отчетыToolStripMenuItem.Click += new System.EventHandler(this.отчетыToolStripMenuItem_Click);
            // 
            // движениеРесурсовToolStripMenuItem
            // 
            this.движениеРесурсовToolStripMenuItem.Name = "движениеРесурсовToolStripMenuItem";
            this.движениеРесурсовToolStripMenuItem.Size = new System.Drawing.Size(331, 22);
            this.движениеРесурсовToolStripMenuItem.Text = "Движение ресурсов";
            this.движениеРесурсовToolStripMenuItem.Click += new System.EventHandler(this.движениеРесурсовToolStripMenuItem_Click);
            // 
            // сформироватьДокументНаПередачуРусрсовToolStripMenuItem
            // 
            this.сформироватьДокументНаПередачуРусрсовToolStripMenuItem.Name = "сформироватьДокументНаПередачуРусрсовToolStripMenuItem";
            this.сформироватьДокументНаПередачуРусрсовToolStripMenuItem.Size = new System.Drawing.Size(331, 22);
            this.сформироватьДокументНаПередачуРусрсовToolStripMenuItem.Text = "Сформировать документ на передачу русрсов";
            this.сформироватьДокументНаПередачуРусрсовToolStripMenuItem.Click += new System.EventHandler(this.сформироватьДокументНаПередачуРусрсовToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 395);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ресурсыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem магазиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьМагазинToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem движениеРесурсовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьДокументНаПередачуРусрсовToolStripMenuItem;
    }
}