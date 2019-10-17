using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
    [SerializeField]
    public float speed;
    float width;

    string input;

    // Use this for initialization
    void Start () {
        width = transform.localScale.x;
        speed = 5f;

    }



    public void Init(bool isRightJugador)
    {
        Vector2 pos = Vector2.zero;

        if (isRightJugador)
        {
            //Jugador de la derecha
            pos = new Vector2(GameManager.topRight.y, -4);
            pos -= Vector2.right * transform.localScale.y;

            input = "Jugador";
        }
        
        transform.position = pos;

        transform.name = input;

    }
    // Update is called once per frame
    void Update () {
        //Mover Jugador
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.x > GameManager.topRight.x - width / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.right);
    }
}
