using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LunaWolfStudios
{
	public static class CameraUtil
	{
		private static Camera s_MainCamera;
		private static Camera s_MinimapCamera;
		private static Camera s_MinimapCameraView;

		public static Camera MainCamera
		{
			get
			{
				if (s_MainCamera == null)
				{
					s_MainCamera = Camera.main;
				}
				return s_MainCamera;
			}
		}

		public static Camera MinimapCamera
		{
			get
			{
				if (s_MinimapCamera == null)
				{
					s_MinimapCamera = Tag.MinimapCamera.Find().GetComponent<Camera>();
				}
				return s_MinimapCamera;
			}
		}

		public static Camera MinimapCameraView
		{
			get
			{
				if (s_MinimapCameraView == null)
				{
					s_MinimapCameraView = Tag.MinimapCameraView.Find().GetComponent<Camera>();
				}
				return s_MinimapCameraView;
			}
		}

		public static bool MinimapPointToWorldPoint(RawImage minimapImage, PointerEventData eventData, out Vector3 worldPoint)
		{
			return MinimapPointToWorldPoint(minimapImage, eventData.position, eventData.pressEventCamera, out worldPoint, Physics.DefaultRaycastLayers);
		}

		public static bool MinimapPointToWorldPoint(RawImage minimapImage, PointerEventData eventData, out Vector3 worldPoint, LayerMask layerMask)
		{
			return MinimapPointToWorldPoint(minimapImage, eventData.position, eventData.pressEventCamera, out worldPoint, layerMask);
		}

		public static bool MinimapPointToWorldPoint(RawImage minimapImage, Vector2 screenPoint, Camera cam, out Vector3 worldPoint, LayerMask layerMask)
		{
			worldPoint = Vector3.zero;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(minimapImage.rectTransform, screenPoint, cam, out Vector2 localCursor))
			{
				var texture = minimapImage.texture;
				var rect = minimapImage.rectTransform.rect;

				// Using the size of the texture and the local cursor, clamp the X, Y coords between 0 and width - height of texture.
				var coordX = Mathf.Clamp(0, (localCursor.x - rect.x) * texture.width / rect.width, texture.width);
				var coordY = Mathf.Clamp(0, (localCursor.y - rect.y) * texture.height / rect.height, texture.height);

				// Convert coordX and coordY to % (0.0-1.0) with respect to texture width and height.
				var recalcX = coordX / texture.width;
				var recalcY = coordY / texture.height;

				localCursor = new Vector2(recalcX, recalcY);

				var ray = MinimapCamera.ScreenPointToRay(new Vector2(localCursor.x * MinimapCamera.pixelWidth, localCursor.y * MinimapCamera.pixelHeight));
				if (Physics.Raycast(ray, out RaycastHit hit, RaycastUtil.MaxRayDistance, layerMask))
				{
					worldPoint = hit.point;
					return true;
				}
			}
			return false;
		}
	}
}
