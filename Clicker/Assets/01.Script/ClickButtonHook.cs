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
        GameManager.Instance.AddEgg(valuePerTick);
    }
}
