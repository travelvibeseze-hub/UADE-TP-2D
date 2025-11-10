

using UnityEngine;



public class MainMenuUI : MonoBehaviour
{
    //This variable stores the name of the scene we want to load when we click "Play"
    public string world = "World";

    
    public string credits = "Credits";

    // this function runs when the player presses the Play button
    public void Play()
    {
        //load the scene stored inside "world"
        SceneLoader.Load(world);
    }


    public void Credits()
    {

        // Load the scene stored inside "credits
        SceneLoader.Load(credits);
    }




    // this function runs when the player presses the Exit button
    public void Exit()

    {

        // If we aree in the Unity editor (testing the game)

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false; // stop play mode (like pressing the play button again)



        // If we are playing the REAL build of the game (not Unity editor)
#else
        Application.Quit(); // close the entire game
#endif
    }
}
