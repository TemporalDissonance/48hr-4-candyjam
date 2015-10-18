using UnityEngine;
using System.Collections;

public class Missile_Mover : MonoBehaviour {
	public float speed;
	public float turnrate;
	private Vector3 currentrotation;
	private Vector3 deltav;
	public ButtonState command_rotatecw;
	public ButtonState command_rotateccw;
	private Rigidbody body;

	void Start ()
	{
		body = GetComponent<Rigidbody>();
		body.velocity = transform.forward * speed;
	}

	void FixedUpdate() {
		deltav.x = 0;
		deltav.y = 0;
		deltav.z = 0;
		turnrate = 0;
		if (command_rotatecw == ButtonState.DOWN) {
			RotateCW ();
		}
		if (command_rotateccw == ButtonState.DOWN) {
			RotateCCW ();
		}
		currentrotation = body.rotation.eulerAngles;
		body.rotation = Quaternion.Euler (currentrotation.x, currentrotation.y + turnrate * Time.deltaTime, currentrotation.z);
		body.velocity = 
	}

	public void Buttons(Controller controller) {
		command_rotatecw = controller.GetButtonState(controller.rotateRMap);
		command_rotateccw = controller.GetButtonState(controller.rotateLMap);
	}
	public void RotateCW() {
		turnrate = 200f;
	}
	
	public void RotateCCW() {
		turnrate = -200f;
	}
}
