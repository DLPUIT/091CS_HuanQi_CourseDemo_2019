namespace Case2
{
    #region using directives

    using System;

    #endregion using directives

    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("DLPU ����ѧϰС�� ����ϵͳ Version 1.0");
                Console.WriteLine();
                var executor = new Executor();
                executor.ShowHelp();
                executor.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"������һ���޷�������쳣��������ֹ���С���ϸ��Ϣ:  {ex}");
            }
        }
    }
}