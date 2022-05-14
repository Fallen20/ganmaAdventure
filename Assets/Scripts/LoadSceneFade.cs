using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneFade : MonoBehaviour
{

	public Animator fadeAnimation;
	public SpriteRenderer spriteRender;
    public Rigidbody2D rigid;

    public bool cambio=true;



	public void OnCollisionEnter2D(Collision2D objetoTocando){
		 if(objetoTocando.gameObject.tag=="wispFinal"){
		 	Debug.Log("tocado");
		 	fadeAnimation.SetBool("end", cambio);
		 	MoveScene("sceneFinalALL");

		 }
	}
    
    public void MoveScene(string level_name){
		Debug.Log("escena");
		Debug.Log(fadeAnimation.GetBool("end"));
    	//SceneManager.LoadScene(level_name);
    }
    
}
