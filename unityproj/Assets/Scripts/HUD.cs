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

        float yPos = Screen.height - buttonHeight;
        float xPos = 0;
        float xSpace = buttonWidth + buttonSpacing;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Left (Sharp)" ) )
        {
            print ("Left (Sharp) Clicked.");
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Left (Long)" ) )
        {
            print ("Left (Long) Clicked.");
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Straight (Long)" ) )
        {
            print ("Straight (Long) Clicked.");
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Right (Long)" ) )
        {
            print ("Right (Long) Clicked.");
        }

        xPos += xSpace;

        if ( GUI.Button( new Rect ( xPos, yPos, buttonWidth, buttonHeight), "Right (Sharp)" ) )
        {
            print ("Right (Sharp) Clicked.");
        }

        xPos += xSpace;
    }
}
