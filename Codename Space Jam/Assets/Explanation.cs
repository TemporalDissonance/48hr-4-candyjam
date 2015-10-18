using UnityEngine;
using System.Collections;

public class Explanation : MonoBehaviour {
    private UnityEngine.UI.Text thetext;

    public void AddExplanation(string in_explanation)
    {
        thetext = gameObject.GetComponent<UnityEngine.UI.Text>();

        thetext.text = in_explanation;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
