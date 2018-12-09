namespace Singleton
{
    #region using directives

    using System;

    #endregion using directives

    internal class Program
    {
        private static void Main(string[] args)
        {
            //..
            //...
            //...

            var logger = Logger.GetInstance();
            logger.Log("你好！再见！");
            Console.ReadKey();
        }
    }
}