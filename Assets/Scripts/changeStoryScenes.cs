using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class changeStoryScenes : MonoBehaviour
{
	public static Image imagen;
	int escena=0;
	public Animator animator;
    public GameObject botonSkip;

    // Start is called before the first frame update
    void Start()
    {
    	//fade


        //la primera vez has de ver la escena si o si
        if(varsPuntuaciones.finalesConseguidos==0){
            botonSkip.gameObject.SetActive(false);
        }
        else{botonSkip.gameObject.SetActive(true);}
        
    }

    public void onClickChange(){
   	    imagen=GameObject.FindWithTag("scenes").GetComponent<Image>();


    	if(escena==0){//la primera
			imagen.GetComponent<UnityEngine.UI.Image> ().sprite=Resources.Load<Sprite>("scenesDrawing/inicio2OKPalabra") as Sprite;
    	}

    	if(escena==1){//la segunda
			imagen.GetComponent<UnityEngine.UI.Image> ().sprite=Resources.Load<Sprite>("scenesDrawing/inicio3OKPalabra") as Sprite;
    	}
    	if(escena==2){//la tercera
    		//fade
    		animator.SetBool("finale",true);
    		Invoke("MoveScene",1);//tras un segundo entra
    	}
    	escena+=1;
    	
    }

	public void MoveScene(){
    	SceneManager.LoadScene("juego");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
