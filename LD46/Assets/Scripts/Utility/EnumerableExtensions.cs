using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;


public static class EnumerableExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

	public static T GetRandomElement<T>(this IList<T> list) {
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	//gets a random element from a list that is not already in "other"
	//currently brute force... meh
	public static T GetRandomElementNotIn<T>(this IList<T> list, IList<T> other) {
		T possible = list.GetRandomElement();
		while (other.Contains(possible)) {
			possible = list.GetRandomElement(); 
		}
		return possible;
	}

	//gets a random element from a list that is not already in "other"
	//currently brute force... meh
	public static T GetRandomElementNotEqualTo<T>(this IList<T> list, T other) {
		T possible = list.GetRandomElement();
		while (possible.Equals(other)) {
			possible = list.GetRandomElement();
		}
		return possible;
	}

	public static List<T> GetRandomDistinctElements<T>(this IList<T> list, int numElements) {
		List<T> result = new List<T>();
		IList<T> copy = list.Select(item => item).ToList();
		copy.Shuffle();
		for (int i = 0; i < numElements; i++) {
			result.Add(copy[i]);
		}
		return result;
	}
}