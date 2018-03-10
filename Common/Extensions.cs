using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class Extensions
	{
		public static void AddToEndAndRemoveFirst<T>(this List<T> list, T obj)
		{
			list.Add(obj);
			list.RemoveAt(0);
		}

		public static K Mutate<T, K>(this T obj, Func<T, K> mutator)
		{
			return mutator(obj);
		}

		public static IEnumerable<object> ZipAll<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, object> zipper)
		{
			var e = first.GetEnumerator();
			var f = second.GetEnumerator();
			var result = new List<object>();
			while (e.MoveNext())
				if (f.MoveNext())
					result.Add(zipper(e.Current, f.Current));
				else
					result.Add(zipper(e.Current, default(TSecond)));

			while (f.MoveNext())
				result.Add(zipper(default(TFirst), f.Current));

			return result;
		}

		public static T As<T>(this object obj) where T : class
		{
			return obj as T;
		}
	}
}
