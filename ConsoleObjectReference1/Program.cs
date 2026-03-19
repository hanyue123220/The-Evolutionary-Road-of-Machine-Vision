using System;

namespace ConsoleObjectReference1
{
    class test1
    {
        public static void setNub(int a, int b) => a = b;//值类型传递

    }
    class Person
    {
        public Person(string name, int age)//构造函数，创建对象时初始化属性
        {
            _name = name;
            _age = age;
        }
        public string _name;
        public int _age;
    }
    internal class Program
    {

        static void Main(string[] args)
        {

           
            int a = 10;
            test1.setNub(a, 20);
            Console.WriteLine(a);//值类型传递测试
            Person p1 = new("Tom", 7);//不是静态方法，必须先创建对象才能调用构造函数
            Console.WriteLine(p1._age);//引用类型传递测试
            Person p2 = p1;//p2和p1指向同一个对象
            p2._age = 70;//修改p2的_age属性
                         //Console.WriteLine($"p1年龄:{p1._age},p2年龄:{p2._age}");//p1._age也被修改了，因为p1和p2指向同一个对象




        }
    }

}
//内存分配：
//、引用类型（Person）的底层逻辑
//new Person("Tom", 7) 在堆内存中创建一个对象，包含 _name 和 _age 两个字段，堆内存会为这个对象分配一个唯一的内存地址（比如 0x001234）。
//变量 p1 是一个引用变量，存储在栈内存中，它的值就是堆对象的地址 0x001234。
//参数传递：
//调用 SetAge(p1, 70) 时，会把 p1 存储的地址 0x001234 复制一份，传递给方法参数 p。
//此时栈内存中 p 和 p1 存储的地址相同，都指向堆内存中的同一个对象。
//修改属性：
//p._age = 70 会通过地址 0x001234 找到堆对象，直接修改它的 _age 字段。
//因为 p1 也指向这个地址，所以 p1._age 读取的是修改后的堆内存数据。

//二、值类型（int）的底层逻辑
//内存分配：
//int v = 1024 是值类型变量，直接在栈内存中存储它的值 1024。
//参数传递：
//调用 SetInt(v, 4096) 时，会把 v 的值 1024 复制一份，传递给方法参数 i。
//此时栈内存中 i 和 v 是两个独立的内存空间，i 存储的是 1024 的副本。
//修改值：
//i = 4096 只会修改栈内存中 i 的副本值，不会影响 v 所在的内存空间。
//方法执行结束后，i 的内存空间被释放，v 仍然仍然存储原始值 10`。


//值类型：我就是数据本身，你拿我的副本，改你自己的去，别碰我。
//引用类型：我只是个地址，你拿到地址就能改我背后的对象，咱们共享同一个东西。