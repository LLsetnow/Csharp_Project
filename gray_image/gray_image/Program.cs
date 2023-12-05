using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace gray_image
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            //Bitmap 创建的彩色图像空间

            // 读取灰度图像
            Bitmap image = new Bitmap("D:\\Csharp Project\\gray_image\\image_input\\1.JPG");
   
            int image_w = image.Width;
            int image_h = image.Height;


            // 创建一张图像 用于存储输出 灰度图像
            Bitmap Image_gray_output = new Bitmap(image_w, image_h);

            //创建二维数组来存储灰度图像  灰度值
            byte[,] image_gray = new byte[image_h, image_w];


            // 创建一张图像 用于存储输出 二值化图像
            Bitmap Image_binary_output = new Bitmap(image_w, image_h);

            // 创建二维数组来存储二值化图像 灰度值（0，1）
            byte[,] image_binary = new byte[image_h, image_w];


            for (y = 0; y < image_h; y++)
            {
                for (x = 0; x < image_w; x++)
                {
                    //输入像素点信息
                    Color pixel = image.GetPixel(x, y);

                    // 使用R、G、B分量的平均值 计算灰度值
                    byte grayValue = (byte)((pixel.R + pixel.G + pixel.B) / 3);



                    image_gray[y, x]   = grayValue;
                    image_binary[y, x] = (byte)(grayValue / 255);



                    //给像素点的 R,G,B 值赋值
                    //输出像素点信息
                    Color grayColor = Color.FromArgb(image_gray[y, x], image_gray[y, x], image_gray[y, x]);

                    //给图像对象的像素点 赋值
                    Image_gray_output.SetPixel(x, y, grayColor);

                }

            }

            //保存图像
            Image_gray_output.Save("D:\\Csharp Project\\gray_image\\image_output\\648_gray.png", ImageFormat.Png);
            
        }
    }
}
