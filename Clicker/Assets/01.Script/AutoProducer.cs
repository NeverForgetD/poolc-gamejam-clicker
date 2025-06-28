using System.Runtime.CompilerServices;
using UnityEngine;

public class AutoProducer : MonoBehaviour
{
    [SerializeField] private string producerName;
    [SerializeField] private int interval;
    [SerializeField] private ulong valuePerTick;

    [SerializeField] private int upgradeCost;

    private float costRatio = 1.2f;

    private int level = 0;
    private ulong totalProducedAmount = 0;
    // ���׷��̵� ����

    private int timer = 0;

    public bool CanUpgrade()
    {

        return false;
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
               $"���׷��̵� ���: {upgradeCost}\n" +
               $"�ʴ� ���귮: {valuePerTick} / {interval}��\n" +
               $"�� ���귮: {totalProducedAmount}";
    }
}
