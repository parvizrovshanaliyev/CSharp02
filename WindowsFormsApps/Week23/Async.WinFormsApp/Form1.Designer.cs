
namespace Async.WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonyellow = new System.Windows.Forms.Button();
            this.buttonblue = new System.Windows.Forms.Button();
            this.buttonred = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonyellow
            // 
            this.buttonyellow.Location = new System.Drawing.Point(208, 396);
            this.buttonyellow.Name = "buttonyellow";
            this.buttonyellow.Size = new System.Drawing.Size(133, 46);
            this.buttonyellow.TabIndex = 0;
            this.buttonyellow.Text = "yellow";
            this.buttonyellow.UseVisualStyleBackColor = true;
            this.buttonyellow.Click += new System.EventHandler(this.buttonyellow_Click);
            // 
            // buttonblue
            // 
            this.buttonblue.Location = new System.Drawing.Point(371, 396);
            this.buttonblue.Name = "buttonblue";
            this.buttonblue.Size = new System.Drawing.Size(133, 46);
            this.buttonblue.TabIndex = 1;
            this.buttonblue.Text = "blue";
            this.buttonblue.UseVisualStyleBackColor = true;
            this.buttonblue.Click += new System.EventHandler(this.buttonblue_Click);
            // 
            // buttonred
            // 
            this.buttonred.Location = new System.Drawing.Point(541, 396);
            this.buttonred.Name = "buttonred";
            this.buttonred.Size = new System.Drawing.Size(133, 46);
            this.buttonred.TabIndex = 2;
            this.buttonred.Text = "red";
            this.buttonred.UseVisualStyleBackColor = true;
            this.buttonred.Click += new System.EventHandler(this.buttonred_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 501);
            this.Controls.Add(this.buttonred);
            this.Controls.Add(this.buttonblue);
            this.Controls.Add(this.buttonyellow);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SingleTreadForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonyellow;
        private System.Windows.Forms.Button buttonblue;
        private System.Windows.Forms.Button buttonred;
    }
}

