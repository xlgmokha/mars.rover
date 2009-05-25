using System.Collections.Generic;
using System.Linq;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace specifications
{
    static public class MockingExtensions
    {
        static public IMethodOptions<R> is_told_to<T, R>(this T mocked_item, Function<T, R> action_to_perform)
            where T : class
        {
            return mocked_item.Stub(action_to_perform);
        }

        static public IMethodOptions<R> it_will_return<R>(this IMethodOptions<R> options, R item)
        {
            return options.Return(item);
        }

        static public IMethodOptions<IEnumerable<R>> it_will_return<R>(this IMethodOptions<IEnumerable<R>> options,
                                                                       params R[] items)
        {
            return options.Return(items.AsEnumerable());
        }
    }
}