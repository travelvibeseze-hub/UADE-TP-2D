
using UnityEngine;


public class CameraFollow : MonoBehaviour
{


   

    [SerializeField] private Transform player;


    [SerializeField] private float smoothSpeed = 5f;



    // offset from player position
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);





    void LateUpdate()

    {
        // calculate where we want the camera to be
        Vector3 targetPosition = player.position + offset;



        // smoothly move camera to that position

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
