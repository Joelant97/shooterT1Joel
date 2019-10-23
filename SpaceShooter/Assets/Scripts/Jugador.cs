using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
    public int health = 100; //Vidas o Salud del Jugador.

    public Transform deathPoint;
    public GameObject deathEffect;

    [SerializeField]
    public float speed;
    float width;

    string input;

    // Use this for initialization
    void Start () {
        width = transform.localScale.y;
        speed = 5f;

    }



    public void Init(bool isRightJugador)
    {
        Vector2 pos = Vector2.zero;
        

        if (isRightJugador)
        {
            //Jugador
            pos = new Vector2(GameManager.topRight.x, -4);
            pos -= Vector2.right * transform.localScale.x;

            input = "Jugador";
        }
        
        transform.position = pos;

        transform.name = input;

    }
    // Update is called once per frame
    void Update () {
        //Mover Jugador
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y > GameManager.topRight.y - width / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.right);
        
    }


    //Funcion evalua daños en el Jugador
    public void TakeDamage(int damage)
    {
        health -= damage;

        //Daños o la salud es menor de 0 jugador muere.
        if (health <= 0)
        {
            Die();
        }


    }

    // Update is called once per frame
    void Die()
    {
        GameObject deathEff = (GameObject)GameObject.Instantiate(deathEffect, deathPoint.position, deathPoint.rotation);
        Destroy(gameObject);

        //validacion destroy del sprite del DeathEffect
        UnityEditor.EditorApplication.delayCall += () =>
        {
            Destroy(deathEff);
        };

    }
}
