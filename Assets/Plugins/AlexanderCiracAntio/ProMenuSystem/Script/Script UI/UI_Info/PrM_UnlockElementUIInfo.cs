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
            public ExplicacionUnlockUIEspañol Español;
            public ExplicacionUnlockUIIngles English;
        }

        #region Spanish
        [System.Serializable]
        public class ExplicacionUnlockUIEspañol
        {
            public UnlockUIEspañol Explicación;
            public UnlockUIUsoEspañol Uso;
        }
        [System.Serializable]
        public class UnlockUIEspañol
        {
#if UNITY_EDITOR
            [PrM_BoxInspector("En este apartado será para habilitar o deshabilitar elementos de la interfaz, dando cada elemento la opción de bloquearlo o desbloquearlo, según el progreso del jugador o según la forma que quiera el usuario. Uso: tendrás que indicar cuantos elementos quieres desbloquear, que imagen adoptara en sus diferentes estados y arrastrar los objetos de la UI interesada", UnityEditor.MessageType.Info)]
            public bool _a;
#endif
        }

        [System.Serializable]
        public class UnlockUIUsoEspañol
        {
#if UNITY_EDITOR
            [PrM_BoxInspector("Uso: tendrás que indicar cuantos elementos quieres desbloquear, que imagen adoptara en sus diferentes estados y arrastrar los objetos de la UI interesada", UnityEditor.MessageType.Warning)]
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
            [Header("Español:¿Cuántos elementos quieres bloquear o desbloquear?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:How many items do you want to lock or unlock?", order = 2)]
            [Space(5, order = 3)]
            public UnlockUIContent[] _unlockUIElements;
        }
        [System.Serializable]
        public class UnlockUIContent
        {
            [Header("Español:¿La interfaz para Bloquear es un botón?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:Is the interface for Lock a button?", order = 2)]
            [Space(5, order = 3)]
            public Button _unlockUIElements;
            [Header("Español:¿Cuál será el ID de este elemento?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:What will be the ID of this element?", order = 2)]
            [Space(5, order = 3)]
            public int _iDElement;            
            [Header("Español:¿Este elemento tiene imágenes de bloqueo y desbloqueo?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:Does this item have lock and unlock images?", order = 2)]
            [Space(5, order = 3)]
            public StateSpriteUnlock _stateUnlock;
        }
        [System.Serializable]
        public class StateSpriteUnlock
        {
            [Header("Español:¿Qué SpriteRender se aplicará a las imágenes de estado?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:What SpriteRender will be applied to the state images?", order = 2)]
            [Space(5, order = 3)]
            public SpriteRenderer _unlockUIElements;
            [Header("Español:¿Cuál será la imagen para Desbloqueado?", order = 0)]
            [Space(-10, order = 1)]
            [Header("English:What will be the image for Unlocked?", order = 2)]
            [Space(5, order = 3)]
            public Sprite _imageUnlock;            
            [Header("Español:¿Cuál será la imagen para Bloqueado?", order = 0)]
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
