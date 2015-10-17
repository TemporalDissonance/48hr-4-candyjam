using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {
    BasicShip OurShip;
	
    void Start()
    {
		OurShip = gameObject.GetComponent<BasicShip> ();
    }

	void Update() 
	{
		if (Input.GetButton ("Fire1")) {
			OurShip.Fire ();
		}
	}

    void FixedUpdate()
    {
       OurShip.SetHorizontal(Input.GetAxis("Horizontal"));
       OurShip.SetVertical(Input.GetAxis("Vertical"));
    }
}
