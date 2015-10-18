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
	//public GameObject firedMissile;
	public List<GameObject> missiles;
	public float missileTime;
	public float detonateDelay;
	// Use this for initialization
	void Start () {
		//firedMissile = null;
		missileTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		missileTime += Time.fixedDeltaTime;

		if (missiles.Count > 0) {
			for (int i = missiles.Count-1; i > 0; i--) {
				if (missiles [i] == null) {
					missiles.RemoveAt (i);
				}
			}
		}
	}

	public void Buttons(Controller controller) {
		foreach (GameObject element in missiles) {
			if (element != null) {
				element.GetComponent<Missile_Mover>().Buttons(controller);
			}
		}
		/*if (firedMissile != null) {
			firedMissile.GetComponent<Missile_Mover> ().Buttons (controller);
		}*/
	}

	public void Fire() {
		/*if (firedMissile == null) {
			firedMissile = Instantiate (missile, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			missileTime = 0;
		} else {
			if (missileTime > detonateDelay) {
				firedMissile.GetComponent<DestroyByContact>().selfDestruct();
			}
		}*/
		if (missileTime > detonateDelay) {
			missiles.Add (Instantiate (missile, gameObject.transform.position, gameObject.transform.rotation) as GameObject);
			missileTime = 0;
		}

	}
}
