using UnityEngine;
using UnityEngine.Video;

namespace AlexanderCA.ProMenu.UI
{
    using AlexanderCA.ProMenu.Enum;
    public class PrM_VideoTrigger : MonoBehaviour
    {
        #region Attributes
        VideoTriggerEnum _videoTriggerEnum;
        public VideoPlayer _videoPlayer;
        string _nameTagTrigger;
        #endregion

        #region UnityCalls
        void Start() => Init();
        void OnTriggerEnter(Collider coll)
        {
          if (coll.CompareTag(_nameTagTrigger))
              _videoPlayer.enabled = true;
        }
        void OnTriggerEnter2D(Collider2D coll)
        {
          if (coll.CompareTag(_nameTagTrigger))
              _videoPlayer.enabled = true;
        }
        #endregion

        #region Custom public Methods
        public void SetTriggerAttributes(VideoTriggerEnum _videoTriggerEnum, VideoPlayer _videoPlayer, string _nameTagTrigger)
        {
            this._videoTriggerEnum = _videoTriggerEnum;
            this._videoPlayer = _videoPlayer;
            this._nameTagTrigger = _nameTagTrigger;
        } 
        #endregion

        #region Custom private Methods
        public void Init()
        {
            switch (_videoTriggerEnum)
            {
                  //Add components for Trigger 2D
                case VideoTriggerEnum.Trigger2D:
                  if (!GetComponent<BoxCollider2D>())
                  {
                      this.gameObject.AddComponent<BoxCollider2D>();
                      if(GetComponent<BoxCollider2D>().isTrigger == false)
                      GetComponent<BoxCollider2D>().isTrigger = true;
                  }                      
                  if (!GetComponent<Rigidbody2D>())
                  {
                      this.gameObject.AddComponent<Rigidbody2D>();
                      if(GetComponent<Rigidbody2D>().simulated == false)
                      GetComponent<Rigidbody2D>().simulated = true;
                      if(GetComponent<Rigidbody2D>().gravityScale != 0)
                      GetComponent<Rigidbody2D>().gravityScale = 0;
                  }
                  break;
          
                  //Add components for Trigger 3D
                  case VideoTriggerEnum.Trigger3D:
                  if (!GetComponent<BoxCollider>())
                  {
                      this.gameObject.AddComponent<BoxCollider>();
                      if(GetComponent<BoxCollider>().isTrigger == false)
                      GetComponent<BoxCollider>().isTrigger = true;
                  }                      
                  if (!GetComponent<Rigidbody>())
                  {
                      this.gameObject.AddComponent<Rigidbody>();
                      if(GetComponent<Rigidbody>().useGravity == true)
                      GetComponent<Rigidbody>().useGravity = false;

                  }
                  break;

                  case VideoTriggerEnum.None:
                  default:
                  break;
            }
        }
        #endregion 
    }
}
