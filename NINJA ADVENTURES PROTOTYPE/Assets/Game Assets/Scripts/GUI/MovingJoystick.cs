using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovingJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image bgImg;
    public Image joystickImg;

    public bool goLeft;
    public bool goRight;

    public Vector3 joysticPos;

    public Vector3 InputDirection { set; get; }
    private void Start()
    {
        bgImg = bgImg.GetComponent<Image>();
        joystickImg = joystickImg.GetComponent<Image>();
        InputDirection = Vector3.zero;
    }
    private void Update()
    {
        if (joystickImg.rectTransform.anchoredPosition.x == 0)
        {
            goLeft = false;
            goRight = false;
        }
    }
    public virtual void OnDrag(PointerEventData ped)
    {

        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);


            InputDirection = new Vector3(pos.x * 2, 0, pos.y * 2);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
            joystickImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3), InputDirection.z * (bgImg.rectTransform.sizeDelta.y / 3));
            if (joystickImg.rectTransform.anchoredPosition.x > 0)
            {
                goLeft = false;
                goRight = true;
            }
            if (joystickImg.rectTransform.anchoredPosition.x < 0)
            {
                goLeft = true;
                goRight = false;
            }

        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {


    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

}