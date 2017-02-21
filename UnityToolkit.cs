using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

namespace UnityToolkit {
	// Ex. transform.position = transform.position.WithX(1);
	public static class VectorToolkit {
		/// <summary>
		/// Returns this Vector2 with a specified X value.
		/// </summary>
		public static Vector2 WithX(this Vector2 vec, float x) {
			vec.x = x;
			return vec;
		}
		/// <summary>
		/// Returns this Vector2 with a specified Y value.
		/// </summary>
		public static Vector2 WithY(this Vector2 vec, float y) {
			vec.y = y;
			return vec;
		}
		/// <summary>
		/// Flips the X and Y of this Vector2.
		/// </summary>
		public static Vector2 Flip(this Vector2 vec) {
			return new Vector2(vec.y, vec.x);
		}
		/// <summary>
		/// Returns this Vector3 with a specified X value.
		/// </summary>
		public static Vector3 WithX(this Vector3 vec, float x) {
			vec.x = x;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified Y value.
		/// </summary>
		public static Vector3 WithY(this Vector3 vec, float y) {
			vec.y = y;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified Z value.
		/// </summary>
		public static Vector3 WithZ(this Vector3 vec, float z) {
			vec.z = z;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified X and Y value.
		/// </summary>
		public static Vector3 WithXY(this Vector3 vec, float x, float y) {
			vec.x = x;
			vec.y = y;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified X and Z value.
		/// </summary>
		public static Vector3 WithXZ(this Vector3 vec, float x, float z) {
			vec.x = x;
			vec.z = z;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified Y and Z value.
		/// </summary>
		public static Vector3 WithYZ(this Vector3 vec, float y, float z) {
			vec.y = y;
			vec.z = z;
			return vec;
		}
		/// <summary>
		/// Flips the X, Y, and Z of this Vector3.
		/// </summary>
		public static Vector3 Flip(this Vector3 vec) {
			return new Vector3(vec.z, vec.y, vec.x);
		}
	}

	// Ex. material.color = material.color.WithA(0);
	public static class ColorToolkit {
		/// <summary>
		/// Returns this Color with a specified R value.
		/// </summary>
		public static Color WithR(this Color c, float r) {
			c.r = r;
			return c;
		}
		/// <summary>
		/// Returns this Color with a specified G value.
		/// </summary>
		public static Color WithG(this Color c, float g) {
			c.g = g;
			return c;
		}
		/// <summary>
		/// Returns this Color with a specified B value.
		/// </summary>
		public static Color WithB(this Color c, float b) {
			c.b = b;
			return c;
		}
		/// <summary>
		/// Returns this Color with a specified A value.
		/// </summary>
		public static Color WithA(this Color c, float a) {
			c.a = a;
			return c;
		}
	}

	// Ex. T item = list.Random();
	public static class ListToolkit {
		/// <summary>
		/// Returns the first element from this list.
		/// </summary>
		public static T First<T>(this List<T> list) {
			return list[0];
		}
		/// <summary>
		/// Returns the last element from this list.
		/// </summary>
		public static T Last<T>(this List<T> list) {
			return list[list.Count - 1];
		}
		/// <summary>
		/// Returns a random element from this list.
		/// </summary>
		public static T Random<T>(this List<T> list) {
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		/// <summary>
		/// Returns a random element from this list and removes the first occurrence of the random element from this list.
		/// </summary>
		public static T GetRandomAndRemove<T>(this List<T> list) {
			T item = list.Random();
			list.Remove(item);
			return item;
		}
		/// <summary>
		/// Returns a random element from this list and removes the random element from this list.
		/// </summary>
		public static T GetRandomAndRemoveAt<T>(this List<T> list) {
			int randLoc = UnityEngine.Random.Range(0, list.Count);
			T item = list[randLoc];
			list.RemoveAt(randLoc);
			return item;
		}
	}

	// Ex. f = f.Squared();
	public static class MathToolkit {
		/// <summary>
		/// Returns this float rounded up or down based on the specified midpoint.
		/// </summary>
		public static float RoundAt(this float f, float midpoint) {
			midpoint += Mathf.Floor(f);
			return f < midpoint ? Mathf.Floor(f) : Mathf.Ceil(f);
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the time in seconds it took to complete the last frame.
		/// </summary>
		public static float WithDeltaTime(this float f) {
			return f * Time.deltaTime;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the interval in seconds at which physics are performed.
		/// </summary>
		public static float WithFixedDelaTime(this float f) {
			return f * Time.fixedDeltaTime;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the timeScale-independent time in seconds it took to complete the last frame.
		/// </summary>
		public static float WithUnscaledDeltaTime(this float f) {
			return f * Time.unscaledDeltaTime;
		}
		/// <summary>
		/// Returns the value of this instance taken to the specified exponential power.
		/// </summary>
		public static float ToPower(this float f, int exponent) {
			float total = 1;
			if (exponent < 0) {
				LoopAction(exponent * -1, (int i)=> total *= i % 2 == 0 ? f * -1 : f);
				total = 1 / total;
			} else {
				LoopAction(exponent, (int i)=> total *= f);
			}
			return total;
		}
		/// <summary>
		/// Loop a single action a specified number of times.
		/// </summary>
		public static void LoopAction(int iterations, Action<int> step) {
			for (int i = 0; i < iterations; i++) {
				step(i);
			}
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static float Squared(this float f) {
			return f * f;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static int Squared(this int i) {
			return i * i;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static double Squared(this double d) {
			return d * d;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static long Squared(this long l) {
			return l * l;
		}
	}

	// Ex. s = s.UppercaseFirst();
	public static class StringToolkit {
		/// <summary>
		/// Returns this string with a space between each camel case.
		/// </summary>
		public static string SplitOnCamelCase(this string s) {
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < s.Length; i++) {
				if (i > 0 && char.IsUpper(s[i])) {
					builder.Append(' ');
                		}
				builder.Append(s[i]);
			}
			return builder.ToString();
		}
		/// <summary>
		/// Returns this string with an uppercase first letter.
		/// </summary>
		public static string UppercaseFirst(this string s) {
			if (string.IsNullOrEmpty(s)) {
				return string.Empty;
			}
			return char.ToUpper(s[0]) + s.Substring(1);
		}
	}

	// Ex. if (c.IsEnglishLetter()) { }
	public static class CharToolkit {
		/// <summary>
		/// Returns true if this char is a lower or upper english letter.
		/// </summary>
		public static bool IsEnglishLetter(this char c) {
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}
	}
}
