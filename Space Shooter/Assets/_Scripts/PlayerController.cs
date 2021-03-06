﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public float fireRate = 0.25f;
	private float nextFire = 0.0f;

	public Boundary boundary;
	
	public GameObject shot;
	public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		speed = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	// FixedUpdate should be used instead of Update when dealing with Rigidbody.
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}
