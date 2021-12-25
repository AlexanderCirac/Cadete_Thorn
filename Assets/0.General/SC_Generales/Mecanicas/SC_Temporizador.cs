using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_Temporizador : MonoBehaviour
{
  //esta script es para crear un temporizador de cuenta regresiva para indicar el fin del juegete

  

  public float m_contador;
  public Text m_texto;
  [HideInInspector]
  public bool m_parar;// esto es para parar el temporizador

  // Update is called once per frame
  void Update()
    {
      if (!m_parar) {
        Cuenta();
      }
    }

   void Cuenta()
  {
    if (m_contador >= 1)
    {
      m_contador -= 1*Time.deltaTime;
    }
    else
    {
      m_contador = 0;
    }

    m_texto.text = Mathf.FloorToInt(m_contador).ToString(); // esto convierte un float en un int
  }
}
