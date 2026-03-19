namespace ConsoleClassTest1
{
    internal class Program
    {
        static void HelloWorld()//静态方法
        {
            Console.WriteLine("你好世界!1");
            Console.WriteLine("Hello, World!1232");
            Console.WriteLine("Hello, World!312313");
        }
        int Add(int a)//非静态方法
        {
            return a + 1;
        }
        int Add1(int a)=>a+1;//表达式体方法（语法糖），适用于方法体只有一行代码的情况，可以省略大括号和return关键字
        int Subtract(int a)//非静态方法
        {
            return a - 1;
        }
        int Subtract1(int a)=>a-1;//表达式体方法（语法糖），适用于方法体只有一行代码的情况，可以省略大括号和return关键字
        static void show()=>Console.WriteLine("这是一个表达式体方法,语法糖");//表达式体方法（语法糖），适用于方法体只有一行代码的情况，可以省略大括号和return关键字
        
        static void Main(string[] args)
        {

            //Program.HelloWorld();//这里的program是不必要的，颜色只是为了强调这是一个静态方法，直接写HelloWorld()就可以了
            int a = 1;
            Program p = new Program();
            int result1 =p.Add(a);
            int result2 =p.Subtract(result1);
            //Console.WriteLine($"加密码后{result1}");
            //Console.WriteLine($"减密码后{result2}");
            show();
        }
    }
}
//静态方法（static）
//属于类，不属于某个对象
//调用：直接用 类名。方法名 ()
//不需要 new 对象


//非静态方法（实例方法）
//属于对象（实例）
//调用：必须先 new 对象，再 对象。方法名 ()
