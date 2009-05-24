using System.Collections.Generic;

namespace mars.rover.common
{
    public interface Registry<T> : IEnumerable<T>
    {
        IEnumerable<T> all();
        void Add(T item);
    }
}