using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MirarJugador : MonoBehaviour
{
  [HideInInspector]
  public GameObject m_jugador;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    CargarJugador();
    mirarJugador();
    }


  void mirarJugador()
  {
    //this.transform.InverseTransformPoint(this.transform.position);
    this.transform.LookAt(m_jugador.transform);
  }
  void CargarJugador()
  {
     if(m_jugador == null)
    {
      m_jugador = GameObject.FindGameObjectWithTag("Player");
    }
  }
}
