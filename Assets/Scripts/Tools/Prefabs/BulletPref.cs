using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AlexanderCA.Tools.Generics;
using C_Thorn.Tools.Templates;
public class BulletPref : MonoBehaviour
{

    //private Action<BulletPref> onKill;
    private ObjectPool<Transform> onKill;

    public void Init(ObjectPool<Transform> actionKill)
    // public void Init(Action<BulletPref> actionKill)
    {
        onKill = actionKill;
        Invoke(nameof(_ToDestroy) , 0.3f);
        Rigidbody _rg =GetComponent<Rigidbody>();
        _rg.velocity = transform.forward * 30;
    }
    void _ToDestroy()
    {

        Transform[] inUseObjects = onKill.GetInUseObjects();
        foreach ( Transform obj in inUseObjects )
        {
            onKill.ReleaseObject(obj);
        }
    }

}
