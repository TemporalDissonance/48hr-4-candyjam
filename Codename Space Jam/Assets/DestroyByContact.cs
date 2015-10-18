﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public string ownerTag;
	//public GameObject playerExplosion;
	//public int scoreValue;
	//private GameController gameController;
	
	void Start ()
	{
		/*GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}*/
	}
	
	void OnTriggerEnter (Collider other)
	{


		if (other.tag == "Boundary" || other.tag == "Wall" || other.tag == ownerTag)
		{
			return;
		}
		
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		
		/*if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);*/
		Destroy (gameObject);
	}

	public void selfDestruct() {
		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
