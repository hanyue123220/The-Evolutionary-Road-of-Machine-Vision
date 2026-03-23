namespace ConsoleMethodPratice1
{
    internal class Program
    {
        //ref 的核心作用：让方法参数以「引用传递」工作，方法内修改参数会直接影响外部原变量；
        //关键规则：定义和调用时都要加 ref，参数必须先初始化；
        //适用场景：需要修改方法外部的值类型变量、优化大型值类型的传递性能。
        //out 的核心：「输出」—— 方法给外部返回多个结果，调用前变量可未初始化，方法内必须赋值；
        //ref 的核心：「引用」—— 方法操作外部变量的 “原件”，调用前必须初始化，可传值也可输出；
        //ref例子1
        /// <summary>
        /// 交换两个数的值
        /// </summary>
        /// <param name="a">第一个参数</param>
        /// <param name="b">第二个参数</param>
        static void swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;

        }
        //ref例子2
        /// <summary>
        /// 实现每个数组内的元素各加指定值
        /// </summary>
        /// <param name="a">数组</param>
        /// <param name="value">指定值</param>
        static void IncreseArrey(ref int[] a, int value)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i] + value;
            }
        }
        //ref例子3
        /// <summary>
        /// ref获取数组中的最大值最小值
        /// </summary>
        /// <param name="a">输入的数组</param>
        /// <param name="max">获取的最大值</param>
        /// <param name="min">获取的最小值</param>
        static void GetMaxMin(int[] a, ref int max, ref int min)
        {
            max = a[0];
            min = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (min > a[i])
                {
                    min = a[i];
                }
                else if (max < a[i])
                {
                    max = a[i];
                }
            }
        }
        //out参数使用例子1
        static void GetSumaAvg(int[] a, out int sum, out double avg)
        {
            sum = 0;
            avg = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];

            }
            avg = (double)sum / a.Length;

        }
        //out参数获取最大值最小值
        static void GetMaxAndMin(int[]a,out int min,out int max)
        {
           min = a[0];
           max = a[0];
            foreach(int item in a)
            {
                if (item > max)
                {
                    max = item;
                }
                if(min>item){
                    min = item;
                }
            }
        }
        //登录功能
        static bool IsLogin(string user,string password,out string loginfo)
        {
           
            if (user == "user" && password == "123")
            {
                loginfo = "登录成功";
                Console.WriteLine(loginfo);
                return true;
            }else if(user == "user")
            {
                loginfo = "密码错误";
                      Console.WriteLine(loginfo);
                return false;
            }else if(password == "123")
            {
                loginfo = "账号错误";
                Console.WriteLine(loginfo);
                return false;
            }
            else
            {
                loginfo = "全都错误";
                Console.WriteLine(loginfo);
                return false;
            }
        }
        //计算面积和周长
        static void Calculate(int len,int wid,out int Mj,out int Zc)
        {
            Mj = len*wid;
            Zc = (len+wid)*2;
        }
        static void Main(string[] args)
        {
            int[] a = { 1,2, 3, 4, 5 };

            int len, wid,Mj,Zc;
            Calculate(1, 2, out Mj, out Zc);
            Console.WriteLine($"面积={Mj},周长={Zc}");


        }
    }
}
