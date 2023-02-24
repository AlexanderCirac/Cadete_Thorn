using UnityEngine;
using UnityEngine.UI;

namespace AlexanderCA.ProMenu
{
    public class PrM_MouseIcon : PrM_Behaviour
    {
        #region Attributes
        RuntimeAnimatorController m_controller;
        AnimationClip m_animClic;
        AnimationClip m_animIdle;  
        Vector2 m_iconoPos;
        Sprite m_imagClic;
        Sprite m_imagIdle;
        bool m_4_1;
        bool yoist;  
        string m_yoistBoton;
        #endregion

        #region UnityCalls
        void Start() => StartUp();

        // Update is called once per frame
        void Update() => UpdateUp();
        #endregion

        #region custom public Methods
        public void SetAnimIcono(RuntimeAnimatorController m_controller,AnimationClip m_animClic,AnimationClip m_animIdle)
        {
          this.m_controller = m_controller;
          this.m_animIdle = m_animIdle;
          this.m_animClic = m_animClic;
        }        
        public void SetImagIcono(Vector2 m_iconoPos, Sprite m_imagClic,Sprite m_imagIdle)
        {
          this.m_iconoPos = m_iconoPos;
          this.m_imagClic = m_imagClic;
          this.m_imagIdle = m_imagIdle;
        }        
        public void SetControlIcono(string m_yoistBoton) => this.m_yoistBoton = m_yoistBoton;    
        #endregion

        #region custom private Methods
        void StartUp()
        {
            Cursor.visible = false;
            this.gameObject.AddComponent<SpriteRenderer>();
            if (m_controller != null)
            {
                if (GetComponent<Animator>() == null)
                  this.gameObject.AddComponent<Animator>();

                this.gameObject.GetComponent<Animator>().runtimeAnimatorController = null;
                this.gameObject.GetComponent<Animator>().runtimeAnimatorController = m_controller;
            }
            PrimerasCosas();

            if (yoist)
            {
                this.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            }
      }
        void UpdateUp()
        {
            LecturaFuncion();
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                this.gameObject.GetComponent<Image>().sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
            }
        }
        void PrimerasCosas()
        {
            ////añadido////
            if (GetComponent<Image>() == null)
                this.gameObject.AddComponent<Image>();
            else
                GetComponent<Image>().raycastTarget = false;

            ////añadido
            if (m_imagIdle != null )
              this.gameObject.GetComponent<Image>().sprite = m_imagIdle;    
            if ( m_animIdle != null)
              this.gameObject.GetComponent<Animator>().Play(m_animIdle.name);

            this.gameObject.AddComponent<Canvas>();
            this.gameObject.GetComponent<Canvas>().overrideSorting = true;
            this.gameObject.GetComponent<Canvas>().additionalShaderChannels = AdditionalCanvasShaderChannels.None;
            this.gameObject.GetComponent<Canvas>().sortingOrder = 30001;

        }
        //public Pla yoist;
        void LecturaFuncion()
        {

            

              gameObject.SetActive(_uIManager._isIconMouseActive);
          if (yoist)
          {

              Vector3 pos = transform.position;

              pos.x = Mathf.Clamp(pos.x +Input.GetAxisRaw("Horizontal") * 20 + m_iconoPos.x, (-Screen.width + Screen.width) + (Screen.width/80), Screen.width - (Screen.width/ 60));

              pos.y = Mathf.Clamp(pos.y + Input.GetAxisRaw("Vertical") * 20 + m_iconoPos.y, (-Screen.height + Screen.height) + (Screen.height / 80), Screen.height - (Screen.height / 60));

              transform.position = pos;
              
          }
          else
          {

          this.transform.position = new Vector3(Input.mousePosition.x + m_iconoPos.x, Input.mousePosition.y + m_iconoPos.y, Input.mousePosition.z);
          }

          if (Input.GetMouseButtonDown(0))
          {
          if (_uIManager._contenido._Option7._content._defoultImage != null /*&& SC_MPPU.contenido.m_Opcion7.m_contenido.m_animacionClicar == null*/)
          {
            if (m_imagClic != null)
            {
              this.gameObject.GetComponent<Image>().sprite = m_imagClic;

            }
          }

          if (/*SC_MPPU.contenido.m_Opcion7.m_contenido.m_iconoClick == null &&*/ _uIManager._contenido._Option7._content._onClickAnim != null)
          {
            if (this.gameObject.GetComponent<Animator>() != null && m_animClic != null)
            {

              this.gameObject.GetComponent<Animator>().Play(m_animClic.name);
            }
          }
        }

        if (m_yoistBoton != "None" && Input.GetKeyDown(m_yoistBoton))
        {
          if (_uIManager._contenido._Option7._content._defoultImage != null /*&& SC_MPPU.contenido.m_Opcion7.m_contenido.m_animacionClicar == null*/)
          {
            if (m_imagClic != null)
            {
              this.gameObject.GetComponent<Image>().sprite = m_imagClic;

            }
          }

          if (/*SC_MPPU.contenido.m_Opcion7.m_contenido.m_iconoClick == null &&*/ _uIManager._contenido._Option7._content._onClickAnim != null)
          {
            if (this.gameObject.GetComponent<Animator>() != null && m_animClic != null)
            {

              this.gameObject.GetComponent<Animator>().Play(m_animClic.name);
            }
          }
        }

        if (Input.GetMouseButtonUp(0))
        {
          if (_uIManager._contenido._Option7._content._onClickImage != null/* && SC_MPPU.contenido.m_Opcion7.m_contenido.m_animacionClicar == null*/)
          {
            if (m_imagIdle != null)
            {
              this.gameObject.GetComponent<Image>().sprite = m_imagIdle;

            }
          }

          if (/*SC_MPPU.contenido.m_Opcion7.m_contenido.m_iconoClick == null &&*/ _uIManager._contenido._Option7._content._onClickAnim != null)
          {
            if (this.gameObject.GetComponent<Animator>() != null && m_animIdle != null)
            {
              this.gameObject.GetComponent<Animator>().Play(m_animIdle.name);
            }
          }
        }

          if (m_yoistBoton != "None" && Input.GetKeyUp(m_yoistBoton))
          {
            if (_uIManager._contenido._Option7._content._onClickImage != null /*&& SC_MPPU.contenido.m_Opcion7.m_contenido.m_animacionClicar == null*/)
            {
              if (m_imagIdle != null)
              {
                this.gameObject.GetComponent<Image>().sprite = m_imagIdle;

              }
            }

            if (/*SC_MPPU.contenido.m_Opcion7.m_contenido.m_iconoClick == null &&*/ _uIManager._contenido._Option7._content._onClickAnim != null)
            {
              if (this.gameObject.GetComponent<Animator>() != null && m_animIdle != null)
              {
                this.gameObject.GetComponent<Animator>().Play(m_animIdle.name);
              }
            }
          }
        }
        #endregion
    }
}
