using System;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Face_Rec_Tmp.FaceCascade;


namespace Face_Rec_Tmp
{
    public partial class faceRec : Form
    {
        // Frame displayed in image box
        Mat frame = new Mat();
        // Camera
        bool cameraOn = false;
        VideoCapture capture = new VideoCapture(0);

        public faceRec()
        {
            InitializeComponent();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {
            uploadImage.FlatAppearance.BorderSize =
                openCamera.FlatAppearance.BorderSize = downloadImage.FlatAppearance.BorderSize =
                helpBtn.FlatAppearance.BorderSize = deleteImgBtn.FlatAppearance.BorderSize =
                exitBtn.FlatAppearance.BorderSize = 0;

            // picBox
            picBox.AllowDrop = true;
            picBox.BorderStyle = BorderStyle.None;
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void faceRec_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
                cameraOn = false;
        }

        /* UPLOADING IMAGE FUNCTIONS */
        private void picBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void picBox_DragDrop(object sender, DragEventArgs e)
        {
            if (cameraOn)
            {
                MessageBox.Show("You cannot upload images while your camera is on");
                return;
            }

            var data = e.Data.GetData(DataFormats.FileDrop);

            if (data != null)
            {
                try
                {
                    Recognition rec = new Recognition();
                    var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                    //Checks if an uploade file's invalid
                    foreach (var file in files)
                        if (rec.invalidFile(file))
                            return;

                    // Locates faces in the first uploaded image
                    Bitmap image = new Bitmap(Image.FromFile(files[0]));
                    frame = BitmapConverter.ToMat(image);

                    // Detects and displays face
                    picBox.Image = Recognition.detectFaces(frame).ToBitmap();

                    image.Dispose();
                    frame.Dispose();
                }
                catch
                {
                    MessageBox.Show("There was a problem displaying image. Please try uploading it again");
                }
            }
        }

        private void uploadImage_Click(object sender, EventArgs e)
        {
            // User can't upload images if the camera's on
            if (cameraOn)
            {
                MessageBox.Show("You cannot upload images while your camera is on");
                return;
            }

            // Catches errors that may come when uploading certain images
            try
            {
                // User selects image
                openFile.ShowDialog();
                string filePath = openFile.FileName;
                Recognition rec = new Recognition();

                // Checks if the file exists and it's path is valid
                if (!File.Exists(filePath) || rec.invalidFile(filePath))
                    return;

                Bitmap image = new Bitmap(Image.FromFile(filePath));
                frame = BitmapConverter.ToMat(image);
                clearPicBox();
                // Detects and displays face
                picBox.Image = Recognition.detectFaces(frame).ToBitmap();
                frame.Dispose();
            }
            catch
            {
                MessageBox.Show("There was a problem displaying image. Please try uploading it again");
            }
        }

        // Camera recording
        private void openCamera_Click(object sender, EventArgs e)
        {
            if (cameraOn)
            {
                closeCamera();
                return;
            }

            if (!capture.IsOpened())
            {
                MessageBox.Show("Camera not found. Please try again");
                return;
            }

            cameraOn = true;
            frame = new Mat();

            while (cameraOn)
            {
                capture.Read(frame);
                //Opens new window for camera
                //Cv2.ImShow("Camera Window", frame);

                clearPicBox();
                // Detects and displays face
                picBox.Image = Recognition.detectFaces(frame).ToBitmap();

                if (Cv2.WaitKey(10) == 8) // || Cv2.WaitKey(1) == 32)
                    cameraOn = false;
            }

            closeCamera();
        }

        // Downloads Image in picBox
        private void downloadImage_Click(object sender, EventArgs e)
        {
            // Checks if there's an image to save
            if (picBox.Image == null)
            {
                MessageBox.Show("There's no image to download.");
                return;
            }

            // Adds file name and type
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "FaceRec_" + DateTime.Now.ToString(@"dd\_MM\_yyyy\_H\_m\_s");
            saveFile.Filter = "PNG Image|* .png";
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
                picBox.Image.Save(saveFile.FileName, System.Drawing.Imaging.ImageFormat.Png);

            saveFile.Dispose();
        }

        // Deletes Image in picBox
        private void deleteImgBtn_Click(object sender, EventArgs e)
        {
            if (picBox.Image == null){
                MessageBox.Show("There is no image to delete");
                return;
            }
            else if (cameraOn){
                MessageBox.Show("Turn off your camera before deleting the image");
                return;
            }
            picBox.Image = null;
            clearPicBox();
        }

        // Help page
        private void helpBtn_Click(object sender, EventArgs e)
        {
            var helpForm = new Help();
            helpForm.Show();
        }

        // Exit button
        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (capture != null)
                cameraOn = false;

            Application.Exit();
        }

        // Deletes the old image in picbox
        public void clearPicBox()
        {
            if (picBox.Image != null)
            {
                picBox.Image.Dispose();
                // Forces the memory to be cleared
                GC.Collect();
            }
        }

        // Closes and resets camera window
        public void closeCamera()
        {
            cameraOn = false;
            Cv2.DestroyAllWindows();
            capture.Release();
            capture.Dispose();
            capture = new VideoCapture(0);
            frame.Dispose();
        }
    }
}