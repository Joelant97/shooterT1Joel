using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Enemigo enemigo;
    public Jugador jugador;

    public static Vector2 topRight;

    // Use this for initialization
    void Start () {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Instantiate(jugador);
        Jugador jugador1 = Instantiate(jugador) as Jugador;
        jugador1.Init(true);

        Enemigo enemigo1 = Instantiate(enemigo) as Enemigo;
        //Enemigo enemigo2 = Instantiate(enemigo) as Enemigo;
        //Enemigo enemigo3 = Instantiate(enemigo) as Enemigo;
        //Enemigo enemigo4 = Instantiate(enemigo) as Enemigo;
        //Enemigo enemigo5 = Instantiate(enemigo) as Enemigo;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
