using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {

	private GameObject BotonGirar, BotonMensaje, Slider;
	private GameObject MenuCubo;
	private GameObject Mensaje;

	private GameObject Camara;


	void Start () {
	
		BotonGirar = GameObject.Find ("BotonGirar");
		BotonMensaje = GameObject.Find ("BotonMensaje");
		MenuCubo = GameObject.Find ("MenuCubo");
		Slider  = GameObject.Find ("Slider");
		Camara = GameObject.Find ("Camera");
		Mensaje = GameObject.Find ("Mensaje");
		BotonGirar.GetComponent<Button>().onClick.AddListener(Gira);
		BotonMensaje.GetComponent<Button>().onClick.AddListener(LanzaMensaje);
		Slider.GetComponent<Slider>().onValueChanged.AddListener(Zoom);
		Mensaje.SetActive (false);

	}

	void LanzaMensaje(){
		StartCoroutine ("MostrarOcultarMensaje");
	}

	IEnumerator MostrarOcultarMensaje(){
	
		Mensaje.SetActive (true);

		Hashtable options = iTween.Hash(
			"y", Mensaje.transform.position.y+0.2f,
			"time", 0.3f,
			"easetype", iTween.EaseType.easeOutBounce
			);
		
		iTween.MoveTo(Mensaje, options);

		yield return new WaitForSeconds (2f);

		options = iTween.Hash(
			"y", Mensaje.transform.position.y-0.2f,
			"time", 0.3f,
			"easetype", iTween.EaseType.easeOutBounce
			);
		
		iTween.MoveTo(Mensaje, options);

		yield return new WaitForSeconds (0.3f);

		Mensaje.SetActive (false);

	}

	void Zoom(float value){

		Camara.transform.Translate(Vector3.forward * value);

	}

	void Gira(){

		iTween.RotateBy(MenuCubo, iTween.Hash("y", 0.080f,"time",0.5f));

	}
	

}
