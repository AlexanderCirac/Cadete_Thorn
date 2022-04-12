using UnityEngine;
using GoogleMobileAds.Api;

namespace C_Thorn
{
    public class SC_BannerAdUIController : MonoBehaviour
    {
          #region Attributes 
          [Header("BannerAD")]
          public static SC_BannerAdUIController _instance;
          [SerializeField] string _iDApp = "ca-app-pub-4149822770479617~8881874217";
          //La id es la de una de pruebas, no es la oficial
          [SerializeField] string _iDBanner = "ca-app-pub-4149822770479617/7517988940";
          public BannerView _banner;
          #endregion

          #region UnityCall
          // Start is called before the first frame update
          void Awake() => Init();

          void Start() => Setup();
          #endregion

          #region Custom Private Methods
          void Init()
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
          void Setup()
          {
              MobileAds.Initialize(initStatus => { });
              ToShowBaners();
              DontDestroyOnLoad(this.gameObject);
          }      
         void ToShowBaners()
         {
              _banner = new BannerView(_iDBanner, AdSize.Banner, AdPosition.Top);
              AdRequest request = new AdRequest.Builder().Build();
              _banner.LoadAd(request);
              _banner.Show();
         }

         void ToHidenBanner()
         {
            _banner.Hide();
         }
         #endregion
    }

}
