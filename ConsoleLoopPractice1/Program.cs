namespace ConsoleLoopPractice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // 九九乘法表
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.Write($"{i}*{j}={i * j}\t");///t是制表符号，实现空格

                }
                Console.WriteLine();//实现外层换行
            }
            //猜数字游戏
            Random random = new Random();
            int secret = random.Next(1, 101);
            int count = 1;//统计次数
            Console.WriteLine("猜数字游戏，从1到100中猜数字");
            Console.WriteLine("输入从1到100中的数字");
            while (true)
            {

                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int userinputInt))
                {

                    Console.WriteLine("输入的不是数字，请重新输入");
                    continue;//跳过本次循环，不执行下面代码，开始新一轮的循环
                }

                else
                {
                    if (userinputInt > 101 || userinputInt < 1)
                    {
                        Console.WriteLine("输入的数字大于100或者小于0不符合要求，请重新输入");
                        continue;//跳过本次循环
                    }
                }


                if (userinputInt > secret)
                {
                    Console.WriteLine("higher");
                }
                else if (userinputInt < secret)
                {
                    Console.WriteLine("lower");
                }
                else
                {

                    Console.WriteLine($"equal,共猜了{count}次");
                    break;
                }
                count++;
            }

            //带次数的猜数字游戏
            int count1 = 0;
            int secret1 = random.Next(1, 101);
            int maxCount = 5;
            Console.WriteLine("猜数字游戏，从1到100中猜数字,你一共有5次机会");
            Console.WriteLine("输入从1到100中的数字");
            while (true)
            {
                if (count1 >= maxCount)
                {
                    Console.WriteLine("次数用尽，game over");
                    Console.WriteLine($"答案是{secret1}");
                    break;
                }//最开始判断次数，次数小于最大要求次数在允许输入，在允许输入
                string userinput1 = Console.ReadLine();
                bool result = int.TryParse(userinput1, out int userinputInt1);
                if (!result)
                {
                    Console.WriteLine("输入的不是数字，请重新输入");
                    continue;//跳过本次循环，不执行下面代码，开始新一轮的循环
                }
                if (userinputInt1 > 100 || userinputInt1 < 1)
                {
                    Console.WriteLine("输入的数字大于100或者小于0不符合要求，请重新输入");
                    continue;//跳过本次循环
                }
           
               
                count1++;
                if (userinputInt1 > secret1)
                {
                    Console.WriteLine("higher");
                    Console.WriteLine($"还剩{maxCount - count1}次机会");
                    Console.WriteLine($"答案是{secret1}");
                }
                else if (userinputInt1 < secret1)
                {
                    Console.WriteLine("lower");
                    Console.WriteLine($"还剩{maxCount - count1}次机会");
                }
                else
                {

                    Console.WriteLine($"equal,共猜了{count1}次");

                    break;
                }





            }


        }
    }
}

