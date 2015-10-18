using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("P2Ship"))
        {
            Player.winningplayer = GameOverState.P2WINSPLANET;
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
