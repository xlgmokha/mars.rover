using System;
using System.Collections.Generic;
using System.Linq;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace specifications
{
    public static class MockingExtensions
    {
        public static IMethodOptions<R> is_told_to<T, R>(this T mocked_item, Function<T, R> action_to_perform) where T : class
        {
            return mocked_item.Stub(action_to_perform);
        }

        public static IMethodOptions<R> is_asked_for<T, R>(this T mock, Function<T, R> func) where T : class
        {
            return mock.Stub(func);
        }

        public static IMethodOptions<R> it_will_return<R>(this IMethodOptions<R> options, R item)
        {
            return options.Return(item);
        }

        public static IMethodOptions<IEnumerable<R>> it_will_return<R>(this IMethodOptions<IEnumerable<R>> options,
                                                                       params R[] items)
        {
            return options.Return(items.AsEnumerable());
        }

        public static IMethodOptions<IEnumerable<R>> it_will_return_nothing<R>(
            this IMethodOptions<IEnumerable<R>> options)
        {
            return options.it_will_return();
        }

        public static void it_will_throw<R>(this IMethodOptions<R> options, Exception item)
        {
            options.Throw(item);
        }
    }
}