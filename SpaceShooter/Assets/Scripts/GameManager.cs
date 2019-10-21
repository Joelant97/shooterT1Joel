﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Enemigo enemigo;
    public Jugador jugador;
    public int numEnemigos = 3;

    public static Vector2 topRight;

    // Use this for initialization
    void Start () {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Instantiate(jugador);
        Jugador jugador1 = Instantiate(jugador) as Jugador;
        jugador1.Init(true);

        //Enemigo enemigo1 = Instantiate(enemigo) as Enemigo;

        //clonar los enemigos en posiciones diferentes.
        Enemigo enemigo1 = Instantiate(enemigo) as Enemigo;
        for (int i = 0; i < numEnemigos; ++i)
        {
            Enemigo go = Instantiate(enemigo1) as Enemigo;
            go.transform.position = new Vector3(i *3,  2, 0);
        }

    }


    // Update is called once per frame
    void Update () {
		
	}
}
