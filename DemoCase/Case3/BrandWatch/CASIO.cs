namespace Case3
{
    #region using directives

    using System;

    #endregion

    public class CASIO : SolarWatch, ICalDay, IStopWatch
    {
        public void CalDayAfterN()
        {
            Console.WriteLine("N 天之后是 M day");
        }

        public void StartTiming()
        {
            throw new NotImplementedException();
        }

        public void StopTiming()
        {
            throw new NotImplementedException();
        }

        public void ShowStopWatch()
        {
            throw new NotImplementedException();
        }
    }
}