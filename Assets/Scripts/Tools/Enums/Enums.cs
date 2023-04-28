using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Tools.Enums
{
    public enum Enums_Inputs
    {
        none,
        down,
        up,
        press
    }

    public enum Enums_AnimationPlayer
    {
        none,
        Idle,
        Move,
        MoveLeft,
        MoveRigh,
        Attack,
        Dead
    }

    public enum Enums_StateGame
    {
        none,
        NormalSpeed,
        FastSpeed,
        Victory,
        Deffet
    }

    public enum TypeBullet
    {
        none,
        bulletPlayer,
        bulletEnemy
    }

    public enum TypePlayer
    {
        Player,
        Enemy
    }
}
