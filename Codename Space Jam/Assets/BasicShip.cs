﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class BasicShip : MonoBehaviour {

	public ButtonState command_rotatecw;
	public ButtonState command_rotateccw;
	public ButtonState command_thrust_forward;
	public ButtonState command_thrust_backward;
	public ButtonState command_thrust_left;
	public ButtonState command_thrust_right;
	public ButtonState command_fire;
	public ButtonState command_alt_control;

    public float thrust;
    public float turnrate;
    private Vector3 yaxis = new Vector3(0.0f, 1.0f, 0.0f);
    private float horizontal;
    private float vertical;
	private bool fire1;
	private bool fire2;
    private Vector3 deltav;
    private Rigidbody body;
	public Transform myweapon;
	public GameObject missile;

    // Use this for initialization
    void Start()
    {
        thrust = 0.2f;
        turnrate = 2f;
        body = GetComponent<Rigidbody>();
    }

	public void Fire()
	{
		GameObject clone = Instantiate(missile, myweapon.position, myweapon.rotation) as GameObject;
	}

    void FixedUpdate()
    {
		deltav.x = 0;
		deltav.y = 0;
		deltav.z = 0;

		if (command_rotatecw == ButtonState.DOWN) {
			RotateCW();
		}
		if (command_rotateccw == ButtonState.DOWN) {
			RotateCCW ();
		}
		if (command_thrust_forward == ButtonState.DOWN) {
			ThrustForward();
		}
		if (command_thrust_backward == ButtonState.DOWN) {
			ThrustBackward();
		}
		if (command_thrust_left == ButtonState.DOWN) {
			ThrustLeft ();
		}
		if (command_thrust_right == ButtonState.DOWN) {
			ThrustRight ();
		}
		if (command_fire == ButtonState.DOWN) {
			Fire ();
		}
		if (command_alt_control == ButtonState.DOWN) {
			Alt ();
		}

		/*deltav.x = horizontal;
        deltav.z = vertical;
        deltav.y = 0;
		*/

        body.velocity = body.velocity + thrust * deltav;
        //body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(deltav, yaxis), turnrate * Time.deltaTime);

    }

    public void SetHorizontal(float in_horizontal)
    {
        horizontal = in_horizontal;
    }

    public void SetVertical(float in_vertical)
    {
        vertical = in_vertical;
    }

	public void Buttons(Controller controller) {
		command_rotatecw = controller.GetButtonState(controller.rotateRMap);
		command_rotateccw = controller.GetButtonState(controller.rotateLMap);
		command_thrust_forward = controller.GetButtonState(controller.thrustUMap);
		command_thrust_backward = controller.GetButtonState(controller.thrustDMap);
		command_thrust_left = controller.GetButtonState(controller.thrustLMap);
		command_thrust_right = controller.GetButtonState(controller.thrustRMap);
		command_fire = controller.GetButtonState(controller.fireMap);
		command_alt_control = controller.GetButtonState(controller.altMap);
	}

	public void RotateCW() {
		turnrate = 2f;
	}

	public void RotateCCW() {
		turnrate = -2f;
	}

	public void ThrustForward() {
		deltav.z = 1;
	}

	public void ThrustBackward() {
		deltav.z = -1;
	}

	public void ThrustLeft() {
		deltav.x = -1;
	}

	public void ThrustRight() {
		deltav.x = 1;
	}

	public void Alt() {
	}
}
