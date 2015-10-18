using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
    public int winningplayer;
    private UnityEngine.UI.Text titletext;
    private GUI_Canvas ourcanvas;
    private UnityEngine.UI.Image background;
    private Title thetitle;

	// Use this for initialization
	void Start () {

        thetitle = gameObject.GetComponentInChildren<Title>();

        if(winningplayer == 1)
        {
            thetitle.ChangeTitle("Player 1 Wins!");
        }
        else if(winningplayer == 2)
        {
            thetitle.ChangeTitle("Player 2 Wins!");
        }
        else
        {
            thetitle.ChangeTitle("It's a tie!");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            Application.LoadLevel("launch");
        }
    }
}
