using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class varsPuntuaciones : MonoBehaviour
{
	
	public static int finalesConseguidos=0;
	public static bool NoPuntConseguido=false;
	public static bool NormalPuntConseguido=false;
	public static bool MaxPuntConseguido=false;

	//public Image image22;

	public static Image imagen;
	public static Image estrella1;
	public static Image estrella2;
	public static Image estrella3;



    public static void Start(){

    	imagen=GameObject.FindWithTag("fondoPantallaInicio").GetComponent<Image>();
    	estrella1=GameObject.FindWithTag("final1Estrella").GetComponent<Image>();
    	estrella2=GameObject.FindWithTag("final2Estrella").GetComponent<Image>();
    	estrella3=GameObject.FindWithTag("final3Estrella").GetComponent<Image>();


		//lo vuelve invisible
		estrella1.gameObject.SetActive(false);
		//estrella1.gameObject.GetComponent<Renderer>().enabled = false;

		estrella2.gameObject.SetActive(false);
		//estrella2.gameObject.GetComponent<Renderer>().enabled = false;


		estrella3.gameObject.SetActive(false);
		//estrella3.gameObject.GetComponent<Renderer>().enabled = false;


		//Debug.Log("aaaaaaaaaaaaaaa");

		if(finalesConseguidos==3){//cambia la imagen solo cuando saques los 3 finales
			imagen.GetComponent<UnityEngine.UI.Image> ().sprite=Resources.Load<Sprite>("scenesDrawing/allStarsOK") as Sprite;
			
		}

//visible
		if(NormalPuntConseguido==true){
			estrella1.gameObject.SetActive(true);
			//estrella1.gameObject.GetComponent<Renderer>().enabled = true;
		}

		if(NoPuntConseguido==true){
			estrella2.gameObject.SetActive(true);
			//estrella1.gameObject.GetComponent<Renderer>().enabled = true;
		}

		if(MaxPuntConseguido==true){
			estrella3.gameObject.SetActive(true);
			//estrella1.gameObject.GetComponent<Renderer>().enabled = true;
		}



    	
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
