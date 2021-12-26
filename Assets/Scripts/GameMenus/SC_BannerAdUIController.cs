using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

namespace C_Thorn
{
    public class SC_BannerAdUIController : MonoBehaviour
    {
        #region Attributes 
        public static SC_BannerAdUIController _instance;
        public string _iDApp = "ca-app-pub-4149822770479617~8881874217";
        //La id es la de una de pruebas, no es la oficial
        public string _iDBanner = "ca-app-pub-4149822770479617/7517988940";
        public BannerView _bannerr;
        #endregion

        #region UnityCall
        // Start is called before the first frame update
        private void Awake()
        {
            if (_instance == null)
            {
              _instance = this;
            }
            else
            {
              Destroy(this);
            }
        }
        void Start()
        {
            MobileAds.Initialize(initStatus => { });
            ShowBaners();
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        #region Methods
       public void ShowBaners()
       {
            _bannerr = new BannerView(_iDBanner, AdSize.Banner, AdPosition.Top);
            AdRequest request = new AdRequest.Builder().Build();
            _bannerr.LoadAd(request);
            _bannerr.Show();
       }

       public  void HidenBanner()
       {
          _bannerr.Hide();
       }
       #endregion
    }

}
