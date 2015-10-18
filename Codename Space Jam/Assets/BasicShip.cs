using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public GameObject myweapon;
	public GameObject missile;
	//public List<GameObject> weapons;
    public float fuel;
    public float burnrate;

    private Vector3 currentrotation;

    // Use this for initialization
    void Start()
    {
        thrust = 0.2f;
        turnrate = 0f;
        fuel = 100f;
        burnrate = 1f;
        body = GetComponent<Rigidbody>();
    }

	public void Fire()
	{
		myweapon.GetComponent<Launcher> ().Fire ();
		//GameObject clone = Instantiate(missile, myweapon.transform.position, myweapon.transform.rotation) as GameObject;
	}

    void FixedUpdate()
    {

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
		if (command_thrust_forward == ButtonState.DOWN) {
			ThrustForward ();
		}
		if (command_thrust_backward == ButtonState.DOWN) {
			ThrustBackward ();
		}
		if (command_thrust_left == ButtonState.DOWN) {
			ThrustLeft ();
		}
		if (command_thrust_right == ButtonState.DOWN) {
			ThrustRight ();
		}

		if (command_fire == ButtonState.PRESSED) {
			Fire ();
		}


		/*deltav.x = horizontal;
        deltav.z = vertical;
        deltav.y = 0;
		*/

        body.velocity = body.velocity + thrust * deltav;
        currentrotation = body.rotation.eulerAngles;
        body.rotation = Quaternion.Euler (currentrotation.x, currentrotation.y + turnrate * Time.deltaTime, currentrotation.z);

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
		command_alt_control = controller.GetButtonState(controller.altMap);
		command_fire = controller.GetButtonState(controller.fireMap);
		if (command_alt_control == ButtonState.DOWN) {
			WeaponButtons (controller);
			command_rotatecw = ButtonState.UP;
			command_rotateccw = ButtonState.UP;
			command_thrust_forward = ButtonState.UP;
			command_thrust_backward = ButtonState.UP;
			command_thrust_left = ButtonState.UP;
			command_thrust_right = ButtonState.UP;
		} else {
			command_rotatecw = controller.GetButtonState(controller.rotateRMap);
			command_rotateccw = controller.GetButtonState(controller.rotateLMap);
			command_thrust_forward = controller.GetButtonState(controller.thrustUMap);
			command_thrust_backward = controller.GetButtonState(controller.thrustDMap);
			command_thrust_left = controller.GetButtonState(controller.thrustLMap);
			command_thrust_right = controller.GetButtonState(controller.thrustRMap);
		}


	}

	public void WeaponButtons(Controller controller) {
		myweapon.GetComponent<Launcher> ().Buttons (controller);
		/*foreach (GameObject element in weapons) {
			element.GetComponent<Done_Mover>().Buttons(controller);
		}*/
	}

	public void RotateCW() {
		turnrate = 200f;
	}

	public void RotateCCW() {
		turnrate = -200f;
	}

	public void ThrustForward() {
        if (fuel > 0)
        {
            deltav.z = 1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
    }

	public void ThrustBackward() {
        if (fuel > 0)
        {
            deltav.z = -1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
	}

	public void ThrustLeft() {
        if (fuel > 0)
        {
            deltav.x = -1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
	}

	public void ThrustRight() {
        if(fuel > 0)
        {
            deltav.x = 1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
	}

	public void Alt() {

	}
}
