using UnityEngine;
using System.Collections;

[System.Serializable]
public class BasicShip : MonoBehaviour {

    private Vector3 deltav;
    private Rigidbody body;
    public float thrust = 0.1f;
    public float turnrate = 2;
    private Vector3 yaxis = new Vector3(0.0f, 1.0f, 0.0f);
    private float horizontal;
    private float vertical;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        print(horizontal);
        deltav.x = horizontal;
        deltav.z = vertical;
        deltav.y = 0;

        body.velocity = body.velocity + thrust * deltav;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(deltav, yaxis), turnrate * Time.deltaTime);
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
