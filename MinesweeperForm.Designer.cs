﻿
namespace Minesweeper
{
    partial class MinesweeperForm
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
            this.mineFieldPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mineFieldPanel
            // 
            this.mineFieldPanel.AutoSize = true;
            this.mineFieldPanel.Location = new System.Drawing.Point(190, 178);
            this.mineFieldPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mineFieldPanel.Name = "mineFieldPanel";
            this.mineFieldPanel.Size = new System.Drawing.Size(100, 100);
            this.mineFieldPanel.TabIndex = 0;
            // 
            // MinesweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 457);
            this.Controls.Add(this.mineFieldPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MinesweeperForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MinesweeperForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mineFieldPanel;
    }
}

