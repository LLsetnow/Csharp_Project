using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace text_file
{
    internal class Program
    {
        string in_floder_path = "D:\\Csharp Project\\text_file\\input_text";
        static string out_floder_path = "D:\\Csharp Project\\text_file\\ouput_text";
        static string file_name = "1.txt";
        static string out_file_path = Path.Combine(out_floder_path, file_name);
        static string out_text = string.Empty;
        static void Main(string[] args)
        {
            //创建文本文件:
            File.Create(out_file_path).Close();

            out_text = "Hello World";

            // string imageName = Path.GetFileNameWithoutExtension(imageFile); // 获取图像文件的名称（不包括扩展名）
            // string txtFileName = $"{imageName}.txt"; // 创建相应的txt文件名


            //创建新文件，并全部写入；若文件存在，覆盖写入
            File.WriteAllText(out_file_path, out_text);
        }
    }
}
