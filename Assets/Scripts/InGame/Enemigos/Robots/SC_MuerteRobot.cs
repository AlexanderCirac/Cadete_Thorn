using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MuerteRobot : MonoBehaviour
{
  [HideInInspector]
  public bool m_robotMuerto;
  public SC_Aspa SC_A;
  public SC_DispararRobot SC_DR;
  public GameObject m_robot;
  public GameObject m_asprobot;
  public GameObject m_efecto;

    // Start is called before the first frame update
    void Start()
    {
    m_efecto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      morir();
    }

  void morir()
  {
    if (m_robotMuerto)
    {
      m_robot.SetActive(false);
      m_efecto.SetActive(true);
      m_asprobot.SetActive(false);
      SC_DR.enabled = false;
      SC_A.enabled = false;
      if (m_efecto.transform.localScale.y < 1100)
      {
        m_efecto.SetActive(true);
        m_efecto.transform.localScale = new Vector3(m_efecto.transform.localScale.x + 2850.5f * Time.deltaTime,
        m_efecto.transform.localScale.y + 2850.5f * Time.deltaTime, m_efecto.transform.localScale.z + 2850.5f * Time.deltaTime);
      }
      else
      {
        Destroy(this.gameObject);
      }
    }
  }
}
