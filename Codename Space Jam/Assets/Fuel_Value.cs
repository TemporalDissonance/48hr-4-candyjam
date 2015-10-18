using UnityEngine;
using System.Collections;

public class Fuel_Value : MonoBehaviour {
    private UnityEngine.UI.Text thetext;

    public void Display_Value(float in_fuel)
    {
        thetext.text = Mathf.FloorToInt(in_fuel).ToString();
    }


    // Use this for initialization
    void Start () {
        thetext = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
