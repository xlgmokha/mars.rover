using System.Collections;
using System.Collections.Generic;

namespace mars.rover.common
{
    public class DefaultRegistry<T> : Registry<T>
    {
        readonly IList<T> items;

        public DefaultRegistry(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public IEnumerable<T> all()
        {
            return items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return all().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}