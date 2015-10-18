using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Launcher : Weapon {

	public GameObject missile;
	public ButtonState command_rotatecw;
	public ButtonState command_rotateccw;
	//public ButtonState command_thrust_forward;
	//public ButtonState command_thrust_backward;
	//public ButtonState command_thrust_left;
	//public ButtonState command_thrust_right;
	public List<GameObject> missiles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*for (int i = missiles.Count-1; i > 0; i--) {
			if (missiles[i]==null) {
				missiles.RemoveAt (i);
			}
		}*/
	}

	public void Buttons(Controller controller) {
		foreach (GameObject element in missiles) {
			if (element != null) {
				element.GetComponent<Missile_Mover>().Buttons(controller);
			}
		}
	}

	public void Fire() {
		GameObject clone = Instantiate(missile, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		missiles.Add (clone);
	}
}
