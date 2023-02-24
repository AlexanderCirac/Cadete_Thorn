using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEditor;

namespace AlexanderCA.ProMenu.UI
{
    using AlexanderCA.ProMenu.Enum;
    public class PrM_VideoController : PrM_Behaviour
    {
        #region Attributes
        
        VideoPlayer _videoPlayer;
        bool _stopVideo;
        bool _stopAll;
        #endregion

        #region custom public methods
        public IEnumerator AddVideo(GameObject _panelVideo,  VideoClip _clip, bool _isAutomatic, bool _isLoop)
        {
              RenderTexture _renderTexture = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
              _renderTexture.Create();
              if (_panelVideo && _panelVideo.GetComponent<Image>())
                  Destroy(_panelVideo.GetComponent<Image>());
              yield return new WaitForEndOfFrame();
              if (_panelVideo)
              {
                  _panelVideo.AddComponent<VideoPlayer>();
                  this._videoPlayer = _panelVideo.GetComponent<VideoPlayer>();
                  if(!_panelVideo.AddComponent<RawImage>())
                      _panelVideo.AddComponent<RawImage>();
                  _panelVideo.GetComponent<RawImage>().texture = _renderTexture;
                  _panelVideo.GetComponent<RawImage>().raycastTarget = false;
                  _panelVideo.GetComponent<VideoPlayer>().targetTexture = _renderTexture;

                      #if UNITY_STANDALONE
                      _panelVideo.GetComponent<VideoPlayer>().clip = _clip;
                      _panelVideo.GetComponent<VideoPlayer>().source = VideoSource.Url;
                      #endif
                      
                      #if UNITY_WEBGL
                      string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, _clip.name + ".mp4");
                      _panelVideo.GetComponent<VideoPlayer>().source = VideoSource.Url;
                      _panelVideo.GetComponent<VideoPlayer>().url =  filePath;
                      _panelVideo.GetComponent<VideoPlayer>().Prepare();
                      #endif
                  _panelVideo.GetComponent<VideoPlayer>().enabled = _isAutomatic;
                  _panelVideo.GetComponent<VideoPlayer>().isLooping = _isLoop;
                  if(_isAutomatic)
                    _panelVideo.GetComponent<VideoPlayer>().loopPointReached += EndingMode;
              }
  
        }
        public void AddVideoButtonsController(Button _play, Button _pause, Button _quit)
        {
          _play?.onClick.AddListener(()=> 
          { 
              if(!_videoPlayer.isActiveAndEnabled)
              _videoPlayer.GetComponent<VideoPlayer>().gameObject.SetActive(true); 
              if(_videoPlayer.isActiveAndEnabled)
              _videoPlayer.GetComponent<VideoPlayer>().Play();  
          });
          _pause?.onClick.AddListener(()=> _videoPlayer.GetComponent<VideoPlayer>().Pause());
          _quit?.onClick.AddListener(()=> _videoPlayer.GetComponent<VideoPlayer>().gameObject.SetActive(false));
        } 
    
        public IEnumerator AddVideoActivate(Button _buttonActve, GameObject _2DActive, GameObject __3DActive, string _nameTagTrigger)
        {
            yield return new WaitForEndOfFrame();
            _buttonActve?.onClick.AddListener(() => {
              _videoPlayer.GetComponent<VideoPlayer>().enabled = true;
              _videoPlayer.GetComponent<VideoPlayer>().gameObject.SetActive(true);
              _videoPlayer.loopPointReached += EndingMode;
            });
            if (_2DActive)
            {
              _2DActive?.AddComponent<PrM_VideoTrigger>();
              _2DActive.GetComponent<PrM_VideoTrigger>().SetTriggerAttributes( VideoTriggerEnum.Trigger2D, _videoPlayer, _nameTagTrigger) ;
              _videoPlayer.loopPointReached += EndingMode;
            }      
            if (__3DActive)
            {
              __3DActive?.AddComponent<PrM_VideoTrigger>();
              __3DActive.GetComponent<PrM_VideoTrigger>().SetTriggerAttributes(VideoTriggerEnum.Trigger3D, _videoPlayer, _nameTagTrigger);
              _videoPlayer.loopPointReached += EndingMode;
            }
        }
        
        public void AddEndingMode(bool _stopVideo,bool _stopAll)
        {
            this._stopVideo = _stopVideo;
            this._stopAll = _stopAll;
        }
        #endregion

        #region custom private methods
        void EndingMode(UnityEngine.Video.VideoPlayer vp)
        {
  
              if(_stopVideo)
                _videoPlayer.gameObject.GetComponent<RawImage>().enabled = false;
              if(_stopAll)
                _videoPlayer.gameObject.SetActive(false);

                _videoPlayer.loopPointReached -= EndingMode;
        }
        #endregion
    }
}
