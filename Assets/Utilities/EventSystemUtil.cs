using UnityEngine.EventSystems;

namespace LunaWolfStudios
{
	public static class EventSystemUtil
	{
		private static EventSystem _current;

		public static bool IsPointerOverUI() => Current.IsPointerOverGameObject();

		public static EventSystem Current
		{
			get
			{
				if (_current == null)
				{
					_current = EventSystem.current;
				}
				return _current;
			}
		}
	}
}
