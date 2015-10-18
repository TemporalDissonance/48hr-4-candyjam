using UnityEngine;
using System.Collections;

public class Mars : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("P1Ship"))
        {
            Player.winningplayer = 1;
            Application.LoadLevel("gameover");
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
