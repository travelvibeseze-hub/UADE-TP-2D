
using UnityEngine;

// keeps music playing when changing scenes

public class MusicPlayer : MonoBehaviour

{

        // this variable stores the only music player

    private static MusicPlayer instance;


    void Awake()
    {


        // check if this is the first music player

        if (instance == null)
        {
            
            
            // this is the first one, so save it

            instance = this;


            
            DontDestroyOnLoad(gameObject);  // tell Unity to not destroy this when loading new scenes
        }


        else

        {
            // there is already a music player, so destro this copy

            Destroy(gameObject);
        }
    }
}
