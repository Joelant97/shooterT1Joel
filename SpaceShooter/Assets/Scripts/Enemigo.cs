using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public int healthEne = 90;

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
        StartCoroutine("waitRandomSeconds");
    }

    IEnumerator waitRandomSeconds() 
    {
        int randomSecnd = Random.Range(1, 3);
        yield return new WaitForSeconds(randomSecnd);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AutoAction(); //loop para repetir disparo una y otra vez.
    }
    //Fin del auto Ataque.


    //Funcion evalua daños
    public void TakeDamage (int damage) {
        healthEne -= damage;

        //Daños o la salud es menor de 0 jugador muere.
        if (healthEne <= 0) 
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
