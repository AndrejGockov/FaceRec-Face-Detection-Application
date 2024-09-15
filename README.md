# FaceRec-Face-Detection-Application

### [Download](https://drive.google.com/drive/folders/1wJg2BOg26PZanwKYoU6Z8deqSVYScPto?usp=sharing)

## About the project
- [Download](https://drive.google.com/drive/folders/1wJg2BOg26PZanwKYoU6Z8deqSVYScPto?usp=sharing)
- [Summary](#Summary)
- [Tools](#Tools)
- [Packages](#Packages)
- [How it works](#How-it-works)

## Summary
FaceRec is an easy to use application made to detect faces caught in uploaded images and in the users camera. 
The user can upload images or open their camera and FaceRec will detect every face caught in the frame, after which it draws a square around the faces caught and displays the result in the box to the right.

## Tools
- #### Visual Studio
- #### Windows Forms
- #### C#
- #### OpenCVSharp

## Packages
NuGet packages used to create this project:
- #### OpenCV (2.4.11)
- #### OpenCVSharp4 (4.10.0.20240616)
- #### OpenCVSharp4.runtime.win (4.10.0.20240616)
- #### OpenCVSharp4.Extensions (4.10.0.20240616)
- #### System.Drawing.Common (8.0.7)

## How it works
The program takes in individual images or frames from the camera.
I will be refering to both as frames for simplicity, so from here on out know that the same applies for both.

FaceRec will take a frame which is inputted from any of the following functions:

    picBox_DragDrop(object sender, DragEventArgs e)
    uploadImage_Click(object sender, EventArgs e)
    openCamera_Click(object sender, EventArgs e)


From here on, the function's that will be called are located in the file Recognition.cs inside FaceCascade.

Inside each of the above functions, except for openCamera_Click(), the program checks if the file type uploaded is valid by calling the function:
If the file checks, it moves on to the next step.

    invalidFile(string filePath)

Afterwards it sets the Picturebox to the following:
    
    picBox.Image = Recognition.detectFaces(frame).ToBitmap();

What this does is it calls the function detectFaces(Mat img), inside this function it does the following:
It loads up two XML files for detecting the front face and the profile, then the image is turned grey and those loaded files will now go through the frame.

One thing to note is that the file for the profile shots cannot detect faces turned to the right,
to solve this the program horizontally flips the original image.

    Mat flippedImage = grayImage;
    Cv2.Flip(flippedImage, flippedImage, FlipMode.Y);
    Rect[] rightFaces = sideCascClassifier.DetectMultiScale(
        flippedImage, 1.1, 2, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(40, 40));

Afterwards it takes the result and calculates to get the original coordinates of the face in the frame:

    Rect[] rightSideFaces = new Rect[rightFaces.Length];

    // Adjusts the flipped image to the coordinates of the original
    for (int i = 0; i < rightFaces.Length; i++){
        Rect face = rightFaces[i];
        rightSideFaces[i] = new Rect(grayImage.Width - face.X - face.Width, face.Y, face.Width, face.Height);
    }

Now it's nearly done, all that's left to do is store every frame in one array:

    Rect[] faces = new Rect[frontFaces.Length + leftSideFaces.Length + rightSideFaces.Length];
    frontFaces.CopyTo(faces, 0);
    leftSideFaces.CopyTo(faces, frontFaces.Length);
    rightSideFaces.CopyTo(faces, frontFaces.Length + leftSideFaces.Length);

And return the result by calling another function, drawRectangles(Mat img, Rect[] faces, int i), which draws a rectangle around the faces found in the frame.

    return drawRectangles(img, faces, 0);
