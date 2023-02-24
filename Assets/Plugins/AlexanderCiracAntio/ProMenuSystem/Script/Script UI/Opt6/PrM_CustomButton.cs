using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AlexanderCA.ProMenu.UI
{
    public class PrM_CustomButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
  {
        #region Attributes
        Sprite _imageDefault;
        Sprite _imageOnClick;
        Sprite _imageOnSelect;
        [SerializeField ]RuntimeAnimatorController m_animatorController;
        AnimationClip _onDefoulVideo;
        AnimationClip _onEnterVideo;
        AnimationClip _onClickVideo;
        AudioSource m_Audio;
        AudioClip _onEnterSound;
        AudioClip _onClickSound;
        bool m_loop;
        #endregion

        #region Unity Calls
        void Start() => StartUp();

        public void OnPointerExit(PointerEventData eventData)
        {
              GetComponent<Image>().sprite = _imageDefault ? _imageDefault : GetComponent<Image>().sprite;
              if(_onDefoulVideo)
              this.gameObject.GetComponent<Animator>().Play(_onDefoulVideo.name);
              if (m_Audio)
              {
                  m_Audio.GetComponent<AudioSource>().mute = true;
                  m_Audio.GetComponent<AudioSource>().loop = m_loop;
              }
        }          
        public void OnPointerEnter(PointerEventData eventData)
        {
              GetComponent<Image>().sprite = _imageOnSelect ? _imageOnSelect: GetComponent<Image>().sprite;
              if(_onEnterVideo)
              this.gameObject.GetComponent<Animator>().Play(_onEnterVideo.name);
              if (m_Audio)
              {
                  m_Audio.GetComponent<AudioSource>().mute = false;
                  m_Audio.GetComponent<AudioSource>().clip = _onEnterSound;
                  m_Audio.GetComponent<AudioSource>().loop = m_loop;
                  m_Audio.GetComponent<AudioSource>().Play();
              }              
        }         
        public void OnPointerDown(PointerEventData eventData)
        {
              GetComponent<Image>().sprite = _imageOnClick ? _imageOnClick : GetComponent<Image>().sprite;
              if(_onClickVideo)              
              this.gameObject.GetComponent<Animator>()?.Play(_onClickVideo.name);
              if (m_Audio)
              {
                  m_Audio.GetComponent<AudioSource>().mute = false;
                  m_Audio.GetComponent<AudioSource>().clip = _onClickSound;
                  m_Audio.GetComponent<AudioSource>().loop = m_loop;
                  m_Audio.GetComponent<AudioSource>().Play();        
              }
        }          
        public void OnPointerUp(PointerEventData eventData)
              
        {
              GetComponent<Image>().sprite = _imageDefault ? _imageDefault : GetComponent<Image>().sprite;
              if(_onDefoulVideo)              
              this.gameObject.GetComponent<Animator>()?.Play(_onDefoulVideo.name);
              if (m_Audio)
              {
                  m_Audio.GetComponent<AudioSource>().mute = true;
                  m_Audio.GetComponent<AudioSource>().loop = m_loop;
              }

        }
        #endregion

        #region Custom public Methods
        /// <summary>
        /// Set differents image to custom the button
        /// </summary>
        /// <param name="_imageDefault">  custom defoult   </param>
        /// <param name="_imageOnClick">  custom On Click  </param>
        /// <param name="_imageOnSelect"> custom On Select </param>
        public void SetImageButton( Sprite _imageDefault, Sprite _imageOnClick, Sprite _imageOnSelect)
        {
              this._imageDefault = _imageDefault;
              this._imageOnClick = _imageOnClick;
              this._imageOnSelect = _imageOnSelect;
        }        
        public void SetSoundButton(AudioSource m_Audio, AudioClip _onEnterSound, AudioClip _onClickSoundo,bool m_loop)
        {
              this.m_Audio = m_Audio;
              this._onEnterSound = _onEnterSound;
              this._onClickSound = _onClickSoundo;
              this.m_loop = m_loop;
        }        
        public void SetVideoButton( RuntimeAnimatorController m_animatorController, AnimationClip m_Idle, AnimationClip _onEnterVideo,AnimationClip _onClickVideo)
        {
              this.m_animatorController = m_animatorController;
              this._onDefoulVideo = m_Idle;
              this._onEnterVideo = _onEnterVideo;
              this._onClickVideo = _onClickVideo;
        }
        #endregion 
    
        #region Custom private Methods
        void StartUp()
        {
              this.gameObject.GetComponent<Image>().sprite = _imageDefault ? _imageDefault : this.gameObject.GetComponent<Image>().sprite;
              if (m_animatorController)
              {
                  if(!GetComponent<Animator>())
                      this.gameObject.AddComponent<Animator>();
                  if (this.gameObject.GetComponent<Animator>().runtimeAnimatorController != m_animatorController && GetComponent<Animator>())
                        this.gameObject.GetComponent<Animator>().runtimeAnimatorController = m_animatorController;

              }


        }
        #endregion
    }
}
