using UnityEngine;

namespace AvarikSaga.Exam
{
    public class Singleton<T> : MonoBehaviour where T : Component
	{
		protected static T _instance;

		/// <summary>
		/// Singleton design pattern
		/// </summary>
		/// <value>The instance.</value>
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<T>();
					if (_instance == null)
					{
						GameObject obj = new GameObject();
						_instance = obj.AddComponent<T>();
					}
				}
				return _instance;
			}
		}

		/// <summary>
		/// Initialize Instance
		/// </summary>
		protected virtual void Awake()
		{
			if (!Application.isPlaying)
			{
				return;
			}

			_instance = this as T;
		}
	}
}