using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象3继承练习例子
{
    class FirstVerify
    {
        public string Name { set; get; }
        public int Pwd { get; }
        public FirstVerify(string name,int pwd)
        {
            Name = name;
            Pwd = pwd;
        }
        public virtual bool Login()
        {
            Console.WriteLine("请输入账号");
                  string inputname= Console.ReadLine();
            Console.WriteLine("请输入密码");
            int inputpwd = int.Parse(Console.ReadLine());
            return inputname == Name && inputpwd == Pwd;


        }

      
    }
    class SecondVerify : FirstVerify
    {
        public int Vcode { set; get; }
        Random random = new Random();
        public SecondVerify(string name, int pwd) : base(name, pwd)
        {
            Vcode = random.Next(1000, 2000);

        }


        public override bool Login()
        {
         
            if (!base.Login())
            {

                Console.WriteLine("name or password is wrong!!");
                return false;
   
            }
            else
            {
                Console.WriteLine("Please input Vcode!!" + Vcode);
                int inputVcode = int.Parse(Console.ReadLine());
                if (inputVcode == Vcode)
                {
                    Console.WriteLine("login success!");
                }
                else
                {
                    Console.WriteLine("Vcode is wrong!!");
                }
                return true;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {


            /*
             1. 一个类可以同时有无参 + 有参构造
             2. new 类名() → 调用无参
             3. new 类名(值,值) → 调用有参
            */
            SecondVerify secondVerify = new SecondVerify("youz", 11);
            secondVerify.Login();
        }
    }
}
