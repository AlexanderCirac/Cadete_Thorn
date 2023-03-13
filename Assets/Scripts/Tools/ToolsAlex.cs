using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AlexanderCA.Tools.Generics
{

    public static class ToolsAlex
    {
        public class PoolGeneric<T> where T : Component
        {
            private List<T> objects = new List<T>();
            public T prefab;
            public T GetObject()
            {
                if ( objects.Count > 0 )
                {
                    T obj = objects[0];
                    objects.RemoveAt(0);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    T obj = GameObject.Instantiate<T>(prefab);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }
            public void ReturnObject(T obj)
            {
                obj.gameObject.SetActive(false);
                objects.Add(obj);
            }
            public void Init()
            {
                for ( int i = 0 ; i < objects.Count ; i++ )
                {
                    T obj = GameObject.Instantiate<T>(prefab);
                    obj.gameObject.SetActive(false);
                    objects.Add(obj);
                }
            }
        }

        public static int ChangeValueGeneric (int value , int decrementAmount , int minLimit)
        {
            return Mathf.Max(minLimit , value - decrementAmount);
        }

        public static int ClampValueGeneric(int value , int minValue , int maxValue , int operation, UnityAction OnClampExceded = null)
        {
            int result = value + operation;
            result = Mathf.Clamp(result , minValue , maxValue);
            if ( result <= minValue )
                OnClampExceded?.Invoke();
            if ( result >= maxValue )
                OnClampExceded?.Invoke();
            return result;
        }

        public class SingletonGeneric<T> : MonoBehaviour where T : MonoBehaviour
        {
            private static T _instance;
            public static bool _createGameObjectIfMissing { get; set; }
            public static T Instance
            {
                get
                {
                    if ( _instance == null )
                    {
                        _instance = FindObjectOfType<T>();
                        if ( _instance == null )
                        {

                            if ( _createGameObjectIfMissing )
                            {
                                GameObject go = new GameObject(typeof(T).Name);
                                _instance = go.AddComponent<T>();
                            }
                            else
                                Debug.LogError($"An instance of {typeof(T)} is needed in the scene, but there is none.");
                        }
                    }
                    return _instance;
                }
            }

            public virtual void DontDestroy()
            {
                if ( _instance == null )
                {
                    _instance = this as T;
                    DontDestroyOnLoad(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
