using UnityEngine;
using UnityEngine.EventSystems;




                //this script sends UI sounds to the AudioManager
public class UIButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler


{



    // click the button

    public void OnPointerClick(PointerEventData e)
    {



        AudioManager.Instance?.PlayButtonClickSound(); // play click sound
    }






    // mouse over the button

    public void OnPointerEnter(PointerEventData e)

    {
         
        AudioManager.Instance?.PlayButtonHoverSound();// play hover sound (if audio exists)
    }



    
}
