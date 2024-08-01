using System;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Face_Rec_Tmp
{
    public partial class Help : Form
    {
        public Help(){
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e){
            exitBtn.FlatAppearance.BorderSize = 0;
        }

        private void exitBtn_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}

/*
 How to use:
Clicking Upload Image will ask you to upload an image saved locally, 
after which it will analyze and return all the image with all the found faces highlighted
 */