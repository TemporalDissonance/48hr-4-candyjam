using UnityEngine;
using System.Collections;

[System.Serializable]
public class BasicShip : MonoBehaviour {

    public float thrust;
    public float turnrate;
    private Vector3 yaxis = new Vector3(0.0f, 1.0f, 0.0f);
    private float horizontal;
    private float vertical;
    private Vector3 deltav;
    private Rigidbody body;

    // Use this for initialization
    void Start()
    {
        thrust = 0.2f;
        turnrate = 2f;
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        deltav.x = horizontal;
        deltav.z = vertical;
        deltav.y = 0;

        body.velocity = body.velocity + thrust * deltav;
        body.rotation = Quaternion.Slerp(body.rotation, Quaternion.LookRotation(deltav, yaxis), turnrate * Time.deltaTime);
    }

    public void SetHorizontal(float in_horizontal)
    {
        horizontal = in_horizontal;
    }

    public void SetVertical(float in_vertical)
    {
        vertical = in_vertical;
    }
}
