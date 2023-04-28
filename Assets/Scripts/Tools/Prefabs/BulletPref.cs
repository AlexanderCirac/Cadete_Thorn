using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AlexanderCA.Tools.Generics;
using C_Thorn.Tools.Interfaces;
using C_Thorn.Tools.Enums;

public class BulletPref : MonoBehaviour, IMonoPool
{
    #region Attributes
    private ToolsAlex.PoolMonoObjectGeneric<Transform> onKill;
    public ToolsAlex.PoolMonoObjectGeneric<Transform> poolMono { get => onKill; set => onKill = value; }

    #endregion

    #region custom Method
    public void Init()
    {
        Invoke(nameof(_ToDestroy) , 0.3f);
        Rigidbody _rg =GetComponent<Rigidbody>();
        _rg.velocity = transform.right * 30;
    }
    void _ToDestroy()
    {
        Transform[] inUseObjects = onKill.GetInUseObjects();
        foreach ( Transform obj in inUseObjects )
        {
            onKill.ReleaseObject(obj);
        }
    }
    #endregion
}
