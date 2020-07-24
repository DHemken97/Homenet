using System;

namespace Homenet.Filesystem
{
    public static class StaticExtension
    {
        internal static bool Try(Action action)
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
