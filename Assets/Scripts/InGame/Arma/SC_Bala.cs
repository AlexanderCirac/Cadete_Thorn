using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Bala : MonoBehaviour
{
  public float m_velocidad;
  public Rigidbody m_rg;
  private float m_tiempo;
  private float m_velocidadTiempo;
  public GameObject m_yo;

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    irPalante();
    }
  void irPalante()
  {
    m_rg.velocity = transform.TransformDirection(0, 0, m_velocidad * Time.deltaTime);
  }

  void desaparecer()
  {
    m_tiempo += m_velocidadTiempo * Time.deltaTime;

    if (m_tiempo > 10)
    {
      Destroy(m_yo);
    }
  }

  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("Player"))
    {
     // coll.GetComponent<SC_MuerteJugador>().m_muerto = true;
    }
  }
}
