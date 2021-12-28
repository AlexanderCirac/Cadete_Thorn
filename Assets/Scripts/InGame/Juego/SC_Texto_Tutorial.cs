using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using C_Thorn.UI;

public class SC_Texto_Tutorial : MonoBehaviour
{

  public GameObject m_panelTexto;
  public GameObject m_panelCuentaAtras;
  [HideInInspector]
  public bool m_empezar;
  private bool m_soloUnavez;



    // Start is called before the first frame update
    void Start()
    {

    }
  // Update is called once per frame
    void Update()
    {
      ActivarTiempo();
    }

    public void Quitar()
    {
      m_empezar = true;
  }

  void ActivarTiempo()
  {
    if (m_empezar)
    {
      if (!m_soloUnavez)
      {
      m_panelTexto.SetActive(false);
      m_panelCuentaAtras.SetActive(true);
      m_soloUnavez = true;
      }
    }
  }
}
