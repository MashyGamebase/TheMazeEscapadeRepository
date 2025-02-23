using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    [Tooltip("Tick this on if you want the gameobject to persist across scenes")] public bool DontDestroy = false;

    public static T Instance
    {
        get
        {
            if( _instance == null)
            {
                _instance = FindObjectOfType<T>();

                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void OnAwake()
    {
        _instance = (T)(object)this;

        if (DontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    protected void Awake()
    {
        if (_instance == null)
        {
            OnAwake();
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
}