
using System;

namespace MyBooks
{
    partial class StartMenuAfterAutorizationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Функції програми";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(20, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(520, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Показати всі книги";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(600, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(520, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Функції адміністратора";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.button2.Location = new System.Drawing.Point(20, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(520, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Знайти автора Х книги У";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.button3.Location = new System.Drawing.Point(20, 600);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(520, 50);
            this.button3.TabIndex = 4;
            this.button3.Text = "Знайти кількість книг ХХ року видання";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.button4.Location = new System.Drawing.Point(600, 287);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(520, 50);
            this.button4.TabIndex = 5;
            this.button4.Text = "Додати книги";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.button5.Location = new System.Drawing.Point(600, 512);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(520, 50);
            this.button5.TabIndex = 6;
            this.button5.Text = "Видалити книги";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // StartMenuAfterAutorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "StartMenuAfterAutorizationForm";
            this.Text = "StartMenuAfterAutorization";
            this.Load += new System.EventHandler(this.StartMenuAfterAutorizationForm_Load);
            this.ResumeLayout(false);

        }

        private void StartMenuAfterAutorizationForm_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}