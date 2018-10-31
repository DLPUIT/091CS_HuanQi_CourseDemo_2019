namespace Case2
{
    #region using directives

    using System;
    using System.Collections.Generic;

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

            // ����һ��User����������������Է���������ͬ���͵�ʵ��
            var list1 = new List<User>();

            list1.Add(somebody);

            var somebody2 = new User();
            list1.Add(somebody2);

            // �ܹ���˼�룬���ǽ�����һ�����
            //if (timeout > 1000 )
            var dbService = new DatabaseOperation();
            foreach (var people in list1)
            {
                dbService.Add(people);
            }

            // Lambda expression
            // => Goes to
            // ��ȡ��һ�� ����ֵ ���� 15 ���û����޸����� GitHub�������»����ݿ�
            var user1 = dbService.Get(u => u.Credits > 15);
            user1.GitHub = "abc1243";
            dbService.Update(user1);

            // select top 1 from Users where gender = true
            var allUser1 = dbService.GetAll(u => u.Credits > 15);

            var allUser2 = dbService.GetAll(
                u =>
                    u.Gender == false && u.Credits > 15);

            var allUser3 = dbService.GetAll(
                u => u.ClassId == "�����091" && u.Gender == true);

            // ��������ɾ������
            dbService.Delete(user1.Id);

            dbService.DeleteMany(u => u.Gender == true && u.Credits < 10);

            Console.ReadKey();
        }
    }
}