using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine
{
	// Ex. transform.position = transform.position.WithX(1);
	public static class VectorToolkit
	{
		/// <summary>
		/// Returns this Vector2 with a specified X value.
		/// </summary>
		public static Vector2 WithX(this Vector2 vec, float x)
		{
			vec.x = x;
			return vec;
		}
		/// <summary>
		/// Returns this Vector2 with a specified Y value.
		/// </summary>
		public static Vector2 WithY(this Vector2 vec, float y)
		{
			vec.y = y;
			return vec;
		}
		/// <summary>
		/// Flips the X and Y of this Vector2.
		/// </summary>
		public static Vector2 Flip(this Vector2 vec)
		{
			return new Vector2(vec.y, vec.x);
		}
		/// <summary>
		/// Returns this Vector3 with it's X and Z as a new Vector2.
		/// </summary>
		public static Vector2 ConvertToVector2(this Vector3 vec)
		{
			return new Vector2(vec.x, vec.z);
		}
		/// <summary>
		/// Are all of this Vector's values greater than or equal to the specified Vector.
		/// </summary>
		public static bool GreaterThanOrEqual(this Vector2 vec1, Vector2 vec2)
		{
			if (vec1.x >= vec2.x && vec1.y >= vec2.y)
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// Returns this Vector3 with a specified X value.
		/// </summary>
		public static Vector3 WithX(this Vector3 vec, float x)
		{
			vec.x = x;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified Y value.
		/// </summary>
		public static Vector3 WithY(this Vector3 vec, float y)
		{
			vec.y = y;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified Z value.
		/// </summary>
		public static Vector3 WithZ(this Vector3 vec, float z)
		{
			vec.z = z;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified X and Y value.
		/// </summary>
		public static Vector3 WithXY(this Vector3 vec, float x, float y)
		{
			vec.x = x;
			vec.y = y;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified X and Z value.
		/// </summary>
		public static Vector3 WithXZ(this Vector3 vec, float x, float z)
		{
			vec.x = x;
			vec.z = z;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with a specified Y and Z value.
		/// </summary>
		public static Vector3 WithYZ(this Vector3 vec, float y, float z)
		{
			vec.y = y;
			vec.z = z;
			return vec;
		}
		/// <summary>
		/// Flips the X, Y, and Z of this Vector3.
		/// </summary>
		public static Vector3 Flip(this Vector3 vec)
		{
			return new Vector3(vec.z, vec.y, vec.x);
		}
		/// <summary>
		/// Returns this Vector2 with it's X and Y as a new Vector3's X and Z with a specified Y.
		/// </summary>
		public static Vector3 ConvertToVector3(this Vector2 vec, float y = 0)
		{
			return new Vector3(vec.x, y, vec.y);
		}
		/// <summary>
		/// Are all of this Vector's values greater than or equal to the specified Vector.
		/// </summary>
		public static bool GreaterThanOrEqual(this Vector3 vec1, Vector3 vec2)
		{
			if (vec1.x >= vec2.x && vec1.y >= vec2.y && vec1.z >= vec2.z)
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// Returns this Vector3 rounded to the nearest 1/2.
		/// </summary>
		public static Vector3 RoundToNearestHalf(this Vector3 vec)
		{
			vec.x = Mathf.RoundToInt(vec.x * 2) / 2f;
			vec.z = Mathf.RoundToInt(vec.z * 2) / 2f;
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 locked to the nearest 1/2.
		/// *Note: This produces cleaner results than RoundToNearestHalf
		/// </summary>
		public static Vector3 LockToNearestHalf(this Vector3 vec)
		{
			vec.x = vec.x.FloorToIntSplit();
			vec.z = vec.z.FloorToIntSplit();
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 rounded to the nearest integer.
		/// </summary>
		public static Vector3 RoundToInt(this Vector3 vec)
		{
			vec.x = Mathf.RoundToInt(vec.x);
			vec.y = Mathf.RoundToInt(vec.y);
			vec.z = Mathf.RoundToInt(vec.z);
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 with it's X and Z rounded to the nearest integer.
		/// </summary>
		public static Vector3 RoundToIntXZ(this Vector3 vec)
		{
			vec.x = Mathf.RoundToInt(vec.x);
			vec.z = Mathf.RoundToInt(vec.z);
			return vec;
		}
		/// <summary>
		/// Returns this Vector3 clamped within a bounds taking into account the object size.
		/// </summary>
		public static Vector3 ClampWithinBounds(this Vector3 vec, Bounds bounds, Vector3 halfScale)
		{
			vec.x = vec.x.ClampWithScale(new Vector2(bounds.min.x, bounds.max.x), halfScale.x);
			vec.z = vec.z.ClampWithScale(new Vector2(bounds.min.z, bounds.max.z), halfScale.z);
			return vec;
		}
	}

	// Ex. material.color = material.color.WithA(0);
	public static class ColorToolkit
	{
		/// <summary>
		/// Returns this Color with a specified R value.
		/// </summary>
		public static Color WithR(this Color c, float r)
		{
			c.r = r;
			return c;
		}
		/// <summary>
		/// Returns this Color with a specified G value.
		/// </summary>
		public static Color WithG(this Color c, float g)
		{
			c.g = g;
			return c;
		}
		/// <summary>
		/// Returns this Color with a specified B value.
		/// </summary>
		public static Color WithB(this Color c, float b)
		{
			c.b = b;
			return c;
		}
		/// <summary>
		/// Returns this Color with a specified A value.
		/// </summary>
		public static Color WithA(this Color c, float a)
		{
			c.a = a;
			return c;
		}
	}

	// Ex. T item = list.Random();
	public static class ListToolkit
	{
		/// <summary>
		/// Returns the first element from this list.
		/// </summary>
		public static T First<T>(this List<T> list)
		{
			return list[0];
		}
		/// <summary>
		/// Returns the last element from this list.
		/// </summary>
		public static T Last<T>(this List<T> list)
		{
			return list[list.Count - 1];
		}
		/// <summary>
		/// Returns a random element from this list.
		/// </summary>
		public static T Random<T>(this List<T> list)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		/// <summary>
		/// Returns a random element from this list and removes the first occurrence of the random element from this list.
		/// </summary>
		public static T GetRandomAndRemove<T>(this List<T> list)
		{
			T item = list.Random();
			list.Remove(item);
			return item;
		}
		/// <summary>
		/// Returns a random element from this list and removes the random element from this list.
		/// </summary>
		public static T GetRandomAndRemoveAt<T>(this List<T> list)
		{
			int randLoc = UnityEngine.Random.Range(0, list.Count);
			T item = list[randLoc];
			list.RemoveAt(randLoc);
			return item;
		}
		/// <summary>
		/// Returns this list with the specified components converted to the correct type.
		/// </summary>
		public static List<T> AddComponentsToList<T>(this List<T> list, Component[] components)
		{
			for (int i = 0; i < components.Length; i++)
			{
				list.Add(components[i].GetComponent<T>());
			}
			return list;
		}
		/// <summary>
		/// Returns this list with the specified components game object component.
		/// </summary>
		public static List<GameObject> AddComponentsToList(this List<GameObject> list, Component[] components)
		{
			for (int i = 0; i < components.Length; i++)
			{
				list.Add(components[i].gameObject);
			}
			return list;
		}
	}

	// Ex. f = f.Squared();
	public static class MathToolkit
	{
		/// <summary>
		/// Returns this float rounded up or down based on the specified midpoint.
		/// </summary>
		public static float RoundAt(this float f, float midpoint)
		{
			midpoint += Mathf.Floor(f);
			return f < midpoint ? Mathf.Floor(f) : Mathf.Ceil(f);
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the time in seconds it took to complete the last frame.
		/// </summary>
		public static float WithDeltaTime(this float f)
		{
			return f * Time.deltaTime;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the interval in seconds at which physics are performed.
		/// </summary>
		public static float WithFixedDelaTime(this float f)
		{
			return f * Time.deltaTime;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the timeScale-independent time in seconds it took to complete the last frame.
		/// </summary>
		public static float WithUnscaledDeltaTime(this float f)
		{
			return f * Time.unscaledDeltaTime;
		}
		/// <summary>
		/// Returns the value of this instance taken to the specified exponential power.
		/// </summary>
		public static float ToPower(this float f, int exponent)
		{
			float total = 1;
			if (exponent < 0)
			{
				LoopAction(exponent * -1, (int i) => total *= i % 2 == 0 ? f * -1 : f);
				total = 1 / total;
			}
			else
			{
				LoopAction(exponent, (int i) => total *= f);
			}
			return total;
		}
		/// <summary>
		/// Loop a single action a specified number of times.
		/// </summary>
		public static void LoopAction(int iterations, Action<int> step)
		{
			for (int i = 0; i < iterations; i++)
			{
				step(i);
			}
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static float Squared(this float f)
		{
			return f * f;
		}
		/// <summary>
		/// Returns the value of this instance taken to the 3rd power.
		/// </summary>
		public static float Cubed(this float f)
		{
			return f * f * f;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static int Squared(this int i)
		{
			return i * i;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static double Squared(this double d)
		{
			return d * d;
		}
		/// <summary>
		/// Returns the value of this instance multiplied by the value of this instance.
		/// </summary>
		public static long Squared(this long l)
		{
			return l * l;
		}
		/// <summary>
		/// Returns the value of this instance taken to Mathf.Floor with .5f added
		/// </summary>
		public static float FloorToIntSplit(this float f)
		{
			return Mathf.FloorToInt(f) + .5f;
		}
		/// <summary>
		/// Returns this float clamped within the Min and Max taking into account the objects scale.
		/// </summary>
		public static float ClampWithScale(this float f, Vector2 minMax, float halfScale)
		{
			for (int i = 0; i < halfScale; i++)
			{
				if (f - i <= minMax.x)
				{
					f = minMax.x + halfScale;
					break;
				}
				else if (f + i >= minMax.y)
				{
					f = minMax.y - halfScale;
					break;
				}
			}
			return f;
		}
	}

	// Ex. s = s.UppercaseFirst();
	public static class StringToolkit
	{
		/// <summary>
		/// Returns this string with a space between each camel case.
		/// </summary>
		public static string SplitOnCamelCase(this string s)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				if (i > 0 && char.IsUpper(s[i]))
				{
					builder.Append(' ');
				}
				builder.Append(s[i]);
			}
			return builder.ToString();
		}
		/// <summary>
		/// Returns this string with an uppercase first letter.
		/// </summary>
		public static string UppercaseFirst(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}
			return char.ToUpper(s[0]) + s.Substring(1);
		}
	}

	// Ex. if (c.IsEnglishLetter()) { }
	public static class CharToolkit
	{
		/// <summary>
		/// Returns true if this char is a lower or upper english letter.
		/// </summary>
		public static bool IsEnglishLetter(this char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}
	}

	// Ex. action.FireAction();
	public static class ActionToolkit
	{
		/// <summary>
		/// Fires this action if the action is not null.
		/// </summary>
		public static void FireAction(this Action action)
		{
			if (action != null)
			{
				action();
			}
		}
		/// <summary>
		/// Fires this action along with a single parameter if the action is not null.
		/// </summary>
		public static void FireAction<T>(this Action<T> action, T t)
		{
			if (action != null)
			{
				action(t);
			}
		}
		/// <summary>
		/// Fires this action along with two parameters if the action is not null.
		/// </summary>
		public static void FireAction<T1, T2>(this Action<T1, T2> action, T1 tOne, T2 tTwo)
		{
			if (action != null)
			{
				action(tOne, tTwo);
			}
		}
		/// <summary>
		/// Fires this action along with three parameters if the action is not null.
		/// </summary>
		public static void FireAction<T1, T2, T3>(this Action<T1, T2, T3> action, T1 tOne, T2 tTwo, T3 tThree)
		{
			if (action != null)
			{
				action(tOne, tTwo, tThree);
			}
		}
	}

	public static class TransformToolkit
	{
		/// <summary>
		/// Returns the transform of all children whose name starts with the specified prefix.
		/// </summary>
		public static Transform[] FindAll(this Transform transform, string prefix)
		{
			List<Transform> matchingTransforms = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.name.Substring(0, prefix.Length).Equals(prefix))
				{
					matchingTransforms.Add(child);
				}
			}
			return matchingTransforms.ToArray();
		}
	}

	// Ex. bounds = bounds.ConvertToViewportBounds(mainCam);
	public static class BoundsToolkit
	{
		/// <summary>
		/// Returns this bounds converted to the specified cameras viewport.
		/// </summary>
		public static Bounds ConvertToViewportBounds(this Bounds bounds, Camera cam)
		{
			bounds.SetMinMax(cam.WorldToViewportPoint(bounds.min).WithZ(cam.nearClipPlane),
				cam.WorldToViewportPoint(bounds.max).WithZ(cam.farClipPlane));
			return bounds;
		}
	}

	public static class CameraToolkit 
	{
		/// <summary>
		/// Returns the bounds of the camera viewport only if its orthographic.
		/// </summary>
		public static Bounds OrthographicBounds (this Camera camera) 
		{
			if (camera.orthographic) 
			{
				float screenAspect = (float)Screen.width / (float)Screen.height;
				float cameraHeight = camera.orthographicSize * 2;

				return new Bounds (
					camera.transform.position,
					new Vector3 (cameraHeight * screenAspect, cameraHeight, 0));
			} 
			else 
			{
				Debug.LogError ("Camera is not orthographic.", camera);
				return new Bounds ();
			}
		}
	}
}
