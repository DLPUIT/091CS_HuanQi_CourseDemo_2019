namespace Singleton
{
    #region using directives

    using System.IO;
    using System.Text;

    #endregion

    internal class Logger
    {
        // 饿汉模式 Java JDK <=1.4
        // JVM
        // CLR
        // 析构 GC 垃圾回收机制
        // OOP
        // C -> ASM
        //private static Logger singleton = new Logger();

        //public static Logger GetInstance()
        //{
        //    return singleton;
        //}

        // 懒汉模式 Lazy
        private static Logger singleton;

        private static readonly object locker = new object();

        // 静态构造方法
        static Logger()
        {
        }

        // 构造方法
        private Logger()
        {
            //......
        }

        public static Logger GetInstance()
        {
            // 双检锁
            if (singleton == null)
            {
                lock (locker)
                {
                    if (singleton == null)
                    {
                        singleton = new Logger();
                    }
                    return singleton;
                }
            }
            return singleton;
        }

        public void Log(string content)
        {
            using (var fileStream =
                new FileStream(@"C:\Users\Hendry\Desktop\aaa\1.txt", FileMode.Append, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.Unicode))
                {
                    streamWriter.WriteLine(content);
                    streamWriter.Flush();
                }
            }
        }
    }
}