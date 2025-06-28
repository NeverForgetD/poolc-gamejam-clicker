using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance { get; private set; }

    [SerializeField] private GameObject tooltipPanel;
    [SerializeField] private TextMeshProUGUI tooltipText;
    [SerializeField] private Vector2 offset = new Vector2(10f, -10f);

    private RectTransform tooltipRect;

    private void Awake()
    {
        Instance = this;
        tooltipPanel.SetActive(false);
        tooltipRect = tooltipPanel.GetComponent<RectTransform>();
    }

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

    private void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        tooltipRect.position = mousePos + (Vector2)offset;

        // 화면 밖으로 나가는 것 방지 (선택적)
        ClampToScreen();
    }

    private void ClampToScreen()
    {
        Vector2 anchoredPos = tooltipRect.anchoredPosition;
        Vector2 size = tooltipRect.sizeDelta;
        Vector2 canvasSize = ((RectTransform)tooltipRect.root).sizeDelta;

        anchoredPos.x = Mathf.Clamp(anchoredPos.x, 0, canvasSize.x - size.x);
        anchoredPos.y = Mathf.Clamp(anchoredPos.y, -canvasSize.y + size.y, 0);

        tooltipRect.anchoredPosition = anchoredPos;
    }
}
