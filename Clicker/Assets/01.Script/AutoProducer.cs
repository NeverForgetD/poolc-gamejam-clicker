using UnityEngine;

public class AutoProducer : MonoBehaviour
{
    [SerializeField] private string producerName;
    [SerializeField] private int interval;
    [SerializeField] private ulong valuePerTick;

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
        }
    }
}
