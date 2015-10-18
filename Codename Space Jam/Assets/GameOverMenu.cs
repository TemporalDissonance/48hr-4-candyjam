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

        if(Player.winningplayer == GameOverState.P1WINSPLANET)
        {
            thetitle.ChangeTitle("Player 1 Wins!");
            theexplanation.AddExplanation("With the Earth ship hovering above, Mars had no choice but to surrender. At last, the war was over.");
        }
        else if(Player.winningplayer == GameOverState.P2WINSPLANET)
        {
            thetitle.ChangeTitle("Player 2 Wins!");
            theexplanation.AddExplanation("When the Mars ship arrived, Earth surrendered and gave up all claim to Mars. At last, Mars was free.");
            
        }
		else if (Player.winningplayer == GameOverState.P1DIES)
		{
			thetitle.ChangeTitle("Player 2 Wins!");
			theexplanation.AddExplanation("Earth's Mightiest Starship blew up");
		}
		else if (Player.winningplayer == GameOverState.P2DIES)
		{
			thetitle.ChangeTitle("Player 1 Wins!");
			theexplanation.AddExplanation("Mar's proud fighter had a tragic slip");
		}
		else if (Player.winningplayer == GameOverState.EVERYONEDIES)
        {
            thetitle.ChangeTitle("It's a tie!");
            theexplanation.AddExplanation("With both starships disabled but far too expensive to replace, both planets looked on in despair.");
        }
		else if (Player.winningplayer == GameOverState.NOONEWINS)
		{
			thetitle.ChangeTitle("It's a tie!");
			theexplanation.AddExplanation("With both starships stupidly out of ammo and fuel, both planets looked on in boredom.");
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
