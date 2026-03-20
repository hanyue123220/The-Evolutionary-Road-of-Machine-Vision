namespace ConsoleIfStatement1
{
    internal class Program
    {

        static void Main(string[] args)
        {

            double a = 12.35;
            short b = (short)a;//显式类型转换
            //Console.WriteLine($"{b}");//打印出12,因为short类型只能存储整数部分，丢失了小数部分.如果a的值超过了short类型的范围，那么b的值将会是一个不确定的值，可能会发生溢出。（缺失精度）
            int c = 12;
            double d = c;//隐式类型转换(范围大double包含int，不会出现精度缺失)
                         // Console.WriteLine(d);
            double e = 12.35;
            float f = (float)e;
            long g = (long)f;
            int h = (int)g;
            byte i = (byte)h;
            // Console.WriteLine($"{i}");//输出12，因为在这个过程中，虽然进行了多次类型转换，但最终的结果仍然是12。需要注意的是，在进行类型转换时，如果目标类型的范围不足以容纳源类型的值，可能会发生溢出或精度丢失。因此，在进行类型转换时，应该谨慎考虑数据的范围和精度要求，以避免不必要的错误。
            //安全转换,convert
            int j = 12;
            double k = Convert.ToDouble(j);
            Console.WriteLine(k);
            double doubleValue = 123.32;
            string stringtest1 = Convert.ToString(doubleValue);//安全方法可以将double转换为string
                                                               // string stringtest2 = (string)doubleValue;//常规方法无法将double转换为string
            Console.WriteLine("double转换string" + stringtest1);
            int intvalue = Convert.ToInt32(doubleValue);
            Console.WriteLine(intvalue);
            string test1 = "123.32";
            double doubletest1 = Convert.ToDouble(test1);
            Console.WriteLine("string转换double" + doubletest1);
            //日期转换
            string datastring = "2026-06-13";
            DateTime time = Convert.ToDateTime(datastring);
            Console.WriteLine("string转date时间转换" + time);
            DateTime time1 = DateTime.Today;
            string datastring1 = Convert.ToString(time1);
            Console.WriteLine("date转string时间转换" + time1);
            //string to int
            string String1 = "123";
            int int1 = Convert.ToInt32(String1);
            int int2 = int.Parse(String1);
            //底层真相（简单说）
            //int.Parse 是专门给字符串转 int 的。如果是 null 开始抛异常
            //Convert.ToInt32 内部其实就是调用了 int.Parse，
            //只是它先帮你判断了一下：
            //如果是 null → 返回 0否则 → 走 int.Parse
            string String2 = "123";
            //int int3 = int.Parse(String2);  //int.Parse 是专门给字符串转 int 的。如果是 null 开始抛异常
            int int3 = Convert.ToInt32(String2);
            Console.WriteLine(int3);//输出0
            bool isTure = int.TryParse(String2, out int number);
            if (isTure)
            {
                Console.WriteLine("转换成功"+number);
            }
            else
            {
                Console.WriteLine("转换失败");
            }
            //tostring练习
            int testTostring = 1;
            string testTostring1 = testTostring.ToString();
































        }

    }
}
