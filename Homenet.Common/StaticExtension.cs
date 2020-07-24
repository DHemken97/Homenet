using System;

namespace Homenet.Common
{
    public static class StaticExtension
    {
        public static bool Try(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
