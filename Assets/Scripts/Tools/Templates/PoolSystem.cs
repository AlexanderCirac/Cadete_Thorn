using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace C_Thorn.Tools.Templates
{
    public struct PoolSystem
    {
        public class ObjectPool<T> where T : Component
        {
            // ...
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

            void Start()
            {
                for ( int i = 0 ; i < objects.Count ; i++ )
                {
                    T obj = GameObject.Instantiate<T>(prefab);
                    obj.gameObject.SetActive(false);
                    objects.Add(obj);
                }
            }
        }
    }
}
