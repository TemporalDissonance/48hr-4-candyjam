using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {
    BasicShip OurShip;

    void Start()
    {
        OurShip = gameObject.AddComponent<BasicShip>();
    }

    void FixedUpdate()
    {
       OurShip.SetHorizontal(Input.GetAxis("Horizontal"));
       OurShip.SetVertical(Input.GetAxis("Vertical"));
    }
}
