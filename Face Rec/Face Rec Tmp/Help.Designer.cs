namespace Face_Rec_Tmp
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            pictureBox1 = new PictureBox();
            title = new Label();
            exitBtn = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo1;
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(185, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 36F);
            title.ImeMode = ImeMode.NoControl;
            title.Location = new Point(42, 9);
            title.Name = "title";
            title.Size = new Size(159, 81);
            title.TabIndex = 6;
            title.Text = "Help";
            // 
            // exitBtn
            // 
            exitBtn.BackColor = SystemColors.ControlLight;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Location = new Point(8, 9);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(28, 27);
            exitBtn.TabIndex = 8;
            exitBtn.Text = "X";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(728, 400);
            label1.TabIndex = 9;
            label1.Text = resources.GetString("label1.Text");
            // 
            // Help
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(752, 490);
            Controls.Add(label1);
            Controls.Add(exitBtn);
            Controls.Add(pictureBox1);
            Controls.Add(title);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Help";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Help";
            Load += Help_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label title;
        private Button exitBtn;
        private Label label1;
    }
}