using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	public int structuralIntegrity;
	public int damageValue;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "P1Ship" || gameObject.tag == "P2Ship") {
			structuralIntegrity = 100;
			damageValue = 50;
		} else if (gameObject.tag == "Asteroid") {
			structuralIntegrity = 30;
			damageValue = 10;
		} else if (gameObject.tag == "Explosion") {
			structuralIntegrity = 1;
			damageValue = 100;
		} else {
			structuralIntegrity = 100000;
			damageValue = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {	
	}

	
	public int getDamageValue ()
	{
		return damageValue;
	}
	
	public void applyDamage (int damage)
	{
		structuralIntegrity -= damage;
		return;
	}

    void OnCollisionEnter(Collision impact)
    {
        if (impact.collider.tag == "Ship" || impact.collider.tag == "Asteroid")
        {
            applyDamage(10 * Mathf.FloorToInt(impact.relativeVelocity.magnitude));
        }
    }

    void OnTriggerEnter(Collider other)
    { 
		if (other.GetComponent<Damage> () != null) {
			applyDamage (other.GetComponent<Damage> ().getDamageValue ());
		}
		return;
	}

}
