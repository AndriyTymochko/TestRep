using System;
using System.Collections.Generic;

namespace Mini_Blog
{
    public static class ExtensionProvider
    {
        public static ICollection<TSource> ForEach<TSource>(this ICollection<TSource> source, Action<TSource> act)
        {
            foreach (TSource el in source)
                act(el);

            return source;
        }
    }
}
