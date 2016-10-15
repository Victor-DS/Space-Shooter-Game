﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter(Collider other) {
        if(other.tag == "shot") {
	        Destroy(other.gameObject);
			Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
    	    Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
