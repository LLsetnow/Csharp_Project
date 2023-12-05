using other_space;          //调用其他命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_text1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //输入
            //string str = Console.ReadLine();

            //静态类内的静态变量可直接调用
            //效果和实例类内定义静态变量差不多
            float kp = PID.Kp;
            float ki = PID.Ki;
            float kd = PID.Kd;

            //将 Point 实例化 创建Pointl类型
            Point left_up = new Point();
            Point right_up = new Point();
            Point2 left_down = new Point2();
            left_down.X = 3;
            left_down.Y = 4;

            //输出完自动换行
            Console.WriteLine("[{0}][{1}]",left_down.X,left_down.Y);

            //Console.Write();      //不会自动换行

            //left_up、right_up无法访问static的数据

            //在try内的报错不会中止程序，而是进入catch
            //若try内无报错，则不进入catch
            /*            try
                        {
                            a = int.Parse(str);     //将str转换为int
                        }
                        catch { }
                        {
                            Console.WriteLine("错误");
                        }*/

            /*            left_up.x = int.Parse(Console.ReadLine());
                        left_up.y = int.Parse(Console.ReadLine());
                        left_up.x = (int)Parse(Console.ReadLine();
             */
            left_up.x = 10;
            left_up.y = 20;

            left_up.show_point();

            //static无需实例化 可直接调用
            Console.WriteLine(Point.test);
            Point.printf();

            //调用其他命名空间的类的静态变量
            show_all_point.prin();

            //Console.WriteLine("point = [{0}][{1}]",left_up.x,left_up.y);
            Console.ReadKey();      //等待读取键位
        }
    }
    //public 表示成员对于所有代码可见
    //类型
    public class Point
    {

        //public 用于外部调用
        public int x;
        public int y;
        public int flag;
        //static 静态变量
        public static string test = "无需实例化";

        public void show_point()
        {
            Console.WriteLine("point = [{0}][{1}]", x, y);
        }

        public static void printf()
        {
            Console.WriteLine("static无需实例化 可直接调用");
        }
    }

    //静态类中只能定义静态变量
    //效果和实例类内定义静态变量差不多
    //一般没必要特意定义静态类（大概）
    public static class PID
    {
        public static float Kp = 0.2f;
        public static float Ki = 0.3f;
        public static float Kd = 0.5f;
    }

    //结构体 相对类 适用于轻量数据结构
    public struct Point2
    {
        public int X;
        public int Y;
    }

    public class MyClass
    {
        //private 只能在类内访问
        private int privateField = 10;

        private void PrivateMethod()
        {
            Console.WriteLine("This is a private method.");
        }
    }


/*   其他访问修饰符：

除了private，C#还提供了其他访问修饰符，如public、protected、internal等，用于定义成员的可见性范围。
public 表示成员对于所有代码可见，protected 表示成员对于派生类可见，internal 表示成员对于同一程序集内的代码可见，等等。*/

}
