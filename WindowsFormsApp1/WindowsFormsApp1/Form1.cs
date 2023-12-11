using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //窗口加载初始化函数
        private void Form1_Load(object sender, EventArgs e)
        {
            text_Serial_port();
            Initialization();
            //添加 MouseMove 事件处理程序
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            //pictureBox1.Paint += PictureBox1_Paint;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //初始化
        private void Initialization()
        {
            comboBox2.Text = "1";
            comboBox3.Text = "8";
            comboBox4.Text = "115200";
            comboBox5.Text = "无";

        }


        //获取电脑串口
        private void text_Serial_port()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames(); //获得可用的串口
            for (int i = 0; i < ports.Length; i++)
            {
                comboBox1.Items.Add(ports[i]);
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count > 0 ? 0 : -1;//如果里面有数据,显示第0个
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Text == "打开串口")
            {
                try
                {
                    serialPort1.PortName = comboBox1.Text;//获取要打开的串口
                    serialPort1.BaudRate = int.Parse(comboBox4.Text);//获得波动率
                    serialPort1.DataBits = int.Parse(comboBox3.Text);//获得数据位
                    //设置停止位
                    if (comboBox2.Text == "1")
                    {
                        serialPort1.StopBits = StopBits.One;
                    }
                    else if (comboBox2.Text == "1.5")
                    {
                        serialPort1.StopBits = StopBits.OnePointFive;
                    }
                    else if (comboBox2.Text == "2")
                    {
                        serialPort1.StopBits = StopBits.Two;
                    }
                    //设置奇偶校验
                    if (comboBox5.Text == "无")
                    {
                        serialPort1.Parity = Parity.None;
                    }
                    else if (comboBox5.Text == "奇校验")
                    {
                        serialPort1.Parity = Parity.Odd;
                    }
                    else if (comboBox5.Text == "偶校验")
                    {
                        serialPort1.Parity = Parity.Even;
                    }
                    serialPort1.Open();//打开串口
                    button1.Text = "关闭串口";
                }
                catch (Exception err)
                {
                    MessageBox.Show("未找到串口" + comboBox1.Text + "\n" + "失败原因:\n" + err.ToString(), "提示！");
                }
            }
            else
            {
                //关闭串口
                try
                {

                    serialPort1.Close();//关闭串口

                }
                catch (Exception) { }
                button1.Text = "打开串口"; //按钮显示打开
            }
        }

        //串口读取并显示接收的信息
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int len = serialPort1.BytesToRead; //获取可以读取的字节数

            byte[] buff = new byte[len];
            serialPort1.Read(buff, 0, len);//把数据读取到数组中
            string reslut = Encoding.Default.GetString(buff);
            //将byte值根据为ASCII值转为string
            Invoke((new Action(() =>
            {

                if (checkBox1.Checked)//16进制转化
                {
                    textBox1.AppendText(" " + byteToHexstr(buff));
                }
                else
                {
                    textBox1.AppendText(" " + reslut);
                }
            }
            )));

        }

        //16进制显示字符串
        private string byteToHexstr(byte[] buff)
        {
            string str = "";
            try
            {
                if (buff != null)
                {

                    for (int i = 0; i < buff.Length; i++)
                    {
                        //char a = (char)buff[i];
                        //str += a.ToString();
                        str += buff[i].ToString("x2");
                        str += " ";//两个之间用空格
                    }
                    //str = new string(buff);
                    return str;
                }
            }
            catch (Exception)
            {
                return str;
            }
            return str;
        }

        //字符串转16进制
        private byte[] strToHexbytes(string str)
        {
            str = str.Replace(" ", "");//清除空格
            byte[] buff;
            if ((str.Length % 2) != 0)
            {
                buff = new byte[(str.Length + 1) / 2];
                try
                {
                    for (int i = 0; i < buff.Length; i++)
                    {
                        buff[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                    }
                    buff[buff.Length - 1] = Convert.ToByte(str.Substring(str.Length - 1, 1).PadLeft(2, '0'), 16);
                    return buff;
                }
                catch (Exception err)
                {
                    MessageBox.Show("含有f非16进制的字符", "提示");
                    return null;
                }
            }
            else
            {
                buff = new byte[str.Length / 2];
                try
                {
                    for (int i = 0; i < buff.Length; i++)
                    {
                        buff[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                    }
                    //buff[buff.Length - 1] = Convert.ToByte(str.Substring(str.Length - 1, 1).PadLeft(2, '0'), 16);
                }
                catch (Exception err)
                {
                    {
                        MessageBox.Show("含有非16进制的字符", "提示");
                        return null;
                    }
                }
            }

            return buff;
        }



        //发送数据  
        private void send_()
        {
            string data_;
            data_ = textBox2.Text.ToString();
            try
            {
                if (data_.Length != 0)
                {
                    data_ += " ";
                    if (checkBox3.Checked) //16进制发送
                    {
                        serialPort1.Write(Encoding.Default.GetString(strToHexbytes(data_)));
                    }
                    else
                    {
                        serialPort1.Write(data_);
                        //byte[] byteArray = Encoding.Default.GetBytes(shuju);//Str 转为 Byte值
                        //serialPort1.Write(byteArray, 0, byteArray.Length, 0, null, null); //发送数据         
                    }
                }

            }
            catch (Exception) { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //发送数据按键
        private void button2_Click_1(object sender, EventArgs e)
        {
            Task.Run(() => {
                send_();
            });
        }

        //清除数据按键
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private List<string> imagePaths = new List<string>();

        //导入图片
        private void button4_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePaths.Clear();
                imagePaths.AddRange(openFileDialog1.FileNames); // 添加文件名到列表
                trackBar1.Minimum = 0;
                trackBar1.Maximum = imagePaths.Count - 1;
                trackBar1.Value = 0; // 重置滑动条位置
                ShowImage(0); // 显示第一张图像

                label7.Text = "图片数量: " + imagePaths.Count;
            }
        }

        private void LoadAndResizeImage(string imagePath)
        {
            // 加载图像
            Image image = Image.FromFile(imagePath);

            // 设置PictureBox的SizeMode属性为Zoom
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // 将图像赋给PictureBox的Image属性
            pictureBox1.Image = image;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ShowImage(trackBar1.Value); // 根据滑动条的值显示图像
        }

        //窗体内显示图像
        private void ShowImage(int index)
        {
            if (index >= 0 && index < imagePaths.Count)
            {
                pictureBox1.Image = Image.FromFile(imagePaths[index]); // 加载并显示图像
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // 确保图像等比例缩放
            }
        }


        private Point mousePosition = new Point(-1, -1); // 初始化为-1，表示无效位置
        private int grayValue = -1; // 灰度值初始化为-1

        //鼠标移动事件
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // 计算鼠标在PictureBox的位置
            Point pt = TranslateZoomMousePosition(e.Location);

            if (pictureBox1.Image != null && pt.X >= 0 && pt.Y >= 0 && pt.X < pictureBox1.Image.Width && pt.Y < pictureBox1.Image.Height)
            {
                mousePosition = pt; // 更新鼠标位置
                                    // 更新灰度值
                Bitmap bmp = pictureBox1.Image as Bitmap;
                Color pixelColor = bmp.GetPixel(pt.X, pt.Y);
                grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11); // 计算灰度值

                // 更新坐标标签
                labelCoordinates.Text = $"X: {pt.X}, Y: {pt.Y}, V: {grayValue}";
                //调整标签位置到鼠标左下方
                //labelCoordinates.Location = new Point(e.X - labelCoordinates.Width, e.Y + 20);

                //重新绘制PictureBox
                //pictureBox1.Invalidate();
            }
        }

        // PictureBox中绘制十字光标
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mousePosition.X != -1)
            {
                // 绘制十字光标
                e.Graphics.DrawLine(Pens.Green, new Point(mousePosition.X, 0), new Point(mousePosition.X, pictureBox1.Height));
                e.Graphics.DrawLine(Pens.Green, new Point(0, mousePosition.Y), new Point(pictureBox1.Width, mousePosition.Y));
            }
        }

        //鼠标在box中的坐标 转换 鼠标在图片中的坐标
        private Point TranslateZoomMousePosition(Point coordinates)
        {
            if (pictureBox1.Image == null)
                return coordinates;

            // 获取PictureBox和图像的大小比例
            float imageWidth = pictureBox1.Image.Width;
            float imageHeight = pictureBox1.Image.Height;
            float scaleX = imageWidth / pictureBox1.ClientSize.Width;
            float scaleY = imageHeight / pictureBox1.ClientSize.Height;

            // 计算图像实际显示的缩放比例
            float zoom = Math.Min(pictureBox1.ClientSize.Width / imageWidth, pictureBox1.ClientSize.Height / imageHeight);

            // 计算图像实际显示的区域大小
            float displayWidth = imageWidth * zoom;
            float displayHeight = imageHeight * zoom;

            // 计算图像在PictureBox中的偏移量
            float offsetX = (pictureBox1.ClientSize.Width - displayWidth) / 2;
            float offsetY = (pictureBox1.ClientSize.Height - displayHeight) / 2;

            // 计算鼠标在图像上的位置，需要减去偏移量，并除以缩放比例
            float x = (coordinates.X - offsetX) / zoom;
            float y = (coordinates.Y - offsetY) / zoom;

            // 确保计算结果不超出图像的实际范围
            x = Math.Max(Math.Min(x, imageWidth - 1), 0);
            y = Math.Max(Math.Min(y, imageHeight - 1), 0);

            return new Point((int)x, (int)y);
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
