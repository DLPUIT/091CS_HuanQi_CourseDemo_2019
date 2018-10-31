namespace Case3
{
    #region using directives

    using System;

    #endregion

    public abstract class Watch : IShowTime, IShowAD
    {
        public string ADDescription;
        public string Name;

        public void ShowAD()
        {
            Console.WriteLine(this.Name + "在做广告：" + this.ADDescription);
        }

        public void CheckPower()
        {
            throw new NotImplementedException();
        }

        public void CheckNetwork()
        {
            throw new NotImplementedException();
        }

        public void ShowTime()
        {
            Console.WriteLine("现在是XXXXXXX");
        }
    }
}