using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadNewScene : MonoBehaviour
{
	public AudioSource objetoConMusica;

	public AudioClip musicaNormal;
    public AudioClip musica3Estrellas;


	void Start(){
		varsPuntuaciones.Start();
		changeMusic();
	}
	
    public void MoveScene(string level_name){
    	SceneManager.LoadScene(level_name);
    }

    public void QuitGame(){
		Application.Quit();
	}

	public void changeMusic(){
		if(varsPuntuaciones.finalesConseguidos==3){
			objetoConMusica.clip=musica3Estrellas;///cambia la musica
			objetoConMusica.Play();//reproduce
		}
		else{
			objetoConMusica.clip=musicaNormal;
			objetoConMusica.Play();
		}

	}
    

}
