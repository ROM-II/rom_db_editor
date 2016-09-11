using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runes.Net.Shared
{
    public class ResetableLazy<T>
    {
        protected Func<T> Initializator { get; }
        protected bool ValueHasBeenConstructed { get; private set; }
        public ResetableLazy(Func<T> initializator)
        {
            Initializator = initializator;
        }

        private T _value;
        public virtual  T Value
            => ValueHasBeenConstructed ? _value : ConstructValue();

        protected virtual  T ConstructValue()
        {
            _value = Initializator();
            ValueHasBeenConstructed = true;
            return _value;
        }

        public virtual void Reset()
        {
            ValueHasBeenConstructed = false;
        }
    }
}
