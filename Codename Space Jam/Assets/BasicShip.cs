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
    public int ammo;
    private Fuel_Value fuelreadout;
    private Ammo_Value ammoreadout;
    private Hull_Value hullreadout;

    private Vector3 currentrotation;

    void ReportHUD()
    {
        fuelreadout.Display_Value(fuel);
        ammoreadout.Display_Value(ammo);
        hullreadout.Display_Value(gameObject.GetComponent<Damage>().structuralIntegrity);
    }

    // Use this for initialization
    void Start()
    {
        thrust = 0.04f;
        turnrate = 0f;
        fuel = 100f;
        burnrate = 2f;
        ammo = 10;
        body = GetComponent<Rigidbody>();
        fuelreadout = GetComponentInParent<Player>().GetComponentInChildren<Fuel_Value>();
        ammoreadout = GetComponentInParent<Player>().GetComponentInChildren<Ammo_Value>();
        hullreadout = GetComponentInParent<Player>().GetComponentInChildren<Hull_Value>();
    }

	public void Fire()
	{
		myweapon.GetComponent<Launcher>().Fire();
    }

    void FixedUpdate()
    {
        ReportHUD();

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


        if (horizontal > 0.5) {
			ThrustRight ();
		} else if (horizontal < -0.5) {
			ThrustLeft ();
		}
		if (vertical > 0.5) {
			ThrustBackward ();
		} else if (vertical < -0.5) {
			ThrustForward ();
		}

		if (fuel <= 0.5f && ammo <= 0.5f) {
			if (gameObject.tag == "P1Ship") {
				Player.P1OUT = true;
			} else if (gameObject.tag == "P2Ship") {
				Player.P2OUT = true;
			}
		}

        body.velocity = body.velocity + thrust * deltav;
        currentrotation = body.rotation.eulerAngles;
        body.rotation = Quaternion.Euler (0.0f, currentrotation.y + turnrate * Time.deltaTime, 0.0f);

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
			/*command_thrust_forward = ButtonState.UP;
			command_thrust_backward = ButtonState.UP;
			command_thrust_left = ButtonState.UP;
			command_thrust_right = ButtonState.UP;*/
		} else {
			command_rotatecw = controller.GetButtonState (controller.rotateRMap);
			command_rotateccw = controller.GetButtonState (controller.rotateLMap);
		}
			
		command_thrust_forward = controller.GetButtonState(controller.thrustUMap);
		command_thrust_backward = controller.GetButtonState(controller.thrustDMap);
		command_thrust_left = controller.GetButtonState(controller.thrustLMap);
		command_thrust_right = controller.GetButtonState(controller.thrustRMap);


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
        if (fuel >= burnrate * Time.fixedDeltaTime)
        {
            deltav.z = 1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
    }

	public void ThrustBackward() {
        if (fuel >= burnrate * Time.fixedDeltaTime)
        {
            deltav.z = -1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
	}

	public void ThrustLeft() {
        if (fuel >= burnrate * Time.fixedDeltaTime)
        {
            deltav.x = -1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
	}

	public void ThrustRight() {
        if (fuel >= burnrate * Time.fixedDeltaTime)
        {
            deltav.x = 1;
            fuel = fuel - burnrate * Time.fixedDeltaTime;
        }
	}

	public void Alt() {

	}
}
