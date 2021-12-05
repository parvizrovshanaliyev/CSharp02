
namespace Async.WinFormsApp
{
    partial class Form2
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
            this.buttonred = new System.Windows.Forms.Button();
            this.buttonblue = new System.Windows.Forms.Button();
            this.buttonyellow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonred
            // 
            this.buttonred.Location = new System.Drawing.Point(679, 568);
            this.buttonred.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonred.Name = "buttonred";
            this.buttonred.Size = new System.Drawing.Size(152, 61);
            this.buttonred.TabIndex = 5;
            this.buttonred.Text = "red";
            this.buttonred.UseVisualStyleBackColor = true;
            this.buttonred.Click += new System.EventHandler(this.buttonred_Click);
            // 
            // buttonblue
            // 
            this.buttonblue.Location = new System.Drawing.Point(485, 568);
            this.buttonblue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonblue.Name = "buttonblue";
            this.buttonblue.Size = new System.Drawing.Size(152, 61);
            this.buttonblue.TabIndex = 4;
            this.buttonblue.Text = "blue";
            this.buttonblue.UseVisualStyleBackColor = true;
            this.buttonblue.Click += new System.EventHandler(this.buttonblue_Click);
            // 
            // buttonyellow
            // 
            this.buttonyellow.Location = new System.Drawing.Point(299, 568);
            this.buttonyellow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonyellow.Name = "buttonyellow";
            this.buttonyellow.Size = new System.Drawing.Size(152, 61);
            this.buttonyellow.TabIndex = 3;
            this.buttonyellow.Text = "yellow";
            this.buttonyellow.UseVisualStyleBackColor = true;
            this.buttonyellow.Click += new System.EventHandler(this.buttonyellow_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 716);
            this.Controls.Add(this.buttonred);
            this.Controls.Add(this.buttonblue);
            this.Controls.Add(this.buttonyellow);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonred;
        private System.Windows.Forms.Button buttonblue;
        private System.Windows.Forms.Button buttonyellow;
    }
}