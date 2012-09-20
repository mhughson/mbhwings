using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    /// <summary>
    /// Most buttons will share the same dimensions.
    /// </summary>
    private float buttonWidth = 100;
    private float buttonHeight = 20;

    private float buttonSpacing = 5.0f;

    void OnGUI ()
    {
        // Used for button placement.
        float yPos = Screen.height - buttonHeight;
        float xPos = 0;
        float xSpace = buttonWidth + buttonSpacing;

        // Find the player who is needed to execute some scripts on when a button
        // is pressed.
        GameObject player = GameObject.FindGameObjectWithTag( "Player" );

        // We need to call a function in the PlaneMovement script to set new
        // targets for the plane to fly to.
        PlaneMovement someScript;
        someScript = player.GetComponent<PlaneMovement>();

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Left (Sharp)" ) )
        {
            print ("Left (Sharp) Clicked.");

            // Tell the plane movement script which card has been played.
            someScript.PlayCard( PlaneMovement.Cards.LeftTurnSharp );
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Left (Long)" ) )
        {
            print ("Left (Long) Clicked.");

            someScript.PlayCard( PlaneMovement.Cards.LeftTurnLong );
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Straight (Long)" ) )
        {
            print ("Straight (Long) Clicked.");

            someScript.PlayCard( PlaneMovement.Cards.StraightLong );
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Right (Long)" ) )
        {
            print ("Right (Long) Clicked.");

            someScript.PlayCard( PlaneMovement.Cards.RightTurnLong );
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Right (Sharp)" ) )
        {
            print ("Right (Sharp) Clicked.");

            someScript.PlayCard( PlaneMovement.Cards.RightTurnSharp );
        }

        xPos += xSpace;
    }
}
