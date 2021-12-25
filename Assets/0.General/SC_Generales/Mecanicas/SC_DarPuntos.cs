using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DarPuntos : MonoBehaviour
{
  public SC_Contador SC_C;
  public int m_puntos;
  //en esta script es para darle al jugador los puntos

     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      añadirScritp();
    }

  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("Player"))
    {
      SC_C.m_contandoPuntos = SC_C.m_contandoPuntos + m_puntos;
      Destroy(this.gameObject);
    }
  }

  void añadirScritp()
  {
    if (SC_C == null)
    {
      SC_C = FindObjectOfType<SC_Contador>();
    }
  }
}
