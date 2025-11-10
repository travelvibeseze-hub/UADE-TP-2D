using UnityEngine.SceneManagement;


//this is our scene manager 

public static class SceneLoader


{
    public static void Load(string sceneName)


    {
        
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single); // rReplace current scene with the new one 

    }
}

