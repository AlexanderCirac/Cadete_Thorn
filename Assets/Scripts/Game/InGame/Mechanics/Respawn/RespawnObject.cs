using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.InGame.Mechanicals
{
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Tools.Interfaces;
    public class RespawnObject : MonoBehaviour
    {
        #region Attributes
        [Header("Objects to spawn")]
        [SerializeField] Transform[] _prefabs; 
        private ToolsAlex.PoolMultiGeneric<Transform> pool; 
        [SerializeField] GameObject _point; 
        #endregion

        #region UnityCalls
        void Start() => Init();
        #endregion
        #region privat custom methods
        void Init()
        {
            pool = new ToolsAlex.PoolMultiGeneric<Transform>(_prefabs , 10);
            InvokeRepeating(nameof(InstancePrefab) , .5f , 3f);
        }

        void InstancePrefab()
        {
            Transform bullet = pool.GetObject();
            bullet.transform.position = _point.transform.position;
            bullet.transform.rotation = _point.transform.rotation;
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<IPluriPool>().poolPluri = pool;
            bullet.GetComponent<IPluriPool>().Init();

        }
        
        #endregion
    }
}
