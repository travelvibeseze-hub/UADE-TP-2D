using UnityEngine;



public class DeathZone : MonoBehaviour
{


        // when something enters the trigger

    private void OnTriggerEnter2D(Collider2D other)

    {

       // try to get the PlayerMovement component from the object that entered
        PlayerMovement player = other.GetComponent<PlayerMovement>();



        // if we found the component, its the player
        if (player != null)
        {
            Debug.Log("player died!");

            AudioManager.Instance.PlayDeathSound(); // ← AGREGA ESTA LÍNEA

            SceneLoader.Load("Defeat"); // load defeat scene
        }
    }
}
