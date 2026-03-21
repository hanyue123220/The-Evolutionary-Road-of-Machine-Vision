namespace ConsoleIfPratice1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double a1 = 5.6666;
            int a2 = Convert.ToInt32(a1);
            int a3 = (int)a1;
            Console.WriteLine(a2);//输出6，四舍五入
            Console.WriteLine(a3);//输出5，直接截断
            //想要数学上的 “取整” → 用 Convert.ToInt32；
            //只想舍弃小数、保留整数 → 用(int) 强制转换。
            //转字符串用 ToString
            //字符串转数字用 TryParse
            //不同类型互转用 Convert
            //三元运算符 ?
            //三元运算符（? :）是值选择器，只能返回值，不能直接执行无返回值的方法（如 Console.WriteLine）；
            int a = 10;
            int b = 20;
            Console.WriteLine(a > b ? b : a);
            //整数除法;
            int a = 10;
            int b = 3;
            int c = a / b;
            double d = (double)a / b;
            double e = (double)c;
            Console.WriteLine(c);//输出3
            Console.WriteLine(d);//输出3.3333333
            // Console.WriteLine(e);//输出3，因为先进行的整数乘除，相当于在c结果的基础上，在转换的double，所以不会显示小数
            //if条件判断练习
            int score = 60;
            if (score >= 90)
            {
                Console.WriteLine("good");
            }
            else if (score >= 80)
            {
                Console.WriteLine("justsoso");
            }
            else
            {
                Console.WriteLine("bad");
            }
            //swich条件判断
            int swichTest = 7;
            switch (swichTest)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;
                default:
                    Console.WriteLine("这里不是123");
                        break;
            }




        }
    }
}
