using UnityEngine;

public class ClickButtonHook : MonoBehaviour, IHoverDescribable
{
    private ulong valuePerTick;

    public ClickButtonHook()
    {
        valuePerTick = 1;
    }

    public void OnClick()
    {
        HeightManager.Instance.AddHeight(valuePerTick);
    }
    public string GetHoverDescription()
    {
        return "그저 닭이다";
    }
}
