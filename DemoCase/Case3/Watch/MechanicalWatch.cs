namespace Case3
{
    #region using directives

    using System;

    #endregion

    // 机械表
    public abstract class MechanicalWatch : Watch, IAutomaticWinding
    {
        public void AutomaticWinding()
        {
            Console.WriteLine("我正在上弦");
        }
    }
}