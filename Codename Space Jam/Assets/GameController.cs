using UnityEngine;
using System.Collections;

public enum GameOverState {
	NOTOVER,
	P1WINSPLANET,
	P2WINSPLANET,
	P1DIES,
	P2DIES,
	EVERYONEDIES
};

public class GameController : MonoBehaviour {
	private bool gameOver;
	private bool restart;
	private float gameOverTime;
	//public GUIText restartText;
	//public GUIText gameOverText;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		gameOverTime = 0;
		//restartText.text = "";
		//gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		if (gameOver) {
			restart = true;
			gameOverTime += Time.deltaTime;
			if (Player.winningplayer == GameOverState.P1WINSPLANET) {
				Application.LoadLevel ("gameover");
			} else if (Player.winningplayer == GameOverState.P2WINSPLANET) {
				Application.LoadLevel ("gameover");
			} else {
				if (gameOverTime > 3) {
					Application.LoadLevel ("gameover");
				} 
			}
		}
	}

	public void GameOver()
	{
		//gameOverText.text = "Game Over!";
		gameOver = true;

	}
}
