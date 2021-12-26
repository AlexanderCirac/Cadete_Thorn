using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_ControlVictoria : MonoBehaviour
{

  //esta scrip controlara cuando el jugador gane la partida o cuando setermine la partida indicara que ha ganado o a perdido

    //variables para coger informacion de otras script que me dara los datos necesiarios para pasar
  public SC_Contador SC_C;
  public SC_Temporizador SC_T;
  public SC_MuerteJugador SC_M;
  public GameObject m_canvasVictoria;

  public GameObject m_B;
  public GameObject m_A;
  public Text m_tiempo;
  public Text m_puntos;

  [HideInInspector]
  public bool m_victoria;
  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Victoria();
    }

  void Victoria()
  {
      if (SC_T.m_contador == 0 || SC_C.m_contandoPuntos == SC_C.m_maximo || SC_M.m_muerto == true)
      {
        if (SC_C.m_contandoPuntos >= (SC_C.m_maximo * 70)/100)
        {
          Debug.Log("A");
          if (SC_C.m_contandoPuntos >= (SC_C.m_maximo * 90) / 100)
          {
            m_A.SetActive(true);
            m_B.SetActive(false);
            Debug.Log("B");
          }
          else
          {
            m_B.SetActive(true);
            m_A.SetActive(false);
            Debug.Log("C");
          }
          m_canvasVictoria.SetActive(true);
          m_tiempo.text = Mathf.FloorToInt(SC_T.m_contador).ToString();
          m_puntos.text = SC_C.m_contandoPuntos.ToString();
          m_victoria = true;
          SC_M.m_MuerteDerrota = false;
        }
        else
        {
          SC_M.m_muerto = true;
          SC_M.m_MuerteDerrota = true;
      }
        SC_T.m_parar = true;
      }
    }
  }

