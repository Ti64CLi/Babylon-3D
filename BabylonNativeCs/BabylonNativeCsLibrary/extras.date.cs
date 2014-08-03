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
            throw new NotImplementedException();
        }

        public int getMinutes()
        {
            throw new NotImplementedException();
        }

        public int getSeconds()
        {
            throw new NotImplementedException();
        }
    }
}
