using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MatarCONAspa : MonoBehaviour
{
  //esta script es para que el aspa pueda matar el jugador


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  

  private void OnTriggerEnter(Collider coll)
  {
    if (coll.CompareTag("Player"))
    {
      coll.GetComponent<SC_MuerteJugador>().m_muerto = true;
    }
  }
}
