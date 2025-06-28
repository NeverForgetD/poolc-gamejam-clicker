using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBooster : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string boosterName;
    [SerializeField] private string info;
    [SerializeField] private ulong clickGainPerLevel;
    [SerializeField] private int upgradeCost;
    private float costRatio = 1.4f;
    private int level = 0;

    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private GameObject tooltipPanel;
    [SerializeField] private TextMeshProUGUI tooltipText;

    private void Start()
    {
        ResetInfo();
    }

    public void OnUpgradeBtnClicked()
    {
        if (GameManager.Instance.TryUseEgg((ulong)upgradeCost))
        {
            level++;
            GameManager.Instance.AddClickBonus(clickGainPerLevel);
            upgradeCost = Mathf.RoundToInt(upgradeCost * costRatio);
        }
        Hide();
        ResetInfo();
        Show();
    }

    private string GetHoverDescription()
    {
        return $"클릭 강화 레벨 : {level}\n" +
               $"클릭당 꼬꼬파워 +{1 + level}\n"
               + $"누적 꼬꼬파워 : {GameManager.Instance.totalClickEarnedEgg}\n\n"
               +$"{info}";
    }

    public void ResetInfo()
    {
        tooltipText.text = GetHoverDescription();
        buttonText.text = $"{boosterName} (클릭당 +{level})\n\n" +
                          $"{upgradeCost} 필요";
    }

    private void Show()
    {
        tooltipPanel.SetActive(true);
        ResetInfo();
    }
    private void Hide() => tooltipPanel.SetActive(false);
    public void OnPointerEnter(PointerEventData eventData) => Show();
    public void OnPointerExit(PointerEventData eventData) => Hide();
}
