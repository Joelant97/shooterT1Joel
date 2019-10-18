using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public int health = 100;

    public Transform deathPoint;
    public GameObject deathEffect;
	// Use this for initialization
	public void TakeDamage (int damage) {
        health -= damage;

        //Daños o la salud es menor de 0 jugador muere.
        if (health <= 0) 
        {
            Die();
        }


	}
	
	// Update is called once per frame
	void Die() {
        Instantiate(deathEffect, deathPoint.position, deathPoint.rotation);
        Destroy(gameObject);
		
	}
}
