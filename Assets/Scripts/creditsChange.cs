using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creditsChange : MonoBehaviour
{
	// public Canvas  thanks;
	// public Canvas  programs;
	// public Canvas  websites;
	// public Canvas  betaTester;
    //esto solo puede usar websites.GetComponent<Canvas>().enabled=false;, no SetActive


    public GameObject  thanks2;
    public GameObject  programs2;
    public GameObject  websites2;
    public GameObject  betaTester2;
    public GameObject  creation;

	 int contador=0;

    // Start is called before the first frame update
    void Start()
    {

        programs2.gameObject.SetActive(true);
        thanks2.gameObject.SetActive(false);
        betaTester2.gameObject.SetActive(false);
        websites2.gameObject.SetActive(false);
    }

    public void hideMenus(){

    	if(contador==0){

            programs2.SetActive(false);
            thanks2.SetActive(true);
            betaTester2.SetActive(false);
            websites2.SetActive(false);
            creation.SetActive(false);


     		contador=1;
    	}

    	else if(contador==1){

            programs2.SetActive(false);
            thanks2.SetActive(false);
            betaTester2.SetActive(true);
            websites2.SetActive(false);
            creation.SetActive(false);


    		contador=2;
    	}

    	else if(contador==2){
    		
            programs2.SetActive(false);
            thanks2.SetActive(false);
            betaTester2.SetActive(false);
            websites2.SetActive(true);
            creation.SetActive(false);


    		contador=3;
    	}

    	else if(contador==3){


            programs2.SetActive(false);
            thanks2.SetActive(false);
            betaTester2.SetActive(false);
            websites2.SetActive(false);
            creation.SetActive(true);


    		contador=4;
    	}
        else if(contador==4){


            programs2.SetActive(true);
            thanks2.SetActive(false);
            betaTester2.SetActive(false);
            websites2.SetActive(false);
            creation.SetActive(false);


            contador=0;
        }



    }
//con websites.GetComponent<Canvas>().enabled=false; se ve borroso. Solo el primero de todos, programs, no sale borroso
}
