using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class SC_ControladroAnuncio : MonoBehaviour
{
  public static SC_ControladroAnuncio m_instancia;

  public string m_IDApp = "ca-app-pub-4149822770479617~8881874217";
  //La id es la de una de pruebas, no es la oficial
  public string m_IDBanner = "ca-app-pub-4149822770479617/7517988940";
  public BannerView Bannerr;
    // Start is called before the first frame update
    void Start()
    {
      if (m_IDApp != null && m_IDApp != "")
      {

      }
    MobileAds.Initialize(initStatus => { });
    ReabirBaners();
    DontDestroyOnLoad(this.gameObject);
  }

    // Update is called once per frame
    void Update()
    {

    }

  private void Awake()
  {
    if (m_instancia == null)
    {
      m_instancia = this;
    }
    else
    {
      Destroy(this);
    }
  }

 public void ReabirBaners()
  {
    Bannerr = new BannerView(m_IDBanner, AdSize.Banner, AdPosition.Top);
    AdRequest request = new AdRequest.Builder().Build();
    Bannerr.LoadAd(request);
    Bannerr.Show();
  }

 public  void esconderBanner()
  {
    Bannerr.Hide();
  }
}
