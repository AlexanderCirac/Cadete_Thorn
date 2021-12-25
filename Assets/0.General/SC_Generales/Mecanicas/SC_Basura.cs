using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Basura : MonoBehaviour
{
  public SC_Contador SC_C;
  public int m_puntos;

  private bool m_efectoMuerte;
  public GameObject m_cuerpo;
  public GameObject m_efecto;
  public GameObject m_puntosVer;
  public SC_MoverBloque SC_M;
  public Collider m_collision;
  //en esta script es para darle al jugador los puntos


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    añadirScritp();
    efectoMuertes();
  }

  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("Bala_Jugador"))
    {
      SC_C.m_contandoPuntos = SC_C.m_contandoPuntos + m_puntos;
      m_efectoMuerte = true;
    }
    if (coll.CompareTag("Player"))
    {
      coll.GetComponent<SC_MuerteJugador>().m_muerto = true;
    }
  }

  void añadirScritp()
  {
    if (SC_C == null)
    {
      SC_C = FindObjectOfType<SC_Contador>();
    }
  }

  void efectoMuertes()
  {
    if (m_efectoMuerte)
    {
      SC_M.enabled = false;
      m_collision.enabled = false;
      m_cuerpo.SetActive(false);
      m_efecto.SetActive(true);
      m_puntosVer.SetActive(true);
      if (m_efecto.transform.localScale.y < 150)
      {
        m_efecto.SetActive(true);
        m_efecto.transform.localScale = new Vector3(m_efecto.transform.localScale.x + 255.5f * Time.deltaTime,
        m_efecto.transform.localScale.y + 255.5f * Time.deltaTime, m_efecto.transform.localScale.z + 255.5f * Time.deltaTime);
      }
      else
      {
        Destroy(this.gameObject);
      }
    }
  }
}
