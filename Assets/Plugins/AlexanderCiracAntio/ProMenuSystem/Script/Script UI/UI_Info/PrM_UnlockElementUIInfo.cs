using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlexanderCA.ProMenu.UI
{
    using AlexanderCA.ProMenu.ToolsInspector;
    public static class PrM_UnlockUI
    {
        public delegate void OnUnlock(int _id, bool _isUnlock);
        public static event  OnUnlock _OnUnlock;
    }

    [System.Serializable]
    public class PrM_UnlockElementUIInfo : MonoBehaviour
    {
        #region URL Explanation

        public ExplicacionUnlockUI _explication;
        public ContentUnlockUI _content;

        [System.Serializable]
        public class ExplicacionUnlockUI
        {
            public ExplicacionUnlockUIEspa�ol Espa�ol;
            public ExplicacionUnlockUIIngles English;
        }

        #region Spanish
        [System.Serializable]
        public class ExplicacionUnlockUIEspa�ol
        {
            public UnlockUIEspa�ol Explicaci�n;
            public UnlockUIUsoEspa�ol Uso;
        }
        [System.Serializable]
        public class UnlockUIEspa�ol
        {
#if UNITY_EDITOR
            [PrM_BoxInspector("En este apartado ser� para habilitar o deshabilitar elementos de la interfaz, dando cada elemento la opci�n de bloquearlo o desbloquearlo, seg�n el progreso del jugador o seg�n la forma que quiera el usuario. Uso: tendr�s que indicar cuantos elementos quieres desbloquear, que imagen adoptara en sus diferentes estados y arrastrar los objetos de la UI interesada", UnityEditor.MessageType.Info)]
            public bool _a;
#endif
        }

        [System.Serializable]
        public class UnlockUIUsoEspa�ol
        {
#if UNITY_EDITOR
            [PrM_BoxInspector("Uso: tendr�s que indicar cuantos elementos quieres desbloquear, que imagen adoptara en sus diferentes estados y arrastrar los objetos de la UI interesada", UnityEditor.MessageType.Warning)]
            public bool _a;
#endif
        }
        #endregion

        #region English
        [System.Serializable]
        public class ExplicacionUnlockUIIngles
        {
            public UnlockUITotalIngles Explanation;
            public UnlockUIUsoIngles Use;
        }
        [System.Serializable]
        public class UnlockUITotalIngles
        {
#if UNITY_EDITOR
            [PrM_BoxInspector("In this section it will be to enable or disable interface elements, giving each element the option to block or unblock it, depending on the player's progress or the way the user wants. Use: you will have to indicate how many elements you want to unlock, what image it will adopt in its different states and drag the objects of the interested UI", UnityEditor.MessageType.Info)]
            public bool _a;
#endif
        }
        [System.Serializable]
        public class UnlockUIUsoIngles
        {
#if UNITY_EDITOR
            [PrM_BoxInspector("Use: You will have to indicate how many elements you want to unlock, what image it will adopt in its different states and drag the objects of the interested UI", UnityEditor.MessageType.Warning)]
            public bool _a;
#endif
        }
        #endregion

        #endregion

        #region URL Content
        [System.Serializable]
        public class ContentUnlockUI
        {
            [Header("Espa�ol:�Cu�ntos elementos quieres bloquear o desbloquear?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:How many items do you want to lock or unlock?", order = 2)]
            [Space(5, order = 3)]
            public UnlockUIContent[] _unlockUIElements;
        }
        [System.Serializable]
        public class UnlockUIContent
        {
            [Header("Espa�ol:�La interfaz para Bloquear es un bot�n?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:Is the interface for Lock a button?", order = 2)]
            [Space(5, order = 3)]
            public Button _unlockUIElements;
            [Header("Espa�ol:�Cu�l ser� el ID de este elemento?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:What will be the ID of this element?", order = 2)]
            [Space(5, order = 3)]
            public int _iDElement;            
            [Header("Espa�ol:�Este elemento tiene im�genes de bloqueo y desbloqueo?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:Does this item have lock and unlock images?", order = 2)]
            [Space(5, order = 3)]
            public StateSpriteUnlock _stateUnlock;
        }
        [System.Serializable]
        public class StateSpriteUnlock
        {
            [Header("Espa�ol:�Qu� SpriteRender se aplicar� a las im�genes de estado?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:What SpriteRender will be applied to the state images?", order = 2)]
            [Space(5, order = 3)]
            public SpriteRenderer _unlockUIElements;
            [Header("Espa�ol:�Cu�l ser� la imagen para Desbloqueado?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:What will be the image for Unlocked?", order = 2)]
            [Space(5, order = 3)]
            public Sprite _imageUnlock;            
            [Header("Espa�ol:�Cu�l ser� la imagen para Bloqueado?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:What will be the image for Blocked?", order = 2)]
            [Space(5, order = 3)]
            public Sprite _imageLock;
        }
        #endregion

        #region URL Error
        /// <summary>
        /// This is to said when there will be an error
        /// </summary>        
        public void GetUnlockUIError(int _i)
        {

        }
        #endregion
    }
}
