using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoProducer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string producerName;
    [SerializeField] private string info;
    [SerializeField] private int interval;
    private ulong valuePerTick = 0;
    [SerializeField] private ulong gain;

    [SerializeField] private int upgradeCost;

    private float costRatio = 1.2f;

    private int level = 0;
    private ulong totalProducedAmount = 0;
    // 업그레이드 정보

    private int timer = 0;
    private void Start()
    {
        ResetInfo();
    }

    public void OnUpgradeBtnClicked()
    {
        if (GameManager.Instance.TryUseEgg((ulong)upgradeCost))
        {
            level++;
            valuePerTick += gain;
            upgradeCost = Mathf.RoundToInt(upgradeCost * costRatio);
        }
        Hide();
        Show();
    }


    public void Tick()
    {
        timer++;
        if (timer >= interval)
        {
            timer = 0;
            GameManager.Instance.AddEgg(valuePerTick);
            totalProducedAmount += valuePerTick;
        }
    }

    private string GetHoverDescription()
    {
        /*
        return $"{producerName}\n" +
               $"레벨: {level}\n" +
               $"업그레이드 비용: {upgradeCost}\n" +
               $"초당 생산량: {valuePerTick} / {interval}초\n" +
               $"누적 생산량: {totalProducedAmount}";
        */
        return $"강화레벨: {level}\n" +
       $"생산량: {valuePerTick} / {interval}초\n" +
       $"누적 생산량: {totalProducedAmount}\n\n" +
       $"{info}";
    }

    public void ResetInfo()
    {
        tooltipText.text = GetHoverDescription();
        buttonText.text = $"{producerName} [x{upgradeCost}]\n\n" +
                            $"생산량 : {valuePerTick} / {interval}";
    }


    [SerializeField] private GameObject tooltipPanel;
    public TextMeshProUGUI tooltipText;
    public TextMeshProUGUI buttonText;

    private void Show()
    {
        tooltipPanel.SetActive(true);
        ResetInfo();
    }

    private void Hide()
    {
        tooltipPanel.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Show();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hide();
    }
}
