using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public int health = 100;

    public Transform deathPoint;
    public GameObject deathEffect;

    public Transform firePoint;
    public GameObject bulletPrefab;

    // Use this for initialization (Inicio Auto Ataque):
    void Start()
    {
        AutoAction();
    }

    void AutoAction() 
    {
        StartCoroutine("waitThreeSeconds");
    }

    IEnumerator waitThreeSeconds() 
    {
        yield return new WaitForSeconds(3);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AutoAction(); //loop para repetir disparo una y otra vez.
    }
    //Fin del auto Ataque.


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
        GameObject deathEff = (GameObject)GameObject.Instantiate(deathEffect, deathPoint.position, deathPoint.rotation);
        Destroy(gameObject);
        
        //validacion destroy del sprite del DeathEffect
        UnityEditor.EditorApplication.delayCall += () =>
        {
            Destroy(deathEff);
        };
        
    }

   
}
