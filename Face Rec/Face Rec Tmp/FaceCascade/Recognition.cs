using System;
using OpenCvSharp;
using System.Drawing;

namespace Face_Rec_Tmp.FaceCascade
{
    internal class Recognition
    {
        public bool invalidFile(string filePath){
            FileInfo fileInfo = new FileInfo(filePath);
            long size = fileInfo.Length;

            bool validFile = (Path.GetExtension(filePath) == ".jpg") || (Path.GetExtension(filePath) == ".jpeg")
            || (Path.GetExtension(filePath) == ".png") || (Path.GetExtension(filePath) == ".bmp")
            || (Path.GetExtension(filePath) == ".gif") || (Path.GetExtension(filePath) == ".jfif");

            // File is invalid if it's not an image, size is less than 15KB or is null
            if (!validFile || size < 15000 || size == 0 || size == null){
                MessageBox.Show("This file type is invalid. Please try again");
                return true;
            }
            return false;
        }

        public static Mat detectFaces(Mat img){
            CascadeClassifier frontCascClassifier = new CascadeClassifier(".\\FaceCascade\\haarcascade_frontalface_alt_tree.xml");
            CascadeClassifier sideCascClassifier = new CascadeClassifier(".\\FaceCascade\\haarcascade_profileface.xml");

            // Checks if files loaded properly
            if (frontCascClassifier.Empty() || sideCascClassifier.Empty()){
                MessageBox.Show("One of the face cascades hasn't loaded properly. Please try again");
                return img;
            }

            Mat grayImage = new Mat();
            Cv2.CvtColor(img, grayImage, ColorConversionCodes.BGR2GRAY);
            Cv2.EqualizeHist(grayImage, grayImage);

            // Front and Left Side
            Rect[] frontFaces = frontCascClassifier.DetectMultiScale(
                grayImage, 1.1, 2, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(40, 40));
            Rect[] leftSideFaces = sideCascClassifier.DetectMultiScale(
                grayImage, 1.1, 2, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(40, 40));

            // Right Side
            // Flips image because haarcascade_profileface is trained to only detect faces turned to the left
            Mat flippedImage = grayImage;
            Cv2.Flip(flippedImage, flippedImage, FlipMode.Y);
            Rect[] rightFaces = sideCascClassifier.DetectMultiScale(
                flippedImage, 1.1, 2, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(40, 40));

            Rect[] rightSideFaces = new Rect[rightFaces.Length];

            // Adjusts the flipped image to the coordinates of the original
            for (int i = 0; i < rightFaces.Length; i++){
                Rect face = rightFaces[i];
                rightSideFaces[i] = new Rect(grayImage.Width - face.X - face.Width, face.Y, face.Width, face.Height);
            }
            
            grayImage.Dispose();
            flippedImage.Dispose();

            // Adds every image to the faces
            Rect[] faces = new Rect[frontFaces.Length + leftSideFaces.Length + rightSideFaces.Length];
            frontFaces.CopyTo(faces, 0);
            leftSideFaces.CopyTo(faces, frontFaces.Length);
            rightSideFaces.CopyTo(faces, frontFaces.Length + leftSideFaces.Length);

            return drawRectangles(img, faces, 0);
        }

        public static Mat drawRectangles(Mat img, Rect[] faces, int i){
            if(i < faces.Length){
                Rect rectangle = new Rect(
                    Math.Max(0, faces[i].X - 20), Math.Max(0, faces[i].Y - 20),
                    Math.Min(img.Cols - 1, faces[i].Width + 2 * 20), Math.Min(img.Rows - 1, faces[i].Height + 2 * 20));

                Cv2.Rectangle(img, rectangle, Scalar.Red, 3);
                i++;
                return drawRectangles(img, faces, i);
            }

            return img;
        }
    }
}