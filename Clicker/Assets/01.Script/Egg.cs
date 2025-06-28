using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Invoke(nameof(DestroySelf), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke(); // �ߺ� Ÿ�̸� ����
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
