using UnityEngine;
using System.Collections;

public class Missile_Mover : MonoBehaviour {
	public float thrust;
	public float turnrate;
	private Vector3 currentrotation;
	private Vector3 deltav;
	public ButtonState command_rotatecw;
	public ButtonState command_rotateccw;
	private Rigidbody body;
	public ParticleSystem[] ps;

	void Start ()
	{
		body = GetComponent<Rigidbody>();
		body.velocity = transform.forward * thrust;
		ps = GetComponentsInChildren<ParticleSystem>();

	}

	void Update() {
        turnrate = 0;
		if (command_rotatecw == ButtonState.DOWN) {
			RotateCW ();
		}
		if (command_rotateccw == ButtonState.DOWN) {
			RotateCCW ();
		}
		currentrotation = body.rotation.eulerAngles;
		body.rotation = Quaternion.Euler (currentrotation.x, currentrotation.y + turnrate * Time.deltaTime, currentrotation.z);
        deltav = transform.forward * thrust;
        body.velocity = body.velocity + deltav;
		ps [0].startRotation = Mathf.Deg2Rad * currentrotation.y - Mathf.PI;    //turns rotation into degrees change from startRotation
		ps [1].startRotation = Mathf.Deg2Rad * currentrotation.y;    //turns rotation into degrees change from startRotation
	}

	public void Buttons(Controller controller) {
		command_rotatecw = controller.GetButtonState(controller.missilerotateRMap);
		command_rotateccw = controller.GetButtonState(controller.missilerotateLMap);
	}
	public void RotateCW() {
		turnrate = 200f;
	}
	
	public void RotateCCW() {
		turnrate = -200f;
	}
}
