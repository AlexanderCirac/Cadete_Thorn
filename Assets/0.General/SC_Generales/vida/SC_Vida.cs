using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Vida : MonoBehaviour
{
  //De esta forma podemos poner una array de sprites, con una contador de vida actual
  // que controlara de forma atomaticamente los sprites activando y descativando los 
  //correspondientes

  public GameObject[] m_SpriteVida;
  public int m_vida = 3;
  private int m_vidaguardado;
  private bool m_ponerVida;
  private int m_quitadoGuardado;
  private bool m_quitarVida;
  // Start is called before the first frame update
  void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControladorSprite();
    }
  void ControladorSprite()
  {
    ////No funciona bien porque esta leeiendo todo el rato el for y eso
    ////colapsaria la memoria del movil, el problema esque este for esta en un bucle Update, 
    ////con lo cual el valor de i o y siempres seran 0 y leera el bucle for para siempres, no
    ////lo puedo poner en Start porque quiero que lea el for para activar o desactivar sprits
    ////cada vez que cambie el valor de la vida y en estar en Start, solo lo leeria 1 vez
    //for (int i = 0; i < m_vida - 1; i++)
    //{
    //  m_SpriteVida[i].SetActive(true);
    //}
    ////quitar sprite automaticamente
    //for (int y = 0; y < (m_SpriteVida.Length - m_vida); y++)
    //{
    //  m_SpriteVida[m_SpriteVida.Length - y - 1].SetActive(false);
    //}
    //---------------------------------------------------------------------
    //La solucion es intentar que el bucle for solo se lea 1 vez, pero que este
    //comprobando la variable vida todo los frames para indicar que active sprites 
    //o los desactive. forzando que lea el bucle cada vez que esa variable cambie, guardandolo
    //en otra que luego compare con su vida actual para ver si ha avido una diferencia
    //y en el caso de que aya una diferencia con la vida guardad y con la vida actual entonces
    //leeria el bucle y guardara la vida acutal en la variable correspondiente. Para eviatar al principio 
    //problemas,  forzamos un clampeo para dar tiempo a que se guarde la vida para luego hacer la comprovaciones
    //----------------------------
    //poner sprites
    if (m_ponerVida == false && m_vidaguardado != m_vida)
    {
      m_ponerVida = true;
      for (int i = 0; i < m_vida; i++)
      {
        m_SpriteVida[i].SetActive(true);
        Debug.Log("h " + i);
      }
    }
    else
    {
      m_vidaguardado = m_vida;

      m_ponerVida = false;
    }
    //quitar sprites
    if (m_quitarVida == false && m_quitadoGuardado != (m_SpriteVida.Length - m_vida))
    {
      m_quitarVida = true;
      for (int y = 0; y < (m_SpriteVida.Length - m_vida); y++)
      {
        m_SpriteVida[m_SpriteVida.Length - y - 1].SetActive(false);
        Debug.Log("h2 " + y);
      }
    }
    else
    {
      m_quitadoGuardado = (m_SpriteVida.Length - m_vida);
      m_quitarVida = false;
    }
  }
}


