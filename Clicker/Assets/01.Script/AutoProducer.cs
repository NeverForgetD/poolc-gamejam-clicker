using UnityEngine;

public class AutoProducer : MonoBehaviour, IHoverDescribable
{
    [SerializeField] private string producerName;
    [SerializeField] private int interval;
    [SerializeField] private ulong valuePerTick;

    [SerializeField] private int upgradeCost;

    private int cost;
    private float costGR;
    private int level = 0;
    private ulong totalProducedAmount = 0;
    // ���׷��̵� ����

    private int timer = 0;

    public void Initialize(string name, int interval, ulong valuePerTick)
    {
        this.producerName = name;
        this.interval = interval;
        this.valuePerTick = valuePerTick;
        this.timer = 0;
    }

    public void Tick()
    {
        timer++;
        if (timer >= interval)
        {
            timer = 0;
            HeightManager.Instance.AddHeight(valuePerTick);
            totalProducedAmount += valuePerTick;
        }
    }

    public string GetHoverDescription()
    {
        return $"{producerName}\n" +
               $"����: {level}\n" +
               $"���׷��̵� ���: {cost}\n" +
               $"�ʴ� ���귮: {valuePerTick} / {interval}��\n" +
               $"�� ���귮: {totalProducedAmount}";
    }
}
