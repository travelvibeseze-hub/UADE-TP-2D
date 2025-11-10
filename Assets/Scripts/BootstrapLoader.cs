

using UnityEngine;



public class BootstrapLoader : MonoBehaviour


{
    [Header("first scene to load")]


    public string mainMenu = "MainMenu"; //configurable, no hardcoded text


    private void Start()
    {
        
        SceneLoader.Load(mainMenu); //Dont load scenes directly, I ask my managerr to do it
    } 
}
