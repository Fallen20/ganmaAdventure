using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class player : MonoBehaviour
{
    public Transform transform;
    public SpriteRenderer spriteRender;
    public Rigidbody2D rigid;
    public Animator animator;

    public Text changeText;
    public GameObject carneObject;
    public Text noPassText;
    public GameObject instrText;

    public SpriteRenderer spriteRender2;
    public Animator fadeAnimation;

    

    public float velocidad=5f;
    public float movHoriztonal=7f;
    public float movVertical=7f;
    public bool onFloor=false;
    public float puntuacion=0;
    public float time=5;
    public bool endReached=false;

    public int puntuacionMax=5;

    
    public AudioSource objetoConMusica;
    public AudioClip runMusic;
    public AudioClip jumpMusic;


    // Start is called before the first frame update
    void Start()
    {
        noPassText.gameObject.SetActive(false);

        Destroy(instrText, time);
        

    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKey(KeyCode.D) && endReached==false)
        {
            transform.position += new Vector3(1f, 0, 0)*velocidad*Time.deltaTime;
            spriteRender.flipX=false;
            animator.SetFloat("speed",2);


        }


        if(Input.GetKeyUp(KeyCode.D) && endReached==false){
            animator.SetFloat("speed",0);
            objetoConMusica.Stop();
        }



        if (Input.GetKey(KeyCode.A) && endReached==false)
        {
            transform.position += new Vector3(-1f, 0, 0)*velocidad*Time.deltaTime;
           spriteRender.flipX=true;
           animator.SetFloat("speed",2);

        }


        if(Input.GetKeyUp(KeyCode.A) && endReached==false){
            animator.SetFloat("speed",0);
            objetoConMusica.Stop();
        }




        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && !Input.GetKey(KeyCode.Space) && onFloor==true){
            objetoConMusica.clip=runMusic;///cambia la musica
            objetoConMusica.Play();//reproduce
        }


        /*if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && !Input.GetKey(KeyCode.Space) && onFloor==true){
            Debug.Log("aquiaaaaaaaaa");
            objetoConMusica.clip=runMusic;///cambia la musica
            objetoConMusica.Play();//reproduce
        }*/


         


        if (Input.GetKeyDown(KeyCode.Space) && onFloor==true && endReached==false){
            rigid.AddForce(Vector2.up*movVertical, ForceMode2D.Impulse);


            objetoConMusica.clip=jumpMusic;
            objetoConMusica.Play();//stpo
        }



//        if(Input.GetKeyUp(KeyCode.Space) && onFloor==false && endReached==false){
  //          animator.SetFloat("speed",1);
    //        animator.SetFloat("jumpChanger",1);
      //  }

         if (!Input.anyKey && onFloor==true && endReached==false){//si no tocas tecla y estas en el suelo
            animator.SetFloat("speed",0);
            objetoConMusica.Stop();
        }


    }

    public void OnCollisionEnter2D(Collision2D objetoTocando){

    	if(objetoTocando.gameObject.tag=="suelo"){
    		onFloor=true;
    	}

    	if(objetoTocando.gameObject.tag=="palo (enemigo)"){
    		transform.position = new Vector3(-6f, -2.3f, 0);
    	}

        if(objetoTocando.gameObject.tag=="paredInvisible"){
           noPassText.gameObject.SetActive(true);
        }

        if(objetoTocando.gameObject.tag=="wispFinal"){
            //cambia el sprite de wisp
           spriteRender2.sprite=(Sprite) Resources.Load<Sprite>("Sprites/wispHappy") as Sprite;
           
           //ahora no se puede mover
           animator.SetFloat("speed",0f);
           endReached=true;
           //Debug.Log(puntuacion);
            objetoConMusica.Stop();//stpo

            fadeAnimation.SetBool("finale", true);

            Invoke("comprobarPuntuaciones",0.7f);//tras un segundo entra
           //cambiar la animacion (wip, hacer otra con otra variable o algo)
           //en lo de animation: if endReached=true poner la animacion nueva. Aqui naada

           //mirar la puntuacion. Depende de cual, un final o otro
           
           
        }

        


    }

    public void comprobarPuntuaciones(){
        if(puntuacion==0){
            if(varsPuntuaciones.NoPuntConseguido==false){
                varsPuntuaciones.NoPuntConseguido=true;
                varsPuntuaciones.finalesConseguidos+=1;
            }
            LoadFadeScene("sceneFinalNoPunt");
           }
           else if(puntuacion==puntuacionMax){
            
            if(varsPuntuaciones.MaxPuntConseguido==false){
                varsPuntuaciones.MaxPuntConseguido=true;
                varsPuntuaciones.finalesConseguidos+=1;
            }
            LoadFadeScene("sceneFinalMaxPunt");
           }

           else{
            if(varsPuntuaciones.NormalPuntConseguido==false){
                varsPuntuaciones.NormalPuntConseguido=true;
                varsPuntuaciones.finalesConseguidos+=1;
            }
           // Debug.Log("No se ha conseguido la puntuacion max");
                LoadFadeScene("sceneFinalNormal");
           }
    }

    public void OnCollisionExit2D(Collision2D objetoTocando){

    	if(objetoTocando.gameObject.tag=="suelo"){
    		onFloor=false;
    	}

        if(objetoTocando.gameObject.tag=="paredInvisible"){
           noPassText.gameObject.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
    	if(col.gameObject.tag=="carne"){
			puntuacion+=1;
    		changeText.text=puntuacion.ToString();//cambia el texto
    		col.gameObject.SetActive(false);//lo vuelve invisible
    		col.gameObject.GetComponent<Renderer>().enabled = false;
    	}

        
        	
    }


    public void LoadFadeScene(string level_name){
        SceneManager.LoadScene(level_name);
    }
        
}