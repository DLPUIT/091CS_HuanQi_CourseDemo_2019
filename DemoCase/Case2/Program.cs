namespace Case2
{
    #region using directives

    using SquirrelFramework.Domain.Model;
    using SquirrelFramework.Repository;
    using System;

    #endregion using directives

    public class Program
    {
        private static void Main(string[] args)
        {
            var somebody = new User();

            Console.WriteLine("������༶ID");
            somebody.ClassId = Console.ReadLine();
            Console.WriteLine("������༶����");
            somebody.ClassName = Console.ReadLine();
            Console.WriteLine("����������");
            somebody.Name = Console.ReadLine();
            Console.WriteLine("�����뵱ǰ����");
            somebody.Credits = int.Parse(Console.ReadLine());
            Console.WriteLine("�������Ա�");
            somebody.Gender = bool.Parse(Console.ReadLine());
            Console.WriteLine("�������쵼");
            somebody.ReportTo = Console.ReadLine();
            Console.WriteLine("������GitHub�˻�");
            somebody.GitHub = Console.ReadLine();

            var dbService = new DatabaseOperation();
            dbService.Add(somebody);

            Console.ReadKey();
        }
    }

    public class DatabaseOperation : RepositoryBase<User>
    {
    }

    [Collection("User")]
    public class User : DomainModel
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public bool Gender { get; set; }
        public string ReportTo { get; set; }
        public string GitHub { get; set; }
    }
}