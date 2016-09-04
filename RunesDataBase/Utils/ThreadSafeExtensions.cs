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
    }
}
