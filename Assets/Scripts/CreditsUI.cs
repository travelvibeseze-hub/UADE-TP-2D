
using UnityEngine;


public class CreditsUI : MonoBehaviour

{
    public string mainMenu = "MainMenu";


    public void Back()


    {
        SceneLoader.Load(mainMenu);

    }

}
