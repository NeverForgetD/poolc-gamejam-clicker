using UnityEngine;

public class HeightManager : MonoBehaviour
{
    public static HeightManager Instance { get; private set; }

    /// <summary>
    /// 0 ~ 18,446,744,073,709,551,615
    /// </summary>
    public ulong height { get; set; }
    public ulong egg { get; set; }
    private ulong nextEggThreshold = 1000;
    private ulong eggThresholdStep = 1000;

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

        while (height >= nextEggThreshold)
        {
            AddEgg(1);
            nextEggThreshold += eggThresholdStep;
        }
    }

    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private Transform chickenPosition; // 발사 위치 (치킨 아래)
    [SerializeField] private float shootForce = 5f;
    [SerializeField] private float spreadAngle = 20f; // ± 퍼짐 각도

    public void AddEgg(ulong amount)
    {
        egg += amount;
        ShootEgg();
    }
    public void ShootEgg()
    {
        GameObject eggObj = Instantiate(eggPrefab, chickenPosition.position, Quaternion.identity);

        Rigidbody2D rb = eggObj.GetComponent<Rigidbody2D>();

        // 기본 방향은 아래 (Vector2.down)
        float angle = Random.Range(-spreadAngle, spreadAngle);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

        rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
    }
}
