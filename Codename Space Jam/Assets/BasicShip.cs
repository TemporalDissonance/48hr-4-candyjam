using UnityEngine;
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
        deltav.x = horizontal;
        deltav.z = vertical;
        deltav.y = 0;

        body.velocity = body.velocity + thrust * deltav;
        body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(deltav, yaxis), turnrate * Time.deltaTime);

		if (command_fire == ButtonState.PRESSED) {
			Fire ();
		}
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
		command_rotatecw = ButtonState.UP;
		command_rotateccw = ButtonState.UP;
		command_thrust_forward = ButtonState.UP;
		command_thrust_backward = ButtonState.UP;
		command_thrust_left = ButtonState.UP;
		command_thrust_right = ButtonState.UP;
		command_fire = ButtonState.UP;
		command_alt_control = ButtonState.UP;

		command_fire = controller.GetButtonState(controller.fireMap);
		command_alt_control = controller.GetButtonState(controller.altMap);
	}
}
