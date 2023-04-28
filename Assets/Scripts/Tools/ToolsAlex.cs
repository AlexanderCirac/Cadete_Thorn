using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AlexanderCA.Tools.Generics
{

    public static class ToolsAlex
    {
        public enum TypeOverlap
        {
            none,
            box,
            sphere
        }

        #region Pool design pattern
        public class PoolMonoObjectGeneric<T> where T : Component
        {
            private List<T> availableObjects = new List<T>();
            private List<T> inUseObjects = new List<T>();
            public T prefab;

            public PoolMonoObjectGeneric(T prefab , int initialSize)
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

        public class PoolMultiGeneric<T> where T : Component
        {
            private List<T> availableObjects = new List<T>();
            private List<T> inUseObjects = new List<T>();
            public T[] prefabs;

            public PoolMultiGeneric(T[] prefabs , int initialSize)
            {
                this.prefabs = prefabs;

                for ( int i = 0 ; i < initialSize ; i++ )
                {
                    AddObjectToPool();
                }
            }

            private void AddObjectToPool()
            {
                T newObject = GameObject.Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)]);
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
        #endregion

        #region singleton design pattern
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

        #endregion
        public static int GetChangeValue(int value , int decrementAmount , int minLimit)
        {
            return Mathf.Max(minLimit , value - decrementAmount);
        }

        public static int GetClampValue(int value , int minValue , int maxValue , int operation , UnityAction OnClampExceded = null)
        {
            int result = value + operation;
            result = Mathf.Clamp(result , minValue , maxValue);
            if ( result <= minValue )
                OnClampExceded?.Invoke();
            if ( result >= maxValue )
                OnClampExceded?.Invoke();
            return result;
        }

        public static RectTransform GetRectTransform(this Transform t)
        {
            return t as RectTransform;
        }

        public static bool IsOverlap3D(LayerMask _mask , GameObject _whoCheckObject , TypeOverlap _typeOverlap)
        {
            bool  _checkGround = false;

            switch ( _typeOverlap )
            {
                case TypeOverlap.none:
                    _checkGround = false;
                    break;
                case TypeOverlap.box:
                    _checkGround = ( Physics.OverlapBox(_whoCheckObject.transform.position , _whoCheckObject.transform.localScale , Quaternion.identity , _mask) ) != null;
                    break;
                case TypeOverlap.sphere:
                    Collider[] hitColliders = Physics.OverlapSphere(_whoCheckObject.transform.position, 20f, LayerMask.NameToLayer("Player")); foreach ( Collider collider in hitColliders )
                    {
                        if ( collider.gameObject.layer == LayerMask.NameToLayer("Player") )
                        {

                            _checkGround = true;
                            break;
                        }
                    }
                    break;

                default:
                    _checkGround = false;
                    break;
            }


            return _checkGround;
        }

        #region GetObjectScreenLimits
        public class ParametresScreen
        {
            public bool isVertical { get; set; }
            public bool isHorizontal { get; set; }
            public bool isLeft { get; set; }
            public bool isRight { get; set; }
            public bool isBottom { get; set; }
            public bool isTop { get; set; }
            public float leftLimit { get; set; }
            public float rightLimit { get; set; }
            public float bottomLimit { get; set; }
            public float topLimit { get; set; }

        }
        public static ParametresScreen GetObjectScreenLimits(Vector3 objectTransform1 , Camera camera , float Offset = 0f)
        {
            //Combertimos el Input.mousposition en una posicion 3D si el targeto o sino pues el objeto que se ha pasado anteriormente
            Vector3  objectTransform = objectTransform1  == Input.mousePosition ?  Camera.main.ScreenToWorldPoint(Input.mousePosition) : objectTransform1;

            // Calcula los puntos en el mundo correspondientes a las esquinas de la cámara en la pantalla
            Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
            Vector3 bottomRight = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane));
            Vector3 topLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));

            // Crear una instancia de la clase ParametresScreen y asignar los valores
            ParametresScreen result = new ParametresScreen();
            //resluts para el Horizontal
            result.isHorizontal = objectTransform.x > bottomLeft.x + Offset && objectTransform.x < bottomRight.x - Offset;
            result.isLeft = objectTransform.x > bottomLeft.x + Offset;
            result.isRight = objectTransform.x < bottomRight.x - Offset;
            result.leftLimit = bottomLeft.x + Offset;
            result.rightLimit = bottomRight.x - Offset;
            //resluts para el Vertical
            result.isVertical = objectTransform.z > bottomRight.z + Offset && objectTransform.z < topLeft.z - Offset;
            result.isBottom = objectTransform.z > bottomRight.z + Offset;
            result.isTop = objectTransform.z < topLeft.z - Offset;
            result.bottomLimit = bottomRight.z + Offset;
            result.topLimit = topLeft.z - Offset;

            return result;

        }
        #endregion

        public static void SetNewAnimation<TEnum>(TEnum _nameAnimationPlay , Animator _animator) where TEnum : Enum
        {
            if ( !_animator.GetBool(_nameAnimationPlay.ToString()) )
            {
                _animator.SetBool(_nameAnimationPlay.ToString() , true);
                for ( int i = 0 ; i < _animator.parameterCount ; i++ )
                {
                    if ( _animator.GetParameter(i).name != _nameAnimationPlay.ToString() )
                    {
                        _animator.SetBool(_animator.GetParameter(i).name , false);
                    }
                }
            }
        }

    }
}
