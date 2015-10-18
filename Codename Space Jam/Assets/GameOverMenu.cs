using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
    private UnityEngine.UI.Text titletext;
    private GUI_Canvas ourcanvas;
    private UnityEngine.UI.Image background;
    private Title thetitle;
    private Explanation theexplanation;

	// Use this for initialization
	void Start () {

        thetitle = gameObject.GetComponentInChildren<Title>();
        theexplanation = gameObject.GetComponentInChildren<Explanation>();
        TextAsset explanationtext;

        if(Player.winningplayer == GameOverState.P1WINSPLANET)
        {
            thetitle.ChangeTitle("Player 1 Wins!");
            explanationtext = Resources.Load("P1WINSPLANET") as TextAsset;
            theexplanation.AddExplanation(explanationtext.text);
        }
        else if(Player.winningplayer == GameOverState.P2WINSPLANET)
        {
            thetitle.ChangeTitle("Player 2 Wins!");
            explanationtext = Resources.Load("P2WINSPLANET") as TextAsset;
            theexplanation.AddExplanation(explanationtext.text);
            
        }
		else if (Player.winningplayer == GameOverState.P1DIES)
		{
			thetitle.ChangeTitle("Player 2 Wins!");
            explanationtext = Resources.Load("P1DIES") as TextAsset;
            theexplanation.AddExplanation(explanationtext.text);
		}
		else if (Player.winningplayer == GameOverState.P2DIES)
		{
			thetitle.ChangeTitle("Player 1 Wins!");
            explanationtext = Resources.Load("P2DIES") as TextAsset;
            theexplanation.AddExplanation(explanationtext.text);
		}
		else if (Player.winningplayer == GameOverState.EVERYONEDIES)
        {
            thetitle.ChangeTitle("It's a tie!");
            explanationtext = Resources.Load("EVERYONEDIES") as TextAsset;
            theexplanation.AddExplanation(explanationtext.text);
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
