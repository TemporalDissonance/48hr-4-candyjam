using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
 
	public string horizontalMap;
	public string verticalMap;
	public string rotateMap;
	public string fireMap;
	public float horizontal;
	public float vertical;
	public bool fire;
	
    void Start()
    {
		horizontalMap = "Horizontal";
		verticalMap = "Vertical";
		fireMap = "Fire1";
    }

	void Update() 
	{
		horizontal = Input.GetAxis (horizontalMap);
		vertical = Input.GetAxis (verticalMap);
		fire = Input.GetButton(fireMap);
		//if (Input.GetButton (fire)) {
			//OurShip.Fire ();
		//}
	}

    void FixedUpdate()
    {

       //OurShip.SetHorizontal(Input.GetAxis(horizontal));
       //OurShip.SetVertical(Input.GetAxis(vertical));
    }
}
