using UnityEngine;
using System.Collections;

public class Hull_Value : MonoBehaviour {
    private UnityEngine.UI.Text thetext;

    public void Display_Value(int in_hull)
    {
        thetext.text = in_hull.ToString(); 
    }

	// Use this for initialization
	void Start () {
        thetext = gameObject.GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
