using System;
using System.Windows.Forms;

namespace RunesDataBase.Utils
{
    internal static class ThreadSafeExtensions
    {
        public static void ThreadSafeInvoke(this Control component, Action act)
        {
            if (component.InvokeRequired)
                component.Invoke(act);
            act();
        }
        public static void ThreadSafeInvoke<T>(this T component, Action<T> act) where T: Control
        {
            if (component.InvokeRequired)
                component.Invoke(act);
            act(component);
        }
    }
}
