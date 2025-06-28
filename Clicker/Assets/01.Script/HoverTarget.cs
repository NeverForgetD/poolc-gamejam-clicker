using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string tooltipMessage;

    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
       TooltipManager.Instance.Show(tooltipMessage);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }
    */
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (TryGetComponent<IHoverDescribable>(out var describable))
        {
            TooltipManager.Instance.Show(describable.GetHoverDescription());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }
}
