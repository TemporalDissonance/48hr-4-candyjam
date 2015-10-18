using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Controller controller;
	public GameObject ship;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ship.GetComponent<BasicShip>().Buttons (controller);
		//ship.GetComponent<BasicShip>().Buttons (controller);
		/*if (controller.fire) {
			ship.GetComponent<BasicShip>().Fire();
		}
		*/
		//ship.GetComponent<BasicShip>().SetHorizontal(controller.horizontal);
		//ship.GetComponent<BasicShip>().SetVertical(controller.vertical);
	}
}
