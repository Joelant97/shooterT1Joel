using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
    public float speed = 0.15f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(0, Time.time * speed); //Vector de pos para el movimiento.
        GetComponent<SpriteRenderer>().material.mainTextureOffset = offset;

    }
}
