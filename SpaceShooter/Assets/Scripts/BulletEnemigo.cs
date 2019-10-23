using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemigo : MonoBehaviour {

    public float speed = 10F;
    public int damage = 30;

    public Rigidbody2D rigb;
    public GameObject impactEffect;


    // Use this for initialization
    void Start()
    {
        //direccion del disparo (up*-1 -->  Equivale a un transform.down el cual no existe).
        rigb.velocity = transform.up*-1 * speed;
    }


    //Funcion envia daños al jugador.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Jugador jugador = hitInfo.GetComponent<Jugador>();
        if (jugador != null)
        {
            jugador.TakeDamage(damage);
        }

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
