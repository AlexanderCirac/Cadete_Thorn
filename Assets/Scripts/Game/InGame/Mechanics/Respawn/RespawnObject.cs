using UnityEngine;

namespace C_Thorn.InGame.Mechanicals
{
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Tools.Interfaces;
    public class RespawnObject : MonoBehaviour
    {
        #region Attributes
        [Header("Objects to spawn")]
        [SerializeField] private    Transform[]     _prefabs; 
        [SerializeField] private    GameObject      _point; 
                         private    ToolsAlex.PluralPoolGeneric<Transform> pool; 
        #endregion

        #region UnityCalls
        void Start() => Init();
        #endregion

        #region privat custom methods
        void Init()
        {
            pool = new ToolsAlex.PluralPoolGeneric<Transform>(_prefabs , 10);
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
