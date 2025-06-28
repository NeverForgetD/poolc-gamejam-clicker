using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    private float timer = 0f;

    [SerializeField] private List<AutoProducer> producers = new List<AutoProducer>();

    public void AddAutoProducer(AutoProducer newProducer)
    {
        producers.Add(newProducer);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0f)
        {
            foreach(var p in producers)
            {
                p.Tick();
            }
            timer = 0.0f;
        }
    }
}
