using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;
    private bool exploded = false;s

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        exploded = false;
        Invoke(nameof(DestroySelf), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke(); // 중복 타이머 방지
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void Launch(Vector2 force)
    {
        //rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
