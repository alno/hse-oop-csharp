using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarSystem
{
    class EnumerableWrapper<S,D> : IEnumerable<D> where S:D
    {

        private IEnumerable<S> source;

        public EnumerableWrapper(IEnumerable<S> source)
        {
            this.source = source;
        }

        public IEnumerator<D> GetEnumerator()
        {
            foreach (S v in source)
                yield return v;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (S v in source)
                yield return v;
        }

    }
}
