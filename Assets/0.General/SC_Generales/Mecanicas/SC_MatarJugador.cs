using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MatarJugador : MonoBehaviour
{

  //esta script  es para cuando un objeto colisione con el jugador lo mate

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerEnter(Collider col)
  {
    if(col.CompareTag("Player")){
      col.GetComponent<SC_MuerteJugador>().m_muerto = true;
    }
  }
}
