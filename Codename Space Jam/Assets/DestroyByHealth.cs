using UnityEngine;
using System.Collections;

public class DestroyByHealth : MonoBehaviour {
	public GameObject explosion;
	public Damage damage;
	// Use this for initialization
	void Start () {
		damage = gameObject.GetComponent<Damage> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (damage.structuralIntegrity <= 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			if (gameObject.tag == "P1Ship") {
				if (Player.winningplayer == GameOverState.P2DIES) {
					Player.winningplayer = GameOverState.EVERYONEDIES;
				} else {
					Player.winningplayer = GameOverState.P1DIES;
				}
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
			} else if (gameObject.tag == "P2Ship") {
				if (Player.winningplayer == GameOverState.P1DIES) {
					Player.winningplayer = GameOverState.EVERYONEDIES;
				} else {
					Player.winningplayer = GameOverState.P2DIES;
				}
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
			Destroy (gameObject);
		}
	}
}
