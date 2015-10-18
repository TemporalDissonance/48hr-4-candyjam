using UnityEngine;
using System.Collections;

public class Ammo_Value : MonoBehaviour {
    private UnityEngine.UI.Text thetext;

    public void Display_Value(int in_ammo)
    {
        thetext.text = in_ammo.ToString();
    }
    // Use this for initialization
    void Start () {
        thetext = GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
