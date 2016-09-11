using System.Threading;

namespace Runes.Net.Shared
{
    public interface IVersioned
    {
        int CurrentVersion { get; }
    }

    public class SimpleVersionProvider : IVersioned
    {
        private int _currentVersion;

        public int CurrentVersion
        {
            get { return _currentVersion; }
            set { _currentVersion = value; }
        }

        public void SafeInc()
        {
            Interlocked.Increment(ref _currentVersion);
        }
    }
}