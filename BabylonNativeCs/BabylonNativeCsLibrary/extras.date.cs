namespace BABYLON
{
    using System;

    public class Date
    {
        public int getTime()
        {
            return (int) (DateTime.Now.Ticks / 1000);
        }

        public int getHours()
        {
            return DateTime.Now.Hour;
        }

        public int getMinutes()
        {
            return DateTime.Now.Minute;
        }

        public int getSeconds()
        {
            return DateTime.Now.Second;
        }
    }
}
