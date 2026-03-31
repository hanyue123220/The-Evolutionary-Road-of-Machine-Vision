using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespac 命名空间，表示当前文件所在位置，也就是文件夹路径
namespace 华蓝Day01
{
    internal class Program//class类的关键
    {
        //main函数，程序入口，程序会从main进入开始执行，
        //代码一定要放在main函数中
        static void Main(string[] args)
        {
            //变量，数据类型，运算符
            float a = 1.2f;
            double w = 1.2;
            char gender = '男';
            string gender1 = "男";
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            int[] numbers1 = new int[5];
            int[] nubmers2 = { 1, 2, 3, 4, 5 };
            int count = 0;
            foreach (int i in nubmers2)
            {
        
                count += i;
               

            }
            int avg = count / 5;
            Console.WriteLine(count);
            Console.WriteLine(avg);
            Console.ReadKey();

        }
    }
}
