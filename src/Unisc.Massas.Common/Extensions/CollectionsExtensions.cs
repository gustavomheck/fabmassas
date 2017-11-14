using System.Collections.ObjectModel;

namespace System.Collections.Generic
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Creates a System.Collections.ObjectModel.Collection from a System.Collections.Generic.IEnumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable to create a System.Collections.ObjectModel.Collection from.</param>
        /// <returns>A System.Collections.ObjectModel.Collection that contains elements from the input sequence.</returns>
        public static Collection<TSource> AsCollection<TSource>(this IEnumerable<TSource> source)
        {
            var c = new Collection<TSource>();

            foreach (TSource each in source)
                c.Add(each);

            return c;
        }

        /// <summary>
        /// Creates a System.Collections.ObjectModel.ObservableCollection from a System.Collections.Generic.IEnumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable to create a System.Collections.ObjectModel.ObservableCollection from.</param>
        /// <returns>A System.Collections.ObjectModel.ObservableCollection that contains elements from the input sequence.</returns>
        public static ObservableCollection<TSource> AsObservableCollection<TSource>(this IEnumerable<TSource> source)
        {
            var oc = new ObservableCollection<TSource>();

            foreach (TSource each in source)
                oc.Add(each);

            return oc;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified
        ///  predicate, and returns the first occurrence within the entire System.Collections.Generic.List.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.List to check.</param>
        /// <param name="match">The System.Predicate`1 delegate that defines the conditions of the element to search for.</param>
        /// <returns>
        /// The first element that matches the conditions defined by the specified predicate,
        /// if found; otherwise, the default value for type T.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">action is null.</exception>
        public static T Find<T>(this Collection<T> source, Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = 0; i < source.Count; i++)
                if (match(source[i]))
                    return source[i];

            return default(T);
        }

        /// <summary>
        /// Performs the specified action on each element of the System.Collections.Generic.IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable whose elements should be passed as arguments to the action.</param>
        /// <param name="action">The System.Action delegate to perform on each element of the System.Collections.Generic.IEnumerable.</param>
        /// <exception cref="System.ArgumentNullException">action is null.</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (T obj in source)
                action(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IList to get the element from.</param>
        /// <param name="current"></param>
        /// <returns>The next element from a list if possible; otherwise returns a default value.</returns>
        public static T Next<T>(this IList<T> source, T current)
        {
            if (source == null || source.Count == 0)
                return default(T);

            if (current == null)
                return source[0];

            int proximoIndice = source.IndexOf(current) + 1;

            if (proximoIndice == source.Count)
                return source[0];

            return source[proximoIndice];
        }

        /// <summary>
        /// Gets the previous element from a list.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IList to get the element from.</param>
        /// <param name="current">The current element.</param>
        /// <returns>The previous element from a list if possible; otherwise returns a default value.</returns>
        public static T Previous<T>(this IList<T> source, T current)
        {
            if (source == null || source.Count == 0)
                return default(T);

            if (current == null)
                return source[0];

            int indiceAnterior = source.IndexOf(current) - 1;

            if (indiceAnterior == -1)
                return source[source.Count - 1];

            return source[indiceAnterior];
        }

        /// <summary>
        /// Creates a System.Collections.ObjectModel.Collection from a System.Collections.Generic.IEnumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable to create a System.Collections.ObjectModel.Collection from.</param>
        /// <returns>A System.Collections.ObjectModel.Collection that contains elements from the input sequence.</returns>
        public static ICollection<TSource> ToCollection<TSource>(this IEnumerable<TSource> source)
        {
            var c = new Collection<TSource>();

            foreach (TSource each in source)
                c.Add(each);

            return c;
        }

        /// <summary>
        /// Creates a System.Collections.ObjectModel.ObservableCollection from a System.Collections.Generic.IEnumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The System.Collections.Generic.IEnumerable to create a System.Collections.ObjectModel.ObservableCollection from.</param>
        /// <returns>A System.Collections.ObjectModel.ObservableCollection that contains elements from the input sequence.</returns>
        public static ICollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> source)
        {
            var oc = new ObservableCollection<TSource>();

            foreach (TSource each in source)
                oc.Add(each);

            return oc;
        }
    }
}
