using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Controller controller;
	public GameObject ship;

    public static GameOverState winningplayer;
	public static bool P1OUT;
	public static bool P2OUT;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<Controller> ();
		P1OUT = false;
		P2OUT = false;
		winningplayer = GameOverState.NOTOVER;
	}

	void Update() {
		if (ship != null) {
			ship.GetComponent<BasicShip> ().Buttons (controller);
			ship.GetComponent<BasicShip> ().SetHorizontal (controller.horizontal);
			ship.GetComponent<BasicShip> ().SetVertical (controller.vertical);
		} else {
			GetComponentInChildren<Hull_Value>().Display_Value (0);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		//ship.GetComponent<BasicShip>().Buttons (controller);
		/*if (controller.fire) {
			ship.GetComponent<BasicShip>().Fire();
		}
		*/
		//ship.GetComponent<BasicShip>().SetHorizontal(controller.horizontal);
		//ship.GetComponent<BasicShip>().SetVertical(controller.vertical);
	}
}
