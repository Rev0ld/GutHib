namespace PresentationLayer
{
    partial class MainForm
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
            this.userBtn = new System.Windows.Forms.Button();
            this.gameBtn = new System.Windows.Forms.Button();
            this.genreBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userBtn
            // 
            this.userBtn.Location = new System.Drawing.Point(33, 36);
            this.userBtn.Name = "userBtn";
            this.userBtn.Size = new System.Drawing.Size(75, 23);
            this.userBtn.TabIndex = 0;
            this.userBtn.Text = "User";
            this.userBtn.UseVisualStyleBackColor = true;
            this.userBtn.Click += new System.EventHandler(this.userBtn_Click);
            // 
            // gameBtn
            // 
            this.gameBtn.Location = new System.Drawing.Point(33, 111);
            this.gameBtn.Name = "gameBtn";
            this.gameBtn.Size = new System.Drawing.Size(75, 23);
            this.gameBtn.TabIndex = 1;
            this.gameBtn.Text = "Game";
            this.gameBtn.UseVisualStyleBackColor = true;
            this.gameBtn.Click += new System.EventHandler(this.gameBtn_Click);
            // 
            // genreBtn
            // 
            this.genreBtn.Location = new System.Drawing.Point(183, 36);
            this.genreBtn.Name = "genreBtn";
            this.genreBtn.Size = new System.Drawing.Size(75, 23);
            this.genreBtn.TabIndex = 2;
            this.genreBtn.Text = "Genre";
            this.genreBtn.UseVisualStyleBackColor = true;
            this.genreBtn.Click += new System.EventHandler(this.genreBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(183, 111);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 201);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.genreBtn);
            this.Controls.Add(this.gameBtn);
            this.Controls.Add(this.userBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button userBtn;
        private System.Windows.Forms.Button gameBtn;
        private System.Windows.Forms.Button genreBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}