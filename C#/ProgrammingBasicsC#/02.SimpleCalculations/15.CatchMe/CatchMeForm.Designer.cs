namespace _15.CatchMe
{
    partial class CatchMeForm
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
            this.CatchMeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CatchMeBtn
            // 
            this.CatchMeBtn.Location = new System.Drawing.Point(89, 47);
            this.CatchMeBtn.Name = "CatchMeBtn";
            this.CatchMeBtn.Size = new System.Drawing.Size(64, 64);
            this.CatchMeBtn.TabIndex = 0;
            this.CatchMeBtn.Text = "Catch me!";
            this.CatchMeBtn.UseVisualStyleBackColor = true;
            this.CatchMeBtn.Click += new System.EventHandler(this.CatchMeBtn_Click);
            this.CatchMeBtn.MouseHover += new System.EventHandler(this.CatchMeBtn_MouseHover);
            // 
            // CatchMeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.CatchMeBtn);
            this.Name = "CatchMeForm";
            this.Text = "Catch me!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CatchMeBtn;
    }
}

