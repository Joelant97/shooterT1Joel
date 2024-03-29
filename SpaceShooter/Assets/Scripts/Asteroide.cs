﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour {

    public float speed = 2F;
    public int damage = 5;
    public int restVidaAst = 5; 

    public Rigidbody2D rigb;
    public GameObject impactEffect;

    public int healthAst = 30;
    //public Transform deathPoint;
    public GameObject deathEffect;


    // Use this for initialization
    void Start()
    {
        
        rigb.velocity = transform.up * -1 * speed;
    }


    //Funcion envia daños al jugador.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Jugador jugador = hitInfo.GetComponent<Jugador>();
        if (jugador != null)
        {
            jugador.TakeDamage(damage);
            Score.instance.RestJugadorVidas(restVidaAst);

            GameObject impEff = (GameObject)GameObject.Instantiate(impactEffect, transform.position, transform.rotation);

            //destroy object
            Destroy(gameObject);
            //validacion espera un poco y luego destroy con el sprite del impacto
            UnityEditor.EditorApplication.delayCall += () =>
            {
                Destroy(impEff);
            };
        }

        
    }


    //Funcion evalua daños
    public void TakeDamage(int damage)
    {
        healthAst -= damage;

        //Daños o la salud es menor de 0 muere.
        if (healthAst <= 0)
        {
            Die();
        }


    }

    // Update is called once per frame
    void Die()
    {
        GameObject deathEff = (GameObject)GameObject.Instantiate(deathEffect);
        Destroy(gameObject);

        //validacion destroy del sprite del DeathEffect
        UnityEditor.EditorApplication.delayCall += () =>
        {
            Destroy(deathEff);
        };

    }
}
