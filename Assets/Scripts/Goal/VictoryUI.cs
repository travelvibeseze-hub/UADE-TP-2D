



using UnityEngine;

public class VictoryUI : MonoBehaviour
{

    public string mainMenu = "MainMenu";

    public string resetGame = "World";

  

    public void ResetGame()
    {
        SceneLoader.Load(resetGame);
    }


    // go back to main menu
    public void BackToMenu()
    {
        SceneLoader.Load(mainMenu);
    }

    // this function runs when the player presses the Exit button
    public void Exit()

    {
        // If we aree in the Unity editor (testing the game)

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false; // stop play mode 



        // If we are playing the REAL build of the game (not Unity editor)
#else
        Application.Quit(); // close the entire game
#endif
    }
}



