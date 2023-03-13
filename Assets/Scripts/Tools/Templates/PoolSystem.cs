using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace C_Thorn.Tools.Templates
{

    public class ObjectPool<T> where T : Component
    {
        private List<T> availableObjects = new List<T>();
        private List<T> inUseObjects = new List<T>();
        public T prefab;

        public ObjectPool(T prefab , int initialSize)
        {
            this.prefab = prefab;

            for ( int i = 0 ; i < initialSize ; i++ )
            {
                AddObjectToPool();
            }
        }

        private void AddObjectToPool()
        {
            T newObject = GameObject.Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            availableObjects.Add(newObject);
        }

        public T GetObject()
        {
            if ( availableObjects.Count == 0 )
            {
                AddObjectToPool();
            }

            T objectToUse = availableObjects[0];
            availableObjects.RemoveAt(0);
            objectToUse.gameObject.SetActive(true);
            inUseObjects.Add(objectToUse);

            return objectToUse;
        }

        public void ReleaseObject(T objectToRelease)
        {
            objectToRelease.gameObject.SetActive(false);
            inUseObjects.Remove(objectToRelease);
            availableObjects.Add(objectToRelease);
        }

        public T[] GetInUseObjects()
        {
            return inUseObjects.ToArray();
        }
    }

}
