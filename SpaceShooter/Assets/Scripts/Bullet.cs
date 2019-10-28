using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10F;
    public int damage = 30;

    public int pEne = 15; 
    public int pMet = 10; 
    public int pAst = 5; 


    public Rigidbody2D rb;
    public GameObject impactEffect;


	// Use this for initialization
	void Start () {
        //direccion del disparo.
        rb.velocity = transform.up * speed;
	}


    //Funcion envia daños al enemigo.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemigo enemigo = hitInfo.GetComponent<Enemigo>();
        if (enemigo != null) 
        {
            enemigo.TakeDamage(damage);
            Score.instance.GiveJugadorPuntos(pEne);
           
           
            GameObject impEff = (GameObject)GameObject.Instantiate(impactEffect, transform.position, transform.rotation);

            //destroy object
            Destroy(gameObject);
            //validacion espera un poco y luego destroy con el sprite del impacto
            UnityEditor.EditorApplication.delayCall += () =>
            {
                Destroy(impEff);
            };
        }
        

        //Asteroide
        Asteroide asteroide = hitInfo.GetComponent<Asteroide>();
        if (asteroide != null)
        {
            
            asteroide.TakeDamage(damage);
            Score.instance.GiveJugadorPuntos(pAst);

            GameObject impEff = (GameObject)GameObject.Instantiate(impactEffect, transform.position, transform.rotation);

            //destroy object
            Destroy(gameObject);
            //validacion espera un poco y luego destroy con el sprite del impacto
            UnityEditor.EditorApplication.delayCall += () =>
            {
                Destroy(impEff);
            };
        }
        //Meteoro
        Meteoro meteoro = hitInfo.GetComponent<Meteoro>();
        if (meteoro != null)
        {
            meteoro.TakeDamage(damage);
            Score.instance.GiveJugadorPuntos(pMet);

            GameObject impEff = (GameObject)GameObject.Instantiate(impactEffect, transform.position, transform.rotation);

            //destroy object de la bala
            Destroy(gameObject);
            //validacion espera un poco y luego destroy con el sprite del impacto
            UnityEditor.EditorApplication.delayCall += () =>
            {
                Destroy(impEff);
            };

        }

        
    } 

}
