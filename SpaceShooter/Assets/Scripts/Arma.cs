using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;

    //public int damage;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1")) 
        {

            Shoot();

        }
	}

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }


}
