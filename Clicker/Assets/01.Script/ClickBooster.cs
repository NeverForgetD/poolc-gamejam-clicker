using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBooster : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string boosterName;
    [SerializeField] private ulong clickGainPerLevel;
    [SerializeField] private int upgradeCost;
    private float costRatio = 2f;
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
        return $"Ŭ�� ��ȭ ����: {level}\n" +
               $"Ŭ���� �����Ŀ� ���귮: {1 + level}\n"
               + $"���� Ŭ�� �����Ŀ� ȹ�淮{GameManager.Instance.totalClickEarnedEgg}";
    }

    public void ResetInfo()
    {
        tooltipText.text = GetHoverDescription();
        buttonText.text = $"{boosterName} (Ŭ���� +{level})\n" +
                          $"{upgradeCost} �ʿ�";
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
