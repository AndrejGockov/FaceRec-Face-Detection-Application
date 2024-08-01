namespace Face_Rec_Tmp
{
    partial class faceRec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(faceRec));
            openCamera = new Button();
            picBox = new PictureBox();
            title = new Label();
            uploadImage = new Button();
            downloadImage = new Button();
            helpBtn = new Button();
            deleteImgBtn = new Button();
            openFile = new OpenFileDialog();
            saveFile = new SaveFileDialog();
            pictureBox2 = new PictureBox();
            exitBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // openCamera
            // 
            openCamera.BackColor = SystemColors.ControlLight;
            openCamera.Cursor = Cursors.Hand;
            openCamera.FlatStyle = FlatStyle.Flat;
            openCamera.Location = new Point(18, 187);
            openCamera.Name = "openCamera";
            openCamera.RightToLeft = RightToLeft.No;
            openCamera.Size = new Size(316, 44);
            openCamera.TabIndex = 3;
            openCamera.Text = "Open Camera";
            openCamera.UseVisualStyleBackColor = false;
            openCamera.Click += openCamera_Click;
            openCamera.Enter += LandingPage_Load;
            // 
            // picBox
            // 
            picBox.BackColor = SystemColors.ControlDark;
            picBox.BorderStyle = BorderStyle.FixedSingle;
            picBox.Location = new Point(360, 11);
            picBox.Name = "picBox";
            picBox.Size = new Size(420, 500);
            picBox.TabIndex = 1;
            picBox.TabStop = false;
            picBox.DragDrop += picBox_DragDrop;
            picBox.DragEnter += picBox_DragEnter;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 36F);
            title.Location = new Point(18, 21);
            title.Name = "title";
            title.Size = new Size(245, 81);
            title.TabIndex = 0;
            title.Text = "FaceRec";
            // 
            // uploadImage
            // 
            uploadImage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uploadImage.BackColor = SystemColors.ControlLight;
            uploadImage.Cursor = Cursors.Hand;
            uploadImage.FlatStyle = FlatStyle.Flat;
            uploadImage.Location = new Point(18, 117);
            uploadImage.Name = "uploadImage";
            uploadImage.Size = new Size(316, 44);
            uploadImage.TabIndex = 3;
            uploadImage.Text = "Upload Image";
            uploadImage.UseVisualStyleBackColor = false;
            uploadImage.Click += uploadImage_Click;
            // 
            // downloadImage
            // 
            downloadImage.BackColor = SystemColors.ControlLight;
            downloadImage.Cursor = Cursors.Hand;
            downloadImage.FlatStyle = FlatStyle.Flat;
            downloadImage.Location = new Point(18, 257);
            downloadImage.Name = "downloadImage";
            downloadImage.Size = new Size(316, 44);
            downloadImage.TabIndex = 3;
            downloadImage.Text = "Download Image";
            downloadImage.UseVisualStyleBackColor = false;
            downloadImage.Click += downloadImage_Click;
            // 
            // helpBtn
            // 
            helpBtn.BackColor = SystemColors.ControlLight;
            helpBtn.Cursor = Cursors.Hand;
            helpBtn.FlatStyle = FlatStyle.Flat;
            helpBtn.Location = new Point(18, 397);
            helpBtn.Name = "helpBtn";
            helpBtn.Size = new Size(316, 44);
            helpBtn.TabIndex = 3;
            helpBtn.Text = "Help";
            helpBtn.UseVisualStyleBackColor = false;
            helpBtn.Click += helpBtn_Click;
            // 
            // deleteImgBtn
            // 
            deleteImgBtn.BackColor = SystemColors.ControlLight;
            deleteImgBtn.Cursor = Cursors.Hand;
            deleteImgBtn.FlatStyle = FlatStyle.Flat;
            deleteImgBtn.Location = new Point(18, 467);
            deleteImgBtn.Name = "deleteImgBtn";
            deleteImgBtn.Size = new Size(316, 44);
            deleteImgBtn.TabIndex = 3;
            deleteImgBtn.Text = "Exit";
            deleteImgBtn.UseVisualStyleBackColor = false;
            deleteImgBtn.Click += exitBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Logo1;
            pictureBox2.ImeMode = ImeMode.NoControl;
            pictureBox2.Location = new Point(254, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(90, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = SystemColors.ControlLight;
            exitBtn.Cursor = Cursors.Hand;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Location = new Point(18, 327);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(316, 44);
            exitBtn.TabIndex = 3;
            exitBtn.Text = "Delete Image";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += deleteImgBtn_Click;
            // 
            // faceRec
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(792, 523);
            Controls.Add(exitBtn);
            Controls.Add(pictureBox2);
            Controls.Add(deleteImgBtn);
            Controls.Add(helpBtn);
            Controls.Add(downloadImage);
            Controls.Add(uploadImage);
            Controls.Add(title);
            Controls.Add(picBox);
            Controls.Add(openCamera);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "faceRec";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FaceRec";
            FormClosing += faceRec_FormClosing;
            Load += LandingPage_Load;
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openCamera;
        private PictureBox picBox;
        private Label title;
        private Button uploadImage;
        private Button downloadImage;
        private Button helpBtn;
        private Button deleteImgBtn;
        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;
        private PictureBox pictureBox2;
        private Button exitBtn;
    }
}
