namespace Case1
{
    #region using directives

    using System;

    #endregion
    
    class People
    {
        // ���췽��
        public People(int birthYear, string gender)
        {
            if (birthYear < 1)
            {
                throw new Exception("���Ұ���ŭ�ˣ�����");
            }
            this.Age = DateTime.Now.Year - birthYear;
            this.Gender = gender;
            this.IsHungry = true;
        }

        // ��Ա���� ��Ա����
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; }
        private bool IsHungry;

        // ��Ա����
        public void Eat()
        {
            this.IsHungry = false;
        }
    }

    // ������
    class MyNumber<T>
    {
        public MyNumber(T number)
        {
            this.Number = number;
        }

        public T Number { get; set; }

        // ��̬���������ǳ�Ա��ʵ�������������෽��
        public static MyNumber<T> Add(MyNumber<T> a, MyNumber<T> b)
        {
            dynamic x = a;
            dynamic y = b;
            return new MyNumber<T>(x.Number + y.Number);
        }

        // ��������ص�ʵ��
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

            // ���������
            var r3 = a + b;

            Console.WriteLine(r.Number);
            Console.WriteLine(r2.Number);
            Console.WriteLine(r3.Number);

            Console.ReadKey();
        }
    }
}
