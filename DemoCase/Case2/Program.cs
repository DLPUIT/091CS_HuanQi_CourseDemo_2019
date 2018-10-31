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

            Console.WriteLine("请输入班级ID");
            somebody.ClassId = Console.ReadLine();
            Console.WriteLine("请输入班级名称");
            somebody.ClassName = Console.ReadLine();
            Console.WriteLine("请输入姓名");
            somebody.Name = Console.ReadLine();
            Console.WriteLine("请输入当前积分");
            somebody.Credits = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入性别");
            somebody.Gender = bool.Parse(Console.ReadLine());
            Console.WriteLine("请输入领导");
            somebody.ReportTo = Console.ReadLine();
            Console.WriteLine("请输入GitHub账户");
            somebody.GitHub = Console.ReadLine();

            // 创建一个User容器，这个容器可以放入无数个同类型的实例
            var list1 = new List<User>();

            list1.Add(somebody);

            var somebody2 = new User();
            list1.Add(somebody2);

            // 架构的思想，我们将数据一起放入
            //if (timeout > 1000 )
            var dbService = new DatabaseOperation();
            foreach (var people in list1)
            {
                dbService.Add(people);
            }

            // Lambda expression
            // => Goes to
            // 读取第一个 信用值 大于 15 的用户，修改他的 GitHub，并更新回数据库
            var user1 = dbService.Get(u => u.Credits > 15);
            user1.GitHub = "abc1243";
            dbService.Update(user1);

            // select top 1 from Users where gender = true
            var allUser1 = dbService.GetAll(u => u.Credits > 15);

            var allUser2 = dbService.GetAll(
                u =>
                    u.Gender == false && u.Credits > 15);

            var allUser3 = dbService.GetAll(
                u => u.ClassId == "计算机091" && u.Gender == true);

            // 根据条件删除数据
            dbService.Delete(user1.Id);

            dbService.DeleteMany(u => u.Gender == true && u.Credits < 10);

            Console.ReadKey();
        }
    }
}