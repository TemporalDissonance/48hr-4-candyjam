using UnityEngine;
using System.Collections;

[System.Serializable]
public class Launcher : MonoBehaviour {
	public Rigidbody missile;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) 
		{
			Instantiate(missile, transform.position,transform.rotation);
		}
	}
}
