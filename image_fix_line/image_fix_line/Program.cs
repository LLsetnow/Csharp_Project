using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace image_fix_line
{
    internal class Program
    {
        #region 计时器使用教程
        //using System.Diagnostics;
        // 创建一个 Stopwatch 对象
        /*        Stopwatch stopwatch = new Stopwatch();

                // 启动计时器
                stopwatch.Start();

                // 执行需要计时的代码块
                DoSomethingTimeConsuming();

                // 停止计时器
                stopwatch.Stop();

                // 获取经过的时间
                TimeSpan elapsed = stopwatch.Elapsed;

                // 打印执行时间
                Console.WriteLine($"执行时间: {elapsed.TotalMilliseconds} 毫秒");

                // 如果需要，可以重置计时器以便在未来再次使用
                stopwatch.Reset();*/
        #endregion
        #region 图像使用教程
        /*
         * using System.Drawing;
         * using System.Drawing.Imaging;
            //Bitmap 创建的彩色图像空间

            // 读取灰度图像
            Bitmap image = new Bitmap("D:\\Csharp Project\\gray_image\\image_input\\1.JPG");
            int image_w = image.Width;
            int image_h = image.Height;

            // 创建一张图像 用于存储输出 灰度图像
            Bitmap Image_gray_output = new Bitmap(image_w, image_h);

            //创建二维数组来存储灰度图像  灰度值
            byte[,] image_gray = new byte[image_h, image_w];

            Color pixel = image.GetPixel(x, y);

            byte grayValue = (byte)((pixel.R + pixel.G + pixel.B) / 3);

            image_gray[y, x]   = grayValue;

             //给像素点的 R,G,B 值赋值
             //输出像素点信息
             Color grayColor = Color.FromArgb(image_gray[y, x], image_gray[y, x], image_gray[y, x]);

            //给图像对象的像素点 赋值
            Image_gray_output.SetPixel(x, y, grayColor);

            //保存图像
            Image_gray_output.Save("D:\\Csharp Project\\gray_image\\image_output\\648_gray.png", ImageFormat.Png);
        
            //批量操作
            //输入文件夹地址
            static string in_folder_path = "D:\\Csharp Project\\image_fix_line\\image_input";
            // 获取所有以 ".png" 扩展名的图像文件
            string[] imageFiles = Directory.GetFiles(in_folder_path, "*.png"); 
            //遍历文件夹
            foreach (string imagePath in imageFiles)
            {
                //更新下一张图
                image = new Bitmap(imagePath);
                // 获取输入图像文件的名称
                string input_name = Path.GetFileName(imagePath); 
                //构建目标文件的完整路径
                string output_file = Path.Combine(out_folder_path, input_name); 
                //将image_binary_out图像空间 以Png格式 在output_file文件地址处保存
                image_binary_out.Save(output_file, ImageFormat.Png);
            }
         
         */


        #endregion

        #region 文本使用教程

        /*        //创建文本文件:
                File.Create(out_file_path).Close();

                //创建新文件，并全部写入；若文件存在，覆盖写入
                File.WriteAllText(out_file_path, out_text);*/

        #endregion

        #region 文件管理变量
        static int image_w = 186;                                                       //图像宽
        static int image_h = 70;                                                        //图像高

        Bitmap image = new Bitmap(image_w, image_h);                                          //创建输入图像空间
        Bitmap image_binary_out = new Bitmap(image_w, image_h);                               //创建输出图像空间

        static string in_folder_path = "D:\\Csharp Project\\image_fix_line\\image_input";     //输入文件夹地址
                                                                                              //static string in_folder_path = "D:\\Smart Car\\摄像头上位机\\图片\\原图";             //输入文件夹地址


        string[] imageFiles = Directory.GetFiles(in_folder_path, "*.png");                    //获取文件夹内 png后缀的所有文件的完整文件
                                                                                              //string[] imageFiles = Directory.GetFiles(in_folder_path, "*.bmp");                    //获取文件夹内 png后缀的所有文件的完整文件

        string out_folder_path = "D:\\Csharp Project\\image_fix_line\\image_output";          //输出文件夹地址
                                                                                              //string out_folder_path = "D:\\Csharp Project\\image_fix_line\\image_output_bmp";          //输出文件夹地址

        string input_name;              //输入图像文件的名称
        string output_file;             //输出文件的完整路径

        string err_file;                //记录报错文件数据
        int file_count = 0;                //记录当前处理到第几个图像

        #endregion

        #region 全局变量定义

        //记录当次图像信息
        string ShowText = string.Empty;                     //输出日志

        byte Mode = 1;                                      //输出日志模式

        byte black_high = 2;

        byte[][] image_zip = new byte[70][]
        {
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
        };
        byte[][] image_binary = new byte[70][]
        {
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
            new byte[186], new byte[186],  new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186], new byte[186],
        };

        byte ostu = 115;                                    //二值化阈值
        byte black = 0;
        byte white = 255;

        byte threshold_max = 5;                             //降噪腐蚀膨胀参数
        byte threshold_min = 3;                             //降噪腐蚀膨胀参数

        byte valid_row = 0;                                 //扫线有效终点行   最小值为1

        byte[] midline = new byte[70 + 1];                  //中线数组，从下（59-0）往上找
        byte[] leftline = new byte[70];                     //扫线左线数组
        byte[] rightline = new byte[70];                    //扫线右线数组

        byte curve = 0;                                     //评估中线弯曲程度 计算量
        byte[] one_line = { 20, 20, 30 };                   //前瞻
        byte car_state;                                     //路况

        byte left_lost_line = 0;                            //左线丢线行数
        byte right_lost_line = 0;                           //右线丢线行数

        byte line_find_count = 0;                           //统计扫线次数

        int variance_r = 0;                                 //右边线偏方差
        int variance_l = 0;                                 //左边线偏方差

        inf_point_t left_down, right_down, left_up, right_up,
                    left_down_tilt, right_down_tilt, left_up_tilt, right_up_tilt;   //拐点结构体

        /*      标志位     */
        byte flag_cross = 0;                                    //可能进入十字标志位  1为进入 0为未进入
        byte flag_buxian = 0;                                   //是否经过补线标志位
        byte Tilt_Cross_Flag = 0;                               //斜入十字标志位
        byte flag_extention_out = 0;                            //延长线是否出界

        /*      环岛      */
        byte Island_Status_Flag = 0;
        byte Island_Flag = 0;

        #endregion

        #region main函数
        static void Main()
        {
            Program program = new Program(); // 创建类实例
            program.ProcessImages();

        }
        #endregion

        #region 主函数
        public void ProcessImages()
        {
            //输入图像  压缩后图像    二值化图像     二值化补线图像
            //image -> image_zip -> image_binary -> image_binary_out

            Stopwatch stopwatch = new Stopwatch();
            TimeSpan elapsed = stopwatch.Elapsed;
            TimeSpan elapsed_pre = stopwatch.Elapsed;

            //遍历文件夹
            //参数说明：imagePath为输入图像完整路径
            foreach (string imagePath in imageFiles)
            {
                //计时器开始计时
                stopwatch.Start();
                //图像文件
                image = new Bitmap(imagePath);                                  //更新下一张图
                input_name = Path.GetFileName(imagePath);                       //获取输入图像文件的名称
                /*                input_name = Path.GetFileNameWithoutExtension(imagePath);     //转换为png格式
                                input_name = $"{input_name}.png";                               //转换为png格式*/
                output_file = Path.Combine(out_folder_path, input_name);        //构建输出文件的完整路径

                //txt文件
                string input_Name = Path.GetFileNameWithoutExtension(imagePath);//获取图像文件的名称（不包括扩展名）
                string out_txet_name = $"{input_Name}.txt";                     //创建相应的txt文件名
                string out_text_file = Path.Combine(out_folder_path, out_txet_name);//构建输出txt的完整路径

                file_count++;                   //第n张图

                camera_variable_init();         //全部参数初始化
                get_image_binary();             //图像二值化
                get_image_filter();             //形态学滤波（膨胀+腐蚀）
                line_find();                    //扫线
                count_lost_line();              //计算丢线
                variance_calculation(0, 69);    //偏方差计算
                find_down_inf(68, 10);           //找下拐点（防止数组越界，保证start<=68，end>=10）
                find_up_inf(59, 2);             //找上拐点（防止数组越界，保证start<=65，end>=2）
                printf_cross();                 //打印拐点数据

                try { Island_Small(); }                 //小环岛
                catch { }

                cross_judge();                  //十字判断和预处理
                cross_process();                //十字补线
                tilt_cross_judge();             //斜入十字判断
                tilt_cross_process();           //斜入十字补线处理
                final_line_find();              //补线后再次扫线
                draw_line();                    //最终计算中线  并用线画出左、中、右线
                save_image();                   //将结果保存为图像


                File.WriteAllText(out_text_file, ShowText);     //创建文档 记录每张图扫线状况
                elapsed = stopwatch.Elapsed;    //获取当前时间
                double cost_time = elapsed.TotalMilliseconds - elapsed_pre.TotalMilliseconds;   //计算单张时间
                elapsed_pre = elapsed;          //更新上一次的值
                Console.Write(input_name);      //打印图像文件名
                Console.Write("                           ");
                Console.Write("{0} / {1}         {2:F1}%             ", file_count, imageFiles.Length, (float)file_count / (float)imageFiles.Length * 100);
                Console.WriteLine("耗时：{0:F2}毫秒       总时长：{1:F2}秒", cost_time, elapsed.TotalSeconds);
            }

            string err_out_text = Path.Combine(out_folder_path, "err.txt");
            Console.WriteLine("");
            Console.WriteLine("**************补线图像处理完成****************");
            if (string.IsNullOrEmpty(err_file))
            {
                err_file += "****************无数组越界****************";
                Console.WriteLine("****************无数组越界****************");
            }
            File.WriteAllText(err_out_text, err_file);     //创建文档 记录每张图扫线状况
            Console.WriteLine("(任意键以关闭此页面)");
            Console.ReadKey();
        }

        #endregion

        #region 图像函数

        /*      全部数据初始化       */
        public void camera_variable_init()
        {
            /************拐点数据初始化***********/
            inf_init(ref right_up);
            inf_init(ref left_up);
            inf_init(ref right_down);
            inf_init(ref left_down);

            inf_init(ref right_up_tilt);
            inf_init(ref left_up_tilt);
            inf_init(ref right_down_tilt);
            inf_init(ref left_down_tilt);

            /**********道路特征初始化***********/
            //line_init();
            valid_row = 0;        //最高行，tip：这里的最高指的是y值的最小
            left_lost_line = 0;
            right_lost_line = 0;
            variance_l = 0;
            variance_r = 0;

            /*******************杂*********************/
            //mt9v03x_finish_flag = 0;    //清除摄像头标志位
            flag_buxian = 0;
            line_find_count = 0;
            flag_extention_out = 0;
            //不要初始化 flag_cross

            /****************输出日志****************/
            ShowText = string.Empty;
            ShowText += "\r\n\r\n";
            ShowText += "************************  " + input_name + "  " + string.Format("第{0}张", file_count) + "  ************************";
            ShowText += "\r\n\r\n";
        }

        /*      拐点数据初始化     */
        public void inf_init(ref inf_point_t point)
        {
            point.x = 0;
            point.y = 0;
            point.flag = 0;
        }
        /*      图像二值化       */
        public void get_image_binary()
        {
            byte i, j;
            for (i = 0; i < image_h; i++)
            {
                for (j = 0; j < image_w; j++)
                {
                    Color pixel = image.GetPixel(j, i);
                    byte grayValue = (byte)((pixel.R + pixel.G + pixel.B) / 3);

                    image_zip[i][j] = grayValue;
                    if (image_zip[i][j] > ostu)
                        image_binary[i][j] = white;
                    else image_binary[i][j] = black;
                }
            }
        }

        /*      打印拐点坐标      */
        public void printf_cross()
        {
            if (left_up.flag == 0 && right_up.flag == 0) ShowText += string.Format("↖未找到            未找到↗\r\n");
            if (left_up.flag == 0 && right_up.flag == 1) ShowText += string.Format("↖未找到              找到↗\r\n");
            if (left_up.flag == 1 && right_up.flag == 0) ShowText += string.Format("↖找到              未找到↗\r\n");
            if (left_up.flag == 1 && right_up.flag == 1) ShowText += string.Format("↖找到                找到↗\r\n");

            if (left_down.flag == 0 && right_down.flag == 0) ShowText += string.Format("↙未找到            未找到↘\r\n");
            if (left_down.flag == 0 && right_down.flag == 1) ShowText += string.Format("↙未找到              找到↘\r\n");
            if (left_down.flag == 1 && right_down.flag == 0) ShowText += string.Format("↙找到              未找到↘\r\n");
            if (left_down.flag == 1 && right_down.flag == 1) ShowText += string.Format("↙找到                找到↘\r\n");


            if (left_up.flag == 1)
                ShowText += string.Format("左上拐点坐标 = [{0}][{1}]\r\n", left_up.y, left_up.x);
            if (right_up.flag == 1)
                ShowText += string.Format("右上拐点坐标 = [{0}][{1}]\r\n", right_up.y, right_up.x);

            if (left_down.flag == 1)
                ShowText += string.Format("左下拐点坐标 = [{0}][{1}]\r\n", left_down.y, left_down.x);
            if (right_down.flag == 1)
                ShowText += string.Format("右下拐点坐标 = [{0}][{1}]\r\n", right_down.y, right_down.x);

        }

        /*      形态学滤波（膨胀+腐蚀）       */
        public void get_image_filter()
        {
            int i, j;
            int num;
            for (i = 1; i < image_h - 1; i++)
            {
                for (j = 1; j < (image_w - 1); j++)
                {
                    //统计八个方向的像素值
                    num =
                        image_binary[i - 1][j - 1] + image_binary[i - 1][j] + image_binary[i - 1][j + 1]
                        + image_binary[i][j - 1] + image_binary[i][j + 1]
                        + image_binary[i + 1][j - 1] + image_binary[i + 1][j] + image_binary[i + 1][j + 1];

                    if (num >= threshold_max * white && image_binary[i][j] == black)
                    {

                        image_binary[i][j] = white;

                    }
                    if (num <= threshold_min * white && image_binary[i][j] == white)
                    {

                        image_binary[i][j] = black;

                    }

                }
            }
        }

        /*      边线数组初始化     */
        public void line_init()
        {
            int i;
            valid_row = 0;
            for (i = 0; i < image_h; i++)
            {
                rightline[i] = (byte)(image_w - 1);
                leftline[i] = 0;
                midline[i] = 0;
            }
        }

        /*      基础寻线        */
        public void line_find()
        {
            int i, j;
            line_init();
            line_find_count++;
            if (Mode == 1 || Mode == 2) ShowText += string.Format("\r\n第{0}次扫线:\r\n\r\n", line_find_count);
            //偏离跑道 加起点
            if (image_binary[image_h - 1][image_w / 2] == black)       //中点为黑
            {
                if (image_binary[image_h - 1][5] == white)
                    midline[image_h] = 5;
                else if (image_binary[image_h - 1][image_w - 5] == white)
                    midline[image_h] = (byte)(image_w - 5);
                else
                    midline[image_h] = (byte)(image_w / 2);
            }
            else midline[image_h] = (byte)(image_w / 2);

            //扫线
            for (i = image_h - 1; i > 0; i--)
            {
                //找左线
                for (j = midline[i + 1]; j >= 0; j--)                    //以上一个中点为起点开始向左扫线
                {
                    if (image_binary[i][j] == black || j == 0)
                    {
                        leftline[i] = (byte)j;
                        if (flag_cross == 1 && leftline[i] <= 20 && i < 35) leftline[i] = 0;
                        break;
                    }
                }

                //找右线
                for (j = midline[i + 1]; j <= image_w - 1; j++)            //以上一个中点为起点开始向右扫线
                {
                    if (image_binary[i][j] == black || j == image_w - 1)
                    {
                        rightline[i] = (byte)j;
                        if (flag_cross == 1 && rightline[i] >= image_w - 20 && i < 35) rightline[i] = (byte)(image_w - 1);
                        break;
                    }
                }

                midline[i] = (byte)((leftline[i] + rightline[i]) / 2);

                //扫线终止行
                if ((ABS((int)leftline[i] - (int)rightline[i]) < 2)
                    || (i < black_high)        // i = 1
                    || (image_binary[i - 1][midline[i]] == black))
                {
                    valid_row = (byte)i;
                    if (Mode == 1 || Mode == 2) ShowText += string.Format("扫线最远行 = {0}\r\n", valid_row);
                    break;
                }
            }
            //发送边线坐标
            if (Mode == 1)
            {
                for (i = valid_row; i < image_h; i++)
                {

                    ShowText += string.Format("左边线 = [{0}][{1}]    右边线 = [{2}][{3}]\r\n", i, leftline[i], i, rightline[i]);
                }
            }

        }

        /*      最终扫线        */
        public void final_line_find()
        {
            if (flag_buxian == 1)
            {
                ShowText += string.Format("最终扫线\r\n");
                line_find();
            }
        }

        /*      斜入十字 从下往上寻找上拐点       */
        //参数说明：point 为 下拐点坐标  point_find 为找到的上拐点
        //参数说明：dir 是找拐点方向 1 为向右找 2 为向左找
        public void find_up_tilt(inf_point_t point, byte dir, ref inf_point_t point_find)
        {
            byte i, j;
            byte[] line = new byte[186];     //
            if (dir == 1)
            {
                for (j = (byte)(point.x + 1); j < image_w; j++)
                {
                    for (i = point.y; i >= 0; i--)
                    {
                        if (image_binary[i][j] == black || i == 0)
                        {
                            line[j] = i;
                            //ShowText += string.Format("[{0}][{1}]\r\n", line[j], j);
                            break;
                        }
                    }
                    //等待存储完11个坐标
                    if (j - point.x >= 11)
                    {
                        // j-10,j-2,j-1,j
                        if (line[j - 2] == line[j - 1]
                            && line[j - 1] > line[j]
                            && line[j - 1] > line[j - 10])
                        {
                            point_find.y = line[j - 1];
                            point_find.x = (byte)(j - 1);
                            point_find.flag = 1;

                            if (Mode == 2) ShowText += string.Format("找到斜入上拐点[{0}][{1}]\r\n", point_find.y, point_find.x);
                            break;
                        }
                    }
                }
            }
        }

        /*      固定扫线中点为 mid 列       */
        public void fixed_line_find(byte mid)
        {
            byte i, j;
            line_init();
            line_find_count++;
            if (Mode == 1 || Mode == 2)
            {
                ShowText += string.Format("\r\n第{0}次扫线:\r\n\r\n", line_find_count);
                ShowText += string.Format("固定寻线列 = {0}\r\n", mid);
            }
            if (mid > image_w - 1)
            {
                mid = (byte)(image_w - 1);
            }
            //扫线
            for (i = (byte)(image_h - 1); i > 0; i--)
            {
                /*  找左线   */
                for (j = mid; j > 0; j--)                    //以上一个中点为起点开始向左扫线
                {
                    if (image_binary[i][j] == black || j == 0)
                    {
                        leftline[i] = j;
                        if (flag_cross == 1 && leftline[i] <= 20 && i < 35) leftline[i] = 0;
                        break;
                    }
                }

                /*  找右线   */
                for (j = mid; j <= image_w - 1; j++)            //以上一个中点为起点开始向右扫线
                {
                    if (image_binary[i][j] == black || j == image_w - 1)
                    {
                        rightline[i] = j;
                        if (flag_cross == 1 && rightline[i] >= image_w - 20 && i < 35) rightline[i] = (byte)(image_w - 1);
                        break;
                    }
                }

                //扫线终止行
                if ((ABS(leftline[i] - rightline[i]) < 2) || (i < black_high))    // i = 1
                {
                    valid_row = i;
                    if (Mode == 1 || Mode == 2) ShowText += string.Format("扫线最远行  = {0}\r\n", valid_row);
                    break;
                }
            }

            if (Mode == 1)
            {
                for (i = valid_row; i < image_h; i++)
                {
                    ShowText += string.Format("左边线 = [{0}][{1}]    左边线 = [{2}][{3}]\r\n", i, leftline[i], i, rightline[i]);
                }
            }
        }

        /*      计数丢线行       */
        public void count_lost_line()
        {
            int i;
            left_lost_line = 0;
            right_lost_line = 0;
            for (i = image_h - 1; i >= valid_row; i--)
            {
                if (leftline[i] <= 1) left_lost_line++;
                if (rightline[i] >= image_w - 2) right_lost_line++;
            }

            if (Mode == 1 || Mode == 2)
            {
                ShowText += string.Format("左丢线行数 = {0}\r\n", left_lost_line);
                ShowText += string.Format("右丢线行数 = {0}\r\n", right_lost_line);
            }
        }

        /*      寻找下拐点        */
        //参数说明 ：start 是开始行  end 是结束行  start > end
        public void find_down_inf(byte start, byte end)
        {
            byte i;
            /*      正入左下拐点      */
            for (i = start; i > end; i--)
            {
                //正拐点
                if (leftline[i] - leftline[i - 5] > 20
                    && (leftline[i - 10] == 0 || leftline[i - 5] == 0)
                    && leftline[i] >= leftline[i + 1]
                    && leftline[i] - leftline[i + 1] < 3)

                {
                    left_down.x = leftline[i];
                    left_down.y = i;
                    left_down.flag = 1;
                    break;
                }

                //斜拐点
                if (leftline[i - 5] > leftline[i]
                    && leftline[i - 5] > leftline[i - 10]
                    && (leftline[i - 5] - leftline[i]) > 3
                    && (leftline[i - 5] - leftline[i]) < 25
                    && (leftline[i - 5] - leftline[i - 10]) > 3
                    && (leftline[i - 5] - leftline[i - 10]) < 25)
                {
                    left_down_tilt.x = leftline[i - 5];
                    left_down_tilt.y = (byte)(i - 5);
                    left_down_tilt.flag = 1;
                }
            }

            /*      正入右下拐点      */
            for (i = start; i > end; i--)
            {
                if (rightline[i] - rightline[i - 5] < -20
                    && (rightline[i - 10] == 185 || leftline[i - 5] == 185)
                    && rightline[i] <= rightline[i + 1]
                    && rightline[i] - rightline[i + 1] > -3)
                {
                    right_down.x = rightline[i];
                    right_down.y = i;
                    right_down.flag = 1;
                    break;
                }
            }
            if (Mode == 1 || Mode == 2)
            {
                if (left_down.flag == 1)
                    ShowText += string.Format("左下拐点坐标 = [{0}][{1}]\r\n", left_down.y, left_down.x);
                if (right_down.flag == 1)
                    ShowText += string.Format("右下拐点坐标 = [{0}][{1}]\r\n", right_down.y, right_down.x);
                if (left_down_tilt.flag == 1)
                    ShowText += string.Format("左下斜拐点 = [{0}][{1}]\r\n", left_down_tilt.y, left_down_tilt.x);
            }



        }

        /*      寻找上拐点        */
        //参数说明 ：start 是开始行  end 是结束行  start > end
        public void find_up_inf(byte start, byte end)
        {
            byte i;

            /*      正出左上拐点      */
            for (i = start; i > end; i--)
            {
                if (leftline[i] - leftline[i + 5] > 20
                    && leftline[i + 10] == 0
                    && leftline[i] <= leftline[i - 1]
                    && leftline[i] - leftline[i - 1] > -3)
                {
                    left_up.x = leftline[i];
                    left_up.y = i;
                    left_up.flag = 1;
                    break;
                }
            }


            /*      正出右上拐点      */
            for (i = start; i > end; i--)
            {
                if (rightline[i] - rightline[i + 5] < -20
                    && rightline[i + 10] == 185
                    && rightline[i] >= rightline[i - 1]
                    && rightline[i] - rightline[i - 1] < 3)
                {
                    right_up.x = rightline[i];
                    right_up.y = i;
                    right_up.flag = 1;
                    break;
                }
            }

            if (Mode == 1 || Mode == 2)
            {
                if (left_up.flag == 1)
                    ShowText += string.Format("左上拐点坐标 = [{0}][{1}]\r\n", left_up.y, left_up.x);
                if (right_up.flag == 1)
                    ShowText += string.Format("右上拐点坐标 = [{0}][{1}]\r\n", right_up.y, right_up.x);
            }


        }

        /*      斜入十字判断      */
        public void tilt_cross_judge()
        {
            //右入斜十字
            if (left_lost_line < 5
                && right_lost_line >= 18
                && left_down_tilt.flag == 1
                && right_down_tilt.flag == 0
                    //            && Islanright_up.flag == 0 && Island_Middle_Flag == 0 && Island_Big_Flag == 0
                    )
            {
                if (Mode == 1 || Mode == 2) ShowText += string.Format("右入斜十字\r\n");
                Tilt_Cross_Flag = 1;
            }

            //左入斜十字
            else if (right_lost_line < 5
                && left_lost_line >= 30
                && right_down.flag == 1
                && left_down.flag == 0
                    //            && Islanright_up.flag == 0 && Island_Middle_Flag == 0 && Island_Big_Flag == 0
                    )
            {
                if (Mode == 1 || Mode == 2) ShowText += string.Format("左入斜十字\r\n");
                Tilt_Cross_Flag = 2;
            }
            else
            {
                if (Mode == 1 || Mode == 2) ShowText += string.Format("未发现斜十字\r\n");
            }

            //已满足普通十字条件，退出斜入十字
            if (flag_cross == 1 || (left_lost_line == 0 && right_lost_line == 0)
                    //            || Island_Big_Flag != 0 || Island_Middle_Flag != 0 || Islanright_up.flag != 0
                    )
            {
                Tilt_Cross_Flag = 0;
                if (Mode == 1 || Mode == 2) ShowText += string.Format("退出斜入十字\r\n");
            }
        }

        /*      斜入十字补线      */
        public void tilt_cross_process() //斜入十字补线
        {
            byte i;
            byte end_y;
            //未进行正入十字补线
            if (flag_buxian == 0)
            {
                if (Tilt_Cross_Flag == 1) //右斜入十字补线
                {
                    find_up_tilt(left_down_tilt, 1, ref left_up_tilt);
                    //2拐点补线
                    if (left_up_tilt.flag == 1 && left_down_tilt.flag == 1)
                    {
                        flag_buxian = 1;
                        ShowText += string.Format("斜入2拐点补线\r\n");
                        line_connection(left_up_tilt.x, left_up_tilt.y, left_down_tilt.x, left_down_tilt.y, leftline);
                        line_extension(left_down_tilt.x, left_down_tilt.y, left_up_tilt.x, left_up_tilt.y, leftline, (byte)0, left_up_tilt.y);
                    }
                    //1拐点补线
                    else if (left_down_tilt.flag == 1)
                    {
                        flag_buxian = 1;
                        end_y = (byte)(left_down_tilt.y + 7);
                        if (end_y >= image_h) end_y = (byte)(image_h - 1);
                        ShowText += string.Format("斜入1拐点补线\r\n");
                        line_extension(left_down_tilt.x, left_down_tilt.y, leftline[end_y], end_y, leftline, (byte)0, left_down_tilt.y);
                    }


                    if (rightline[(byte)(image_h - 1)] == (byte)(image_w - 1))
                    {
                        for (i = (byte)(image_h - 1); i >= 1; i--) rightline[i] = (byte)(image_w - 1);
                    }
                    else if (right_up.flag == 1)
                    {
                        line_connection(rightline[(byte)(image_h - 1)], (byte)(image_h - 1), right_up.x, right_up.y, rightline);
                    }


                }
                if (Tilt_Cross_Flag == 2)                    //右斜入
                {

                }
            }
        }

        /*      正常十字判断和预处理以及清除十字标志      */
        public void cross_judge()
        {
            if (flag_cross == 1)//十字标志位清0
            {

                //无拐点 若有全白列 更换扫线方式 并重新寻找拐点
                if (left_down.flag == 0 && right_down.flag == 0 && left_up.flag == 0 && right_up.flag == 0)
                {
                    byte x;
                    x = find_white_line(20, 160, 1);
                    if (x != 0)          // 如果找到全白列
                    {
                        fixed_line_find(x);     //秒啊
                    }
                    find_up_inf(59, 2);
                    find_down_inf(68, 10);

                    if (Mode == 1 || Mode == 2) printf_cross();
                }

                //完全离开十字状态
                if ((left_down.flag == 0 && right_down.flag == 0 && left_up.flag == 0 && right_up.flag == 0)
                 || left_lost_line == 0 || right_lost_line == 0)
                {
                    flag_cross = 0;     //清除十字标志
                    if (Mode == 1 || Mode == 2) ShowText += string.Format("出十字\r\n");
                }
            }

            //进入十字状态判定
            //    if (Island_Flag == 0 && Island_Middle_Flag == 0 && Island_Big_Flag == 0) //如果不是其他元素,对十字进行判断
            //    {
            if ((left_down.flag == 1 && right_down.flag == 1 && left_up.flag == 1 && right_up.flag == 1
                    && left_down.x < right_down.x && left_up.x < right_up.x)
                || (left_down.flag == 1 && right_down.flag == 1 && left_lost_line >= 5 && right_lost_line >= 5 && left_down.x < right_down.x)
                || (left_lost_line >= 20 && right_lost_line >= 20))
            {
                flag_cross = 1;
                if (Mode == 1 || Mode == 2) ShowText += string.Format("发现十字\r\n");
            }
            else
            {
                if (Mode == 1 || Mode == 2) ShowText += string.Format("未发现十字\r\n");
            }
            //    }
        }

        /*      寻找全白列       */
        //参数说明 ：start 是开始列  end 是结束列 start < end
        //参数说明 ：dir决定扫线方向，dir = 1从右往左，dir = 2从左往右）
        //返回说明 ：全白列 列号 若无全白列 返回0
        public byte find_white_line(byte start, byte end, byte dir)
        {
            byte i, j;
            byte x = 0;
            byte white_line = 0;

            if (dir == 1)
            {
                for (i = start; i <= end; i++)
                {
                    for (j = (byte)(image_h - 1); j > 9; j--)
                    {
                        if (image_binary[j][i] == black || i == end)
                        {
                            if (x >= 10)
                            {
                                return (byte)(white_line + x / 2);
                            }
                            else
                            {
                                x = 0;
                                white_line = 0;
                            }
                            break;
                        }

                        // 69 - 10列为全白
                        if (j == 10)
                        {
                            x++;
                            if (white_line == 0)
                                white_line = i;
                        }

                    }
                }
            }
            if (dir == 2)
            {
                for (i = start; i >= end; i--)
                {
                    for (j = (byte)(image_h - 1); j > 9; j--)
                    {
                        if (image_binary[j][i] == black || i == end)
                        {
                            if (x >= 10)
                            {
                                return (byte)(white_line - x / 2);
                            }
                            else
                            {
                                x = 0;
                                white_line = 0;
                            }
                            break;
                        }
                        // 69 - 10列为全白
                        if (j == 10)
                        {
                            x++;
                            if (white_line == 0)
                                white_line = i;
                        }
                    }
                }
            }
            return 0;
        }

        /*      十字补线        */
        public void cross_process()
        {
            if (flag_cross == 1)
            {
                byte x;
                if (left_down.flag == 1 && right_down.flag == 1 && left_down.x < right_down.x) //下拐点符合十字
                {
                    if (Mode == 1 || Mode == 2)
                    {
                        ShowText += string.Format("下拐点符合十字 进行二次扫线\r\n");
                    }
                    fixed_line_find((byte)((left_down.x + right_down.x) / 2));
                    find_up_inf(59, 2);
                }
                else if (left_up.flag == 1 && right_up.flag == 1 && left_up.x < right_up.x) //上拐点符合十字
                {
                    if (Mode == 1 || Mode == 2)
                    {
                        ShowText += string.Format("上拐点符合十字 进行二次扫线\r\n");
                    }
                    fixed_line_find((byte)((left_up.x + right_up.x) / 2));
                    find_up_inf(59, 2);
                }
                else if (left_down.flag == 1 && right_up.flag == 1 && left_down.x < right_up.x)//对角两拐点
                {
                    if (Mode == 1 || Mode == 2)
                    {
                        ShowText += string.Format("对角两拐点符合十字 进行二次扫线\r\n");
                    }
                    fixed_line_find((byte)((left_down.x + right_up.x) / 2));
                    find_up_inf(59, 2);
                }
                else if (right_down.flag == 1 && left_up.flag == 1 && left_up.x < right_down.x)//对角两拐点
                {
                    if (Mode == 1 || Mode == 2)
                    {
                        ShowText += string.Format("对角两拐点符合十字 进行二次扫线\r\n");
                    }
                    fixed_line_find((byte)((right_down.x + left_up.x) / 2));
                    find_up_inf(59, 2);
                }
                else //上下拐点均不符合十字，重新找拐点
                {
                    left_down.flag = 0;
                    right_down.flag = 0;
                    left_up.flag = 0;
                    right_up.flag = 0;
                    x = find_white_line(20, 160, 1);
                    if (x != 0)          // 如果找到全白列
                    {
                        fixed_line_find(x);
                    }
                    find_up_inf(59, 2);
                    find_down_inf(68, 10);
                }

                if (Mode == 1 || Mode == 2) printf_cross();
                int end_y;
                //正入4拐点补线
                if (left_down.flag == 1 && right_down.flag == 1 && left_up.flag == 1 && right_up.flag == 1
                    && left_down.y > left_up.y && right_down.y > right_up.y && left_down.x < right_down.x && left_up.x < right_up.x)
                {
                    flag_buxian = 1;
                    ShowText += string.Format("四拐点补线\r\n");
                    line_connection(left_up.x, left_up.y, left_down.x, left_down.y, leftline);
                    line_connection(right_up.x, right_up.y, right_down.x, right_down.y, rightline);

                }
                //四缺右下拐点补线
                else if (left_down.flag == 1 && left_up.flag == 1 && right_up.flag == 1
                    && (right_down.flag == 0 || right_down.y < right_up.y)
                    && left_down.y > left_up.y
                    && leftline[image_h - 1] != 0)
                {
                    flag_buxian = 1;
                    ShowText += string.Format("四缺右下拐点补线\r\n");

                    end_y = right_up.y - 7;
                    if (end_y < 0) end_y = 0;
                    line_connection(left_up.x, left_up.y, left_down.x, left_down.y, leftline);
                    try
                    {
                        line_extension(right_up.x, right_up.y, rightline[end_y], (byte)end_y, rightline, right_up.y, (byte)69);
                    }
                    catch
                    {
                        Console.WriteLine("ERR");
                        ShowText += string.Format("end_y = {0}\r\n", end_y);
                        err_file += ShowText;
                    }

                }
                //四缺左下拐点补线
                else if (right_down.flag == 1 && left_up.flag == 1 && right_up.flag == 1
                    && (left_down.flag == 0 || left_down.y < right_up.y)
                    && rightline[image_h - 1] != 185)
                {
                    flag_buxian = 1;
                    ShowText += string.Format("四缺左下拐点补线\r\n");

                    end_y = left_up.y - 7;
                    if (end_y < 0) end_y = 0;
                    line_connection(right_up.x, right_up.y, right_down.x, right_down.y, rightline);
                    line_extension(left_up.x, left_up.y, leftline[end_y], (byte)end_y, leftline, left_up.y, (byte)69);
                }
                //上两拐点补线
                else if (left_up.flag == 1 && right_up.flag == 1
                    && (left_down.flag == 0 || left_down.y < right_up.y)
                    && (right_down.flag == 0 || right_down.y < right_up.y))
                {
                    flag_buxian = 1;
                    ShowText += string.Format("上两拐点补线\r\n");

                    end_y = right_up.y - 7;
                    if (end_y < 0) end_y = 0;
                    line_extension(right_up.x, right_up.y, rightline[end_y], (byte)end_y, rightline, right_up.y, (byte)69);

                    end_y = left_up.y - 7;
                    if (end_y < 0) end_y = 0;
                    line_extension(left_up.x, left_up.y, leftline[end_y], (byte)end_y, leftline, left_up.y, (byte)69);
                }
                //下两拐点补线
                else if (left_down.flag == 1 && right_down.flag == 1 && (left_up.flag == 0 || right_up.flag == 0))
                {
                    flag_buxian = 1;
                    ShowText += string.Format("下两拐点补线\r\n");

                    end_y = right_down.y + 7;
                    if (end_y > image_h - 1) end_y = image_h - 1;
                    line_extension(right_down.x, right_down.y, rightline[end_y], (byte)end_y, rightline, (byte)0, right_down.y);

                    end_y = left_down.y + 7;
                    if (end_y > image_h - 1) end_y = image_h - 1;
                    line_extension(left_down.x, left_down.y, leftline[end_y], (byte)end_y, leftline, (byte)0, left_down.y);
                }
                else
                {
                    if (Mode == 1 || Mode == 2)
                        ShowText += string.Format("拐点不符合补线\r\n");
                }

            }
        }

        //连接两点
        //参数说明 ：start < end
        public void line_connection(byte start_x, byte start_y, byte end_x, byte end_y, byte[] border)
        {
            byte i;
            float slope_rate;
            float intercept;

            slope_rate = (float)(start_x - end_x) / (start_y - end_y);
            intercept = (float)((start_y * end_x) - (end_y * start_x)) / (start_y - end_y);
            for (i = end_y; i >= start_y; i--)
            {
                border[i] = (byte)(slope_rate * (i) + intercept); //x = ky+b
                image_binary[i][border[i]] = black;
            }
        }

        //延长一条直线
        //参数说明 ：从start_row < end_row
        public void line_extension(byte start_x, byte start_y, byte end_x, byte end_y, byte[] border, byte start_row, byte end_row)
        {
            byte i;
            float slope_rate;
            float intercept;

            slope_rate = (float)(start_x - end_x) / (start_y - end_y);
            intercept = (float)((start_y * end_x) - (end_y * start_x)) / (start_y - end_y);
            for (i = start_row; i <= end_row; i++)
            {
                border[i] = (byte)(slope_rate * (i) + intercept); //x = ky+b
                if (border[i] < 0 || flag_extention_out == 1)
                {
                    border[i] = 0;
                    flag_extention_out = 1;
                }
                if (border[i] >= image_w || flag_extention_out == 1)
                {
                    border[i] = (byte)(image_w - 1);
                    flag_extention_out = 1;
                }
                image_binary[i][border[i]] = black;
            }
        }

        /*      画出左右线       */
        public void draw_line()
        {
            int i;
            if (valid_row == 0) valid_row = 1;
            for (i = image_h - 1; i >= valid_row; i--)
            {
                //midline[i] = (byte)((leftline[i] + rightline[i]) / 2);

                if (i == image_h - 1) midline[i] = (byte)((leftline[i] + rightline[i]) / 2);
                //低通滤波 让中线变光滑
                else midline[i] = (byte)(midline[i + 1] * 0.4 + (float)(leftline[i] + rightline[i]) / 2 * 0.6);

                /*  以黑线显示中，左，右线  */
                /*                image_binary[i][midline[i]] = 2;
                                image_binary[i][leftline[i]] = 3;
                                image_binary[i][rightline[i]] = 1;*/
            }
        }

        /*      将结果保存为图片        */
        public void save_image()
        {
            byte i, j;
            Color grayColor;
            for (i = 0; i < 70; i++)
            {
                for (j = 0; j < 186; j++)
                {
                    grayColor = Color.FromArgb(image_binary[i][j], image_binary[i][j], image_binary[i][j]);
                    image_binary_out.SetPixel(j, i, grayColor);
                }
                //给边线上色
                try
                {
                    grayColor = Color.FromArgb(0, 47, 167);          //左 克莱因蓝
                    image_binary_out.SetPixel(leftline[i], i, grayColor);

                    grayColor = Color.FromArgb(34, 139, 34);         //中 森林绿
                    image_binary_out.SetPixel(midline[i], i, grayColor);

                    grayColor = Color.FromArgb(178, 34, 34);         //右 火砖
                    image_binary_out.SetPixel(rightline[i], i, grayColor);
                }
                catch
                {
                    Console.WriteLine("ERR");
                    ShowText += String.Format("leftline[{0}]  = {1}\r\n", i, leftline[i]);
                    ShowText += String.Format("midline[{0}]   = {1}\r\n", i, midline[i]);
                    ShowText += String.Format("rightline[{0}] = {1}\r\n", i, rightline[i]);
                    err_file += ShowText;
                    break;
                }
            }
            image_binary_out.Save(output_file, ImageFormat.Png);    //保存图像至指定文件夹
            ShowText += string.Format("当前图像结束处理\r\n\r\n");
        }


        void Island_Small() //小环岛
        {
            Island_Judge();
            Island_Status();
            Island_Status_Process();
        }



        void Island_Judge() // 小环岛判断
        {
            if (Island_Flag == 0 && right_up.flag == 1 && right_up.y > 40 && variance_l < 100 && variance_r > 10000 && right_lost_line > 0 && left_lost_line == 0)//弯接环判断右小环岛
            {
                Island_Flag = 2;
                Island_Status_Flag = 3;//直接进入右环岛第三阶段
            }
            if (Island_Flag == 0 && left_up.flag == 1 && left_up.y > 40 && variance_r < 100 && variance_l > 10000 && left_lost_line > 0 && right_lost_line == 0)//弯接环判断左小环岛
            {
                Island_Flag = 1;
                Island_Status_Flag = 3;//直接进入左环岛第三阶段
            }
            if (Island_Flag == 0 && leftline[left_down.y + 3] == 185 && rightline[20] > 10 && variance_r < 100 && variance_l > 1000 && left_down.flag == 1 && right_down.flag == 0 && left_up.flag == 0 && right_lost_line == 0) //判断左环岛
            {
                Island_Flag = 1;
            }
            if (Island_Flag == 0 && rightline[right_down.y + 3] == 0 && leftline[20] < 180 && variance_l < 100 && variance_r > 1000 && right_down.flag == 1 && left_down.flag == 0 && right_up.flag == 0 && left_lost_line == 0) //判断右环岛
            {
                Island_Flag = 2;
            }
        }

        void Island_Status() // 小环岛状态变换
        {
            if (Island_Flag == 1) //左小环岛
            {
                ///////////////////////////////再次扫线找拐点帮助判断下次状态
                if (Island_Status_Flag == 2 || Island_Status_Flag == 3 || Island_Status_Flag == 7 || Island_Status_Flag == 8)
                {
                    fixed_line_find((byte)((int)rightline[20] + Half_Width(20)));
                    find_up_inf(5, 65);
                }
                //////////////////////////////
                if (Island_Status_Flag == 0 && left_down.flag == 1)//A点存在
                {
                    Island_Status_Flag = 1;
                }
                if (Island_Status_Flag == 1 && left_down.flag == 0)//A点消失
                {
                    Island_Status_Flag = 2;
                }
                if (Island_Status_Flag == 2 && left_up.flag == 1 && left_up.y < 55 && leftline[left_up.y - 1] == 185)
                {
                    Island_Status_Flag = 3;
                }
                if (Island_Status_Flag == 3 && left_up.flag == 0)
                {
                    Island_Status_Flag = 4;
                }
                if (Island_Status_Flag == 4 && right_down.flag == 1)
                {
                    Island_Status_Flag = 5;
                }
                if (Island_Status_Flag == 5 && right_down.flag == 0)
                {
                    Island_Status_Flag = 6;
                }
                if (Island_Status_Flag == 6 && right_lost_line == 0)
                {
                    Island_Status_Flag = 7;
                }
                if (Island_Status_Flag == 7 && left_up.flag == 1 && left_up.y < 55 && leftline[left_up.y - 1] == 185)
                {
                    Island_Status_Flag = 8;
                }
                if (Island_Status_Flag == 8 && left_up.flag == 0 && (left_lost_line <= 10 || variance_r > 10000))
                {
                    Island_Status_Flag = 0;
                    Island_Flag = 0;
                }
            }
            if (Island_Flag == 2) //右小环岛
            {
                //再次扫线找拐点帮助判断下次状态
                if (Island_Status_Flag == 2 || Island_Status_Flag == 3 || Island_Status_Flag == 7 || Island_Status_Flag == 8)
                {
                    fixed_line_find((byte)((int)(leftline[20]) - (Half_Width(20))));
                    find_up_inf(5, 65);
                }

                if (Island_Status_Flag == 0 && right_down.flag == 1 && rightline[right_down.y + 2] == 0)//B点存在
                {
                    Island_Status_Flag = 1;
                }
                if (Island_Status_Flag == 1 && right_down.flag == 0)//B点消失
                {
                    Island_Status_Flag = 2;
                }
                if (Island_Status_Flag == 2 && right_up.flag == 1 && right_up.y < 55 && rightline[right_up.y - 1] == 0)//D点存在
                {
                    Island_Status_Flag = 3;
                }
                if (Island_Status_Flag == 3 && right_up.flag == 0)//C点消失
                {
                    Island_Status_Flag = 4;
                }
                if (Island_Status_Flag == 4 && left_down.flag == 1)//A点出现
                {
                    Island_Status_Flag = 5;
                }
                if (Island_Status_Flag == 5 && left_down.flag == 0)//A点消失
                {
                    Island_Status_Flag = 6;
                }
                if (Island_Status_Flag == 6 && left_lost_line == 0)
                {
                    Island_Status_Flag = 7;
                }
                if (Island_Status_Flag == 7 && right_up.flag == 1 && right_up.y < 55)//D点存在
                {
                    Island_Status_Flag = 8;
                }
                if (Island_Status_Flag == 8 && right_up.flag == 0 && (right_lost_line <= 10 || variance_l > 10000))
                {
                    Island_Status_Flag = 0;
                    Island_Flag = 0;
                }
            }
        }

        void Island_Status_Process() // 小环岛处理
        {
            int x3, x4;
            if (Island_Flag == 1)//左小环岛
            {
                if (Island_Status_Flag == 1) //A点存在
                {
                    //Down_Slope_Buxian(AX, left_down.y, leftline);
                    for (int j = 0; j < 70; j++)
                    {
                        x3 = rightline[j] + 2 * Half_Width(j);
                        if (x3 > 184) x3 = 184;
                        image_binary[j][x3] = 0;
                        flag_buxian = 1;
                    }
                }
                if (Island_Status_Flag == 2)
                {
                    for (int j = 0; j < 70; j++)
                    {
                        x3 = rightline[j] + 2 * Half_Width(j);
                        if (x3 > 184) x3 = 184;
                        image_binary[j][x3] = 0;
                        flag_buxian = 1;
                    }
                }
                if (Island_Status_Flag == 3)
                {
                    Pot_Buxian(10, 0, left_up.x, left_up.y + 1);
                }
                if (Island_Status_Flag == 4)
                {
                    flag_buxian = 1;
                }
                if (Island_Status_Flag == 5)
                {
                    Pot_Buxian(right_down.x, right_down.y, 185, 60);
                }
                if (Island_Status_Flag == 6)
                {
                    Pot_Buxian(30, 0, 185, 65);
                }
                if (Island_Status_Flag == 7)
                {
                    for (int j = 0; j < 70; j++)
                    {
                        x4 = rightline[j] + 2 * Half_Width(j);
                        if (x4 > 185) x4 = 185;
                        image_binary[j][x4] = 0;
                        flag_buxian = 1;
                    }
                }
                if (Island_Status_Flag == 8)
                {
                    for (int j = 0; j < 70; j++)
                    {
                        x4 = rightline[j] + 2 * Half_Width(j);
                        if (x4 > 185) x4 = 185;
                        image_binary[j][x4] = 0;
                        flag_buxian = 1;
                    }
                }
                final_line_find();
            }
            if (Island_Flag == 2) //右小环岛处理
            {
                if (Island_Status_Flag == 1) //B点存在
                {
                    //Down_Slope_Buxian(right_down.x, right_down.y, rightline);
                    for (int j = 0; j < 70; j++)
                    {
                        x3 = leftline[j] - 2 * Half_Width(j);
                        if (x3 < 0) x3 = 0;
                        image_binary[j][x3] = 0;
                        flag_buxian = 1;
                    }
                }
                if (Island_Status_Flag == 2)
                {
                    for (int j = 0; j < 70; j++)
                    {
                        x3 = leftline[j] - 2 * Half_Width(j);
                        if (x3 < 0) x3 = 0;
                        image_binary[j][x3] = 0;
                        flag_buxian = 1;
                    }
                }
                if (Island_Status_Flag == 3)
                {
                    Pot_Buxian(180, 0, right_up.x, right_up.y + 1);
                }
                if (Island_Status_Flag == 4)
                {
                    flag_buxian = 1;
                }
                if (Island_Status_Flag == 5)
                {
                    Pot_Buxian(110, 0, 0, 50);
                }
                if (Island_Status_Flag == 6)
                {
                    Pot_Buxian(140, 0, 0, 50);
                }
                if (Island_Status_Flag == 7)
                {
                    for (int j = 0; j < 70; j++)
                    {
                        x3 = leftline[j] - 2 * Half_Width(j);
                        if (x3 < 0) x3 = 0;
                        image_binary[j][x3] = 0;
                        flag_buxian = 1;
                    }
                }
                if (Island_Status_Flag == 8)
                {
                    for (int j = 0; j < 70; j++)
                    {
                        x3 = leftline[j] - 2 * Half_Width(j);
                        if (x3 < 0) x3 = 0;
                        image_binary[j][x3] = 0;
                        flag_buxian = 1;
                    }
                }
                final_line_find();
            }
        }

        #endregion

        #region 路况判断函数

        /*      路弯曲程度计算     */
        public void road_judgment()
        {
            byte i;
            //    uint8 middle_row = (image_h - 1 + valid_row)/2;
            byte middle_row = one_line[car_state];

            float sum = 0;
            float middle_row_average;
            for (i = (byte)(middle_row - 5); i < middle_row + 5; i++)
            {
                sum += midline[i];
            }
            middle_row_average = sum / 10;
            sum = 0;
            for (i = (byte)(middle_row - 5); i < middle_row + 5; i++)
            {
                sum += ABS(midline[i] - (byte)middle_row_average);
            }
            curve = (byte)sum;
        }

        /*      偏方差计算     */
        void variance_calculation(int start, int end)
        {
            double k1, k2;
            int i;
            for (i = start; i <= end; i++)             //计算偏方差
            {
                k2 = (double)((end - start) * 1.0 / (rightline[end] - rightline[start]));
                variance_r += (int)((rightline[i] - (rightline[15] + (i - 15) / k2)) * (rightline[i] - (rightline[15] + (i - 15) / k2)));
                k1 = (double)((end - start) * 1.0 / (leftline[end] - leftline[start]));
                variance_l += (int)((leftline[i] - (leftline[15] + (i - 15) / k1)) * (leftline[i] - (leftline[15] + (i - 15) / k1)));
            }
            ShowText += string.Format("variance_l = {0}\r\n", variance_l);
            ShowText += string.Format("variance_r = {0}\r\n", variance_r);
        }




        #endregion
        #region 功能函数
        public int ABS(int a)
        {
            if (a < 0) a = -a;
            return a;
        }

        int Half_Width(int h)
        {
            int Half_width;
            Half_width = ((int)(-1.03 * h) + 106) / 2;
            return Half_width;
        }

        void Pot_Buxian(int downx, int downy, int upx, int upy)//两点补线（需要上下拐点坐标）
        {
            double k1, x;
            int j;
            k1 = (double)(((double)upy - (double)downy) / ((double)upx - (double)downx));
            for (j = downy; j < upy; j++)
            {
                x = (double)downx + ((double)j - (double)downy) / (double)k1;
                if (x < 0)
                {
                    x = 0;
                }
                if (x > 184)
                {
                    x = 184;
                }
                image_binary[j][(int)x] = 0;
                flag_buxian = 1;
            }
        }

        #endregion

        #region 颜色表
        //RGB(129, 216, 207)蒂芙尼蓝
        //RGB(251, 210, 106)申布伦黄
        //RGB( 64, 224, 208)只此青绿
        //RGB(  0,  47, 167)克莱因蓝
        //RGB( 34, 139,  34)森林绿
        //RGB(178,  34,  34)火砖
        #endregion

    }


    #region 结构体
    public struct inf_point_t
    {
        public byte x;
        public byte y;
        public byte flag;
    }
    #endregion
}
