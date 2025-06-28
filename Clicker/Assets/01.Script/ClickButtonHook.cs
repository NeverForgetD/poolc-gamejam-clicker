using UnityEngine;

public class ClickButtonHook : MonoBehaviour
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
}
