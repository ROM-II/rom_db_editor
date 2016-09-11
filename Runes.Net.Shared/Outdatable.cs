using System;

namespace Runes.Net.Shared
{
    public class Outdatable<T> : ResetableLazy<T>
    {
        public Outdatable(IVersioned versionedObject, Func<T> initializator) : base(initializator)
        {
            VersionedObject = versionedObject;
        }

        protected IVersioned VersionedObject { get; }
        protected int? LastVersion { get; set; }

        public bool IsOutdated
            => LastVersion == null || LastVersion.Value != VersionedObject.CurrentVersion;

        public override T Value
            => IsOutdated ? ConstructValue() : base.Value;

        protected override T ConstructValue()
        {
            var result = base.ConstructValue();
            LastVersion = VersionedObject.CurrentVersion;
            return result;
        }

        public override void Reset()
        {
            base.Reset();
            LastVersion = null;
        }
    }
}