using System;

namespace RunesDataBase.Utils
{
    public class ChangesSourceController
    {
        public bool ChangesByUser { get; private set; } = true;

        public void MakeChanges(Action action)
        {
            if (!ChangesByUser)
            {
                action?.Invoke();
                return;
            }

            ChangesByUser = false;
            action?.Invoke();
            ChangesByUser = true;
        }
    }
}
