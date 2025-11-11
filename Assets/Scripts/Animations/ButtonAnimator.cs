

using UnityEngine;

using UnityEngine.EventSystems;



// makes buttons grow and shrink when you interact with them

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // How much the button grows when you hover
    [SerializeField] private float hoverScale = 1.1f;


    //how much it shrinks when you click
    [SerializeField] private float clickScale = 0.9f;



    // how fast it changes size
    [SerializeField] private float animSpeed = 10f;



    private Vector3 normalSize; // Original size of the button
    private Vector3 targetSize; // size we want to reach




    void Start()
    {


        // save the original size
        normalSize = transform.localScale;


        targetSize = normalSize;
    }

    void Update()
    {
         // smoothly move towards target size
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Time.deltaTime * animSpeed);
    }




    // when mouse enters the button
    public void OnPointerEnter(PointerEventData eventData)

    {

        targetSize = normalSize * hoverScale; // make it bigger
    }



    // when mouse exits the button
    public void OnPointerExit(PointerEventData eventData)


    {
        targetSize = normalSize; // back to normal size

    }



    // when you press the button
    public void OnPointerDown(PointerEventData eventData)
    {
        targetSize = normalSize * clickScale; // make it smaller

    }




    // when you release the button
    public void OnPointerUp(PointerEventData eventData)
    {

        targetSize = normalSize * hoverScale; // back to the  hovver size
    }
}