using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction Clicked;

    public void OnPointerClick(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            Clicked.Invoke();
        }
    }
}
