using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 华蓝Day02
{
    internal class Program
    {
        /// <summary>
        /// 根据用户输入的数字求平均值和总和,输入数字个数为用户所定
        /// </summary>
        /// <param name="count">用户要求的数字个数</param>
        static void SumAndAcg(int count)
        {
            Console.WriteLine("请输入数字");
            int sum = 0;
            int[] nubmers = new int[count];
            while (true)
            {

                for (int i = 0; i < count; i++)
                {
                   
                    int userinputInt = int.Parse(Console.ReadLine());

                    nubmers[i] = userinputInt;
                }
                break;
            }
            foreach (int i in nubmers)
            {
                sum += i;
            }
            Console.WriteLine($"总和为{sum},平均数为{(double)sum / nubmers.Length:F2}");

        }
        /// <summary>
        /// 冒泡排序,用户输入数组,调用函数排序
        /// </summary>
        /// <param name="FirstArrey">用户要进行排序的数组</param>
        /// <returns></returns>
        static int[] Sort(int[] FirstArrey)
        {
            for (int j = 0; j < FirstArrey.Length - 1; j++)
            {
                for (int i = 0; i < FirstArrey.Length - 1; i++)
                {
                    if (FirstArrey[i + 1] < FirstArrey[i])
                    {
                        int temp;
                        temp = FirstArrey[i];
                        FirstArrey[i] = FirstArrey[i + 1];
                        FirstArrey[i + 1] = temp;
                    }
                }
            }
            return FirstArrey;
        }
        /// <summary>
        /// 判断年份是否为闰年
        /// </summary>
        /// <param name="year">输入的年份</param>
        /// <returns></returns>
        static bool IsRunnian(int year)
        {
            if (year % 100 != 0 && year % 4 == 0)
            {
                return true;
            }
            if (year % 400 == 0)
            {
                return true;
            }
            return false;

        }
        static void Main(string[] args)
        {
            #region 测试函数
            Console.WriteLine("请输入要求的数字个数");
            String userinput = Console.ReadLine();
            int userinputInt = int.Parse(userinput);
            SumAndAcg(userinputInt);
            #endregion
            #region 测试冒泡排序
            //int[] BeginArrey = { 4, 3, 5, 1 };
            //int[] AfterArrey = Sort(BeginArrey);
            //foreach (int i in AfterArrey)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion
            #region list练习
            //List<int> listTest = new List<int>();
            //listTest.AddRange(new int[] { 11, 22, 33, 44, 33, 44 });//批量添加
            //listTest.Insert(0, 1);//指定位置添加,前面是索引,后边是值
            //listTest.RemoveRange(0, 2);//批量删除
            //listTest.Remove(44);//删除第一个相同的数字
            //Console.WriteLine(listTest.Contains(44));
            //Console.WriteLine(listTest.Count);
            //int a= listTest.Find(item => item >33);
            // Console.WriteLine(a);
            // foreach (int item in listTest)
            // {
            //     Console.WriteLine(item);
            // }
            //List<int> list = new List<int> { 10, 20, 30, 40 };

            //// 先建一个数组，长度要够
            //int[] arr = new int[4];

            //list.CopyTo(arr);// 把 list 复制到 arr 里
            //list.CopyTo(1,arr,1,2);//(list的下标索引,复制到哪个数组,从数组哪个下标开始复制,复制list中的几个元素)
            //foreach (int item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region 三目运算符判断闰年
            int year =2100;
            string result = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0) ? "是" : "不是";
            Console.WriteLine(result);
            #endregion
            Console.ReadKey();string hdsahu = "daskajkd";


        }
    }
}
