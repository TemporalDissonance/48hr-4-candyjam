using UnityEngine;
using System.Collections;

public enum ButtonState {
	UP,
	PRESSED,
	DOWN,
	RELEASED
};


public class Controller : MonoBehaviour {
 
	public string horizontalMap;
	public string verticalMap;
	public string thrustUMap;
	public string thrustDMap;
	public string thrustLMap;
	public string thrustRMap;
	public string rotateLMap;
	public string rotateRMap;
	public string fireMap;
	public string altMap;
	public float horizontal;
	public float vertical;
	
    void Start()
    {
		/*horizontalMap = "Horizontal";
		verticalMap = "Vertical";
		fireMap = "Fire1";
		altMap = "Alt";
		thrustUMap = "ThrustUp";
		thrustDMap = "ThrustDown";
		thrustLMap = "ThrustLeft";
		thrustRMap = "ThrustRight";
		rotateLMap = "RotateLeft";
		rotateRMap = "RotateRight";*/
    }

	void Update() 
	{
		horizontal = Input.GetAxis (horizontalMap);
		vertical = Input.GetAxis (verticalMap);
			//OurShip.Fire ();
		//}
	}

    void FixedUpdate()
    {

       //OurShip.SetHorizontal(Input.GetAxis(horizontal));
       //OurShip.SetVertical(Input.GetAxis(vertical));
    }

	public ButtonState GetButtonState(string map) {
		if (Input.GetButtonDown (map))
			return ButtonState.PRESSED;
		else if (Input.GetButton (map))
			return ButtonState.DOWN;
		else if (Input.GetButtonUp (map))
			return  ButtonState.RELEASED;
		return ButtonState.UP;
	}
}

