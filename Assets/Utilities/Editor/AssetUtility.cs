using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public static class AssetUtility
{
	public enum Extension { Anim, Controller, Cs, Fbx, Jpg, Json, Mat, Mp3, Mp4, Ogg, Playable, Png, Prefab, Shader, Txt, Unity, Wav };

	private const string ReserializePath = "Assets/Reserialize/";

	[MenuItem(ReserializePath + "All")]
	public static void ReserializeAll()
	{
		AssetDatabase.ForceReserializeAssets();
	}

	[MenuItem(ReserializePath + "Animations")]
	public static void ReserializeAnim()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Anim));
	}

	[MenuItem(ReserializePath + "Animators")]
	public static void ReserializeController()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Controller));
	}

	[MenuItem(ReserializePath + "C# Scripts")]
	public static void ReserializeCs()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Cs));
	}

	[MenuItem(ReserializePath + "Fbx")]
	public static void ReserializeFbx()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Fbx));
	}

	[MenuItem(ReserializePath + "Jpg")]
	public static void ReserializeJpg()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Jpg));
	}

	[MenuItem(ReserializePath + "Json")]
	public static void ReserializeJson()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Json));
	}

	[MenuItem(ReserializePath + "Materials")]
	public static void ReserializeMat()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Mat));
	}

	[MenuItem(ReserializePath + "Mp3")]
	public static void ReserializeMp3()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Mp3));
	}

	[MenuItem(ReserializePath + "Mp4")]
	public static void ReserializeMp4()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Mp4));
	}

	[MenuItem(ReserializePath + "Ogg")]
	public static void ReserializeOgg()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Ogg));
	}

	[MenuItem(ReserializePath + "Playables")]
	public static void ReserializePlayable()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Playable));
	}

	[MenuItem(ReserializePath + "Png")]
	public static void ReserializePng()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Png));
	}

	[MenuItem(ReserializePath + "Prefabs")]
	public static void ReserializePrefab()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Prefab));
	}

	[MenuItem(ReserializePath + "Shaders")]
	public static void ReserializeShaders()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Shader));
	}

	[MenuItem(ReserializePath + "Txt")]
	public static void ReserializeTxt()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Txt));
	}

	[MenuItem(ReserializePath + "Scenes")]
	public static void ReserializeUnity()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Unity));
	}

	[MenuItem(ReserializePath + "Wav")]
	public static void ReserializeWav()
	{
		AssetDatabase.ForceReserializeAssets(AssetsEndingWith(Extension.Wav));
	}

	public static IEnumerable<string> AssetsEndingWith(Extension extension)
	{
		return AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith($".{extension.ToString()}", StringComparison.CurrentCultureIgnoreCase));
	}
}
