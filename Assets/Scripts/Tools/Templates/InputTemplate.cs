using UnityEngine;


namespace C_Thorn.Tools.Templates
{

    using C_Thorn.Tools.Enums;
    public abstract class InputTemplate : MonoBehaviour
    {
        #region Attributes
        public delegate void MyDelegateAnimations(Enums_AnimationPlayer _namePlay , bool _boolState);
        public MyDelegateAnimations _myDelegateAnimations;
        #endregion


        #region private custom method
        public abstract Vector3 GetMove();
        public abstract bool GetAttack();
        #endregion
    }
}