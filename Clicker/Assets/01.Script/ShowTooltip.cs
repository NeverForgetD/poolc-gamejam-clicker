using UnityEngine;

public class ShowTooltip : MonoBehaviour
{
    [SerializeField] private GameObject tooltipPanel;

    public void Show(string message)
    {
        tooltipText.text = message;
        tooltipPanel.SetActive(true);
        UpdatePosition();
    }

    public void Hide()
    {
        tooltipPanel.SetActive(false);
    }
}
