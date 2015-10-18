using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Random.Range(0.05f,1.0f);
		gameObject.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * Random.Range(0.05f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
