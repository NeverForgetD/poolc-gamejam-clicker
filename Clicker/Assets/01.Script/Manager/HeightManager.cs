using UnityEngine;

public class HeightManager : MonoBehaviour
{
    public static HeightManager Instance { get; private set; }
    /// <summary>
    /// 0 ~ 18,446,744,073,709,551,615
    /// </summary>
    public ulong height { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    public void AddHeight(ulong amount)
    {
        height += amount;

        Debug.Log($"현재 누적 : {height}");
    }
}
