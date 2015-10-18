using UnityEngine;
using System.Collections;

public class Mars : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("P1Ship"))
        {
            Player.winningplayer = GameOverState.P1WINSPLANET;
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			if (gameControllerObject != null)
			{
				GameController gameController = gameControllerObject.GetComponent <GameController>();
				gameController.GameOver();
			}
			if (gameControllerObject == null)
			{
				Debug.Log ("Cannot find 'GameController' script");
			}      
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
