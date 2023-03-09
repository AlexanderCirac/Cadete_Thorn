using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPref : MonoBehaviour
{

    private Action<BulletPref> onKill;

    public void Init(Action<BulletPref> actionKill)
    {
        onKill = actionKill;
        Invoke(nameof(_ToDestroy) , 0.3f);
        Rigidbody _rg =GetComponent<Rigidbody>();
        _rg.velocity = transform.forward * 30;
    }
    void _ToDestroy()
    {
     
        onKill( this );
    }
}
