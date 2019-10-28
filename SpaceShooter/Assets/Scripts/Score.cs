using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static Score instance;

    public Text JugadorScoreText;
    public Text JugadorHealthText;
    public int jugadorHealth = 100;


    public int JugadorScore;


    // Use this for initialization
    void Start()
    {
        instance = this;

        JugadorScore = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void GiveJugadorPuntos(int puntos)
    {
        JugadorScore += puntos;
        JugadorScoreText.text = JugadorScore.ToString();

    }
    public void RestJugadorVidas(int vidas)
    {
        jugadorHealth -= vidas;
        JugadorHealthText.text = jugadorHealth.ToString();

    }


}
