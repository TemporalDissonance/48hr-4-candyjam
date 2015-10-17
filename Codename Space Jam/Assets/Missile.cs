using UnityEngine;
using System.Collections;

[System.Serializable]
public class Missile : MonoBehaviour {
	
	public Rigidbody missileBody;
	public float fuseDelay;
	private GameObject missileMod;
	private ParticleSystem smokePrefab;
	private AudioClip missileClip;
	
	private Transform target;

	public float thrust;
	public float turnrate;
	private Vector3 yaxis = new Vector3(0.0f, 1.0f, 0.0f);
	private float horizontal;
	private float vertical;
	private Vector3 deltav;

	void Start () {
		
		Fire();
		
	}
	
	void FixedUpdate ()
		
	{
		if (Input.GetButtonDown ("Fire2")) {
			deltav.x = Input.GetAxis ("Horizontal");
			deltav.z = Input.GetAxis ("Vertical");
			deltav.y = 0;
		}
		
		missileBody.velocity = missileBody.velocity + thrust * deltav;
		missileBody.rotation = Quaternion.Slerp(missileBody.rotation, Quaternion.LookRotation(deltav, yaxis), turnrate * Time.deltaTime);
		
	}
	
	void Fire ()
		
	{
		//yield WaitForSeconds (fuseDelay);
		AudioSource.PlayClipAtPoint(missileClip, transform.position);
		
		thrust = 0.2f;
		turnrate = 2f;
		missileBody = GetComponent<Rigidbody>();
	}
	
	void OnCollisionEnter (Collision theCollision)
	{
		
		if(theCollision.gameObject.name == "Wall")
		{
			smokePrefab.emissionRate = 0.0f;
			Destroy(missileMod.gameObject);
			//yield WaitForSeconds(5);
			Destroy(gameObject);
		}
		
	}
}
