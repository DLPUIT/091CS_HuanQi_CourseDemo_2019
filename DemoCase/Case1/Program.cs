namespace Case1
{
    #region using directives

    using System;

    #endregion
    
    class People
    {
        // 构造方法
        public People(int birthYear, string gender)
        {
            if (birthYear < 1)
            {
                throw new Exception("玩我啊，怒了！！！");
            }
            this.Age = DateTime.Now.Year - birthYear;
            this.Gender = gender;
            this.IsHungry = true;
        }

        // 成员变量 成员属性
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; }
        private bool IsHungry;

        // 成员方法
        public void Eat()
        {
            this.IsHungry = false;
        }
    }

    // 泛型类
    class MyNumber<T>
    {
        public MyNumber(T number)
        {
            this.Number = number;
        }

        public T Number { get; set; }

        // 静态方法，不是成员（实例）方法，是类方法
        public static MyNumber<T> Add(MyNumber<T> a, MyNumber<T> b)
        {
            dynamic x = a;
            dynamic y = b;
            return new MyNumber<T>(x.Number + y.Number);
        }

        // 运算符重载的实现
        public static MyNumber<T> operator +(MyNumber<T> a, MyNumber<T> b)
        {
            return Add(a, b);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // int a = 3;
            var a = new MyNumber<int>(3);
            // int b = 5;
            var b = new MyNumber<int>(5);
            var r = MyNumber<int>.Add(a, b);

            var x = new MyNumber<double>(3.1415);
            var y = new MyNumber<double>(6.28);
            var r2 = MyNumber<double>.Add(x, y);

            // 运算符重载
            var r3 = a + b;

            Console.WriteLine(r.Number);
            Console.WriteLine(r2.Number);
            Console.WriteLine(r3.Number);

            Console.ReadKey();
        }
    }
}
