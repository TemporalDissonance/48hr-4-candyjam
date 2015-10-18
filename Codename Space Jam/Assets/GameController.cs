using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private bool gameOver;
	private bool restart;
	public GUIText restartText;
	public GUIText gameOverText;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		if (gameOver)
		{
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		Application.LoadLevel("gameover");
	}
}
