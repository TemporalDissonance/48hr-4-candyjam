using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("P2Ship"))
        {
            Player.winningplayer = 2;
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
