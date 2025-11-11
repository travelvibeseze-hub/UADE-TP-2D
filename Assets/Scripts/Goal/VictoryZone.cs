

using UnityEngine;

public class VictoryZone : MonoBehaviour


{
   

    private void OnTriggerEnter2D(Collider2D other)
    {
            // search if it has the player component

        PlayerMovement player = other.GetComponent<PlayerMovement>();

        // if we found the component, its the player

        if (player != null)

        {
            Debug.Log("you won!");


            AudioManager.Instance.PlayVictorySound(); // ← AGREGA ESTA LÍNEA


            SceneLoader.Load("Victory"); // load victory scene
        }
    }
}



