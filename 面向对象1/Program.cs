using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 面向对象1
{
    //面向对象1
    class Student
    {
        string name;
        private int age;
        public string Name
        {
            get
            {
                return name;

            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {

                return age;

            }
            set
            {
                if (value > 100 ||value < 1)
                {
                    Console.WriteLine(false);
                    return;
                }
                age = value;
            }

        }
        public void Say()
        {
            Console.WriteLine($"名字:{Name},年龄:{Age}");
        }

    }
    //面向对象2
    class Person { 
    public string Name { get; set; }
        private int _score;
        public int Score
        {

            get { return _score; }
            set
            {
                if (value > 150)//判断必须用value,value是新接收的值
                {
                    Console.WriteLine(false);
                    return;
                    
                }
                _score = value;
            }
        }


        public void Say()
        {
            Console.WriteLine($"名字:{Name},分数:{Score}");
        }

    }
    //面向对象3,构造函数;
    class Dog
    {
        public string _name { get; set; }
        public int _age { get;  }
        
        public Dog(string _name,int _age){

            this._name = _name;
         
            this._age = _age;


        }
    }
    //面向对象加限制,加构造函数,限制只写在set里面,构造函数只能赋值
    class Sjp {
    public string Name { get; set; }
        int age;
        public int Age
        {
            get { return age; }
            set
            {

                if (value > 100)
                {
                    Console.WriteLine(false);
                    return;
                }
                age = value;
            }
        
        }
        public Sjp(string Name,int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }



    }
    //测试类student1
    class Student1 { 
       public string Name { set; get; }
        int _age;
        public int Age
        {
            get=>_age;
            set
            {
                if (value > 100 || value < 1)
                {
                    Console.WriteLine("年龄错误"+false);
                    return;
                }
                _age = value;
            }
        }
        int _score;
        public int Score
        {
            get => _score;
           private set//外界不能进行赋值,只能通过构造函数进行赋值,赋值时加上验证,一旦确定,不能更改
            {
                if (value > 150 || value < 0)
                {
                    Console.WriteLine("成绩错误"+false);
                    return;
                }
                _score = value;
            }
        }
        public Student1(string name, int Age, int score)
        {
         this. Name = name;//传进来的参数不与你定义的属性一样,不用this,如name和Name
           this. Age = Age;//传进来的Age和外面定义的属性Age一样,必须用this
            Score = score;

        }
        public void Say() => Console.WriteLine($"我的名字是{Name},我的年龄是{Age},我的分数是{Score}");

       
    }


    internal class Program
        {
            static void Main(string[] args)
            {
            Student1 student = new Student1("haneyu", 12, 18);
            Console.WriteLine(student.Score);
          
            student.Say();
        }
        }
    }

