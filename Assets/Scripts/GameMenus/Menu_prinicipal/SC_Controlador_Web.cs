using UnityEngine;
using UnityEngine.UI;

namespace C_Thorn.UI
{
			public class SC_Controlador_Web : MonoBehaviour {
					
					#region Attributes
					[Header("URL")]
					[SerializeField] private string _url;
					#endregion

					#region UnityCalls
					void Start () 
					{
						//Button OnClick
						this.GetComponent<Button>().onClick.AddListener(() => Application.OpenURL(_url));
					}
					#endregion
			}

}
