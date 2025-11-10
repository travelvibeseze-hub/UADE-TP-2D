using UnityEngine;
using UnityEngine.SceneManagement;




public class BootstrapLoader : MonoBehaviour


{

    // this script loads the MainMenu when The game starts

    private void Start()
    {
        
        SceneManager.LoadScene("MainMenu"); // load MainMenu Scene (replaces Bootstrap scene)
    }
}