using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
    private UnityEngine.UI.Text thetext;

    public void ChangeTitle(string in_title)
    {
        thetext = gameObject.GetComponent<UnityEngine.UI.Text>();

        thetext.text = in_title;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
