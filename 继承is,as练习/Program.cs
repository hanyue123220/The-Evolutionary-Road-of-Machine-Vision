using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 继承is_as练习
{
 class Person
    {
        public string Name { set; get; }
        public Person (string name)
        {
            Name = name;
        }
        public virtual void ShowInfo() => Console.WriteLine($"我的名字是{Name}");
    }

    class Teacher : Person
    {
        public string Career { get; set; }
        public Teacher (string name,string career) : base(name)
        {
            Career = career;
        }
        public override void ShowInfo() {

            Console.WriteLine($"我的名字是{Name},我的身份是{Career}"); 
        }
        public void LookAllStudents(List<Person> personList)
           
        {
           
            Console.WriteLine("\n===== 老师查看所有学生 =====");
            foreach (Person p in personList)
            {
                if (p is Student)
                {
                    Student stu = p as Student;
                    //Console.WriteLine($"学生：{stu.Name}，分数：{stu.Score}");
                    stu.LookScore();
                }
            }
        }
    }
    class Student : Person
    {
        public int Score { get; }
        public Student (string name,int score) : base(name)
        {
            Score = score;
        }

        public void LookScore()
        {
            Console.WriteLine("名字:"+Name+"分数:"+Score);
        }

    }
    class Admin:Person
    {
        public Admin(string name) : base(name) { }
        public void AddStudent(string name, int score, List<Person> personList)
        {

            personList.Add(new Student(name, score));
        }
        public void AllInfo(List<Person> AllData)
        {
            Console.WriteLine($"我的管理员名字是{Name}");
            foreach (Person person in AllData)
            {
                if(person is Student)
                {
                    Student stu = person as Student;
                    stu.LookScore();
                }
                if(person is Teacher)
                {
                    Teacher tea = person as Teacher;
                    tea.ShowInfo();
                }
            }
        }
    }
    class Animal { 
    
    public string Name { set; get; }
        public Animal( string name)
        {
            Name = name;
        }
        public virtual void Eat() => Console.WriteLine("animal eat");
    
    }
    class Dog:Animal
    {
        public Dog(string name) :base(name)
        {
           
        }
        public override void Eat()
        {
        
            Console.WriteLine("dog eat meet");
        }
    }
    class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
            
        }
        public override void Eat()
        {
          
            Console.WriteLine("cat eat fish");
        }
    }
    class Panda : Animal
    {
        public Panda(string name) : base(name)
        {

        }
        public override void Eat()
        {
         
            Console.WriteLine("Panda eat 竹子");
        }
    }
    class Program
    {
        public void Addstudent()
        {

            List<Person> personlist = new List<Person> {
               new Admin("yozuhi")
                  };
            Admin admin = personlist[0] as Admin;
            int chosenub = 0;
            while (true)
            {
                Console.WriteLine("input student name");
                string studentname = Console.ReadLine();
                Console.WriteLine("input student score");
                int studentscore = int.Parse(Console.ReadLine());
                admin.AddStudent(studentname, studentscore, personlist);
                Console.WriteLine("contiue:1,exit:0");
                if (!int.TryParse(Console.ReadLine(), out chosenub))
                {
                    Console.WriteLine("input wrong");
                    chosenub = 0;

                }

                if (chosenub == 1)
                {
                    continue;
                }
                if (chosenub == 0)
                {
                    admin.AllInfo(personlist);
                    break;
                }


            }
        }//添加学生
        static void Main()
        {
            List<Person> personlist = new List<Person> { new Student("小明", 88) };
            Admin admin = new Admin("yozuhi");

            // 在这里打个断点
            admin.AllInfo(personlist);






        }
        }
    }
