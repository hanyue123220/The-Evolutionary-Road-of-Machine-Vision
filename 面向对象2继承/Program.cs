using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象2继承
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person() { }//无参构造,只有无参构造才能用初始化生成器
        public Person(string name, int age)//有参构造
        {
            Name = name;
            Age = age;
        }
        public void SayHello() => Console.WriteLine($"我是{Name},我的年龄是{Age}");

    }
    class Student : Person
    {

        public int Score { get; set; }
        public Student(string name, int age, int score)
            : base(name, age)
        {
            Score = score;
        }
        public void ShowScore() => Console.WriteLine($"我的成绩是{Score}");
    }
    class Boss
    {
        public string Name { set; get; }
        public Boss(string name)
        {
            Name = name;
        }
        public virtual void Say()
        {
            Console.WriteLine($"我是{Name}，我是一个人");
        }
    }
    class Employee : Boss
    {
        public int Money { get; set; }
        public Employee(string name, int money) : base(name)
        {
            Money = money;
        }
        public override void Say()
        {
            // 👇 这里就是 base 的第二个场景！
            // 先调用父类原来的 Say 方法
            base.Say();

            // 再执行子类自己的逻辑
            Console.WriteLine($"我考了{Money}分，我是学生");
        }
    }
    class CommonVerify
    {
        public string Name { set; get; }
        public int Password { set; get; }
        public CommonVerify(string name, int password)
        {

            Password = password;
            Name = name;
        }
        public virtual bool IstureLogin()
        {
            Console.Write("请输入账号：");
            string inputName = Console.ReadLine();

            Console.Write("请输入密码：");
            int inputPwd = int.Parse(Console.ReadLine());
            return inputName == Name && inputPwd == Password;//账号密码不对,返回false
        }
    }
    class ExtraVerify : CommonVerify
        {
            Random random = new Random();
            public int Vcode { get; }
            public ExtraVerify(string name, int password) : base(name, password)
            {
                Vcode = random.Next(1000, 2000);
            }
            public override bool IstureLogin()
            {
                if (!base.IstureLogin())
                {
                    Console.WriteLine("账号密码错误");
                    return false;


                }

                // 2. 账号密码正确 → 才要验证码
                Console.WriteLine("请输入验证码：" + Vcode); // 把正确码显示出来
                int inputCode = int.Parse(Console.ReadLine());

                if (inputCode != Vcode)
                {
                    Console.WriteLine("验证码错误！");
                    return false;
                }

                Console.WriteLine("登录成功！");
                return true;


            }
        }
    
        internal class Program
        {

            /// <summary>
            /// 费用练习
            /// </summary>
            static void Fare()
            {
                int input = int.Parse(Console.ReadLine());
                double money;
                if (input <= 5)
                {
                    money = input * 7;
                }
                else
                {
                    money = 35 + (input - 5) * 7 * 1.2;
                }
                Console.WriteLine(money);
            }
            static void Main(string[] args)
            {

                //Student student = new Student("有志", 17, 100);

                //student.SayHello();
                //student.ShowScore();
                //Person person = new Person("han", 12);
                //Person person1 = new Person
                //{
                //    Name = "111",
                //    Age = 11
                //};
                //person.SayHello();
                //person1.SayHello();
                //Employee employee = new Employee("han", 12);
                //employee.Say();

                ExtraVerify extraVerify = new ExtraVerify("youzhi", 12);
            extraVerify.IstureLogin();




        }
        }
    }
