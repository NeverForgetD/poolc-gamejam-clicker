using UnityEngine;
using DG.Tweening;

public class PopcornEffect : MonoBehaviour
{
    public GameObject ballPrefab; // �ϳ��� �� ������
    public Sprite[] ballSprites;  // �� �̹��� �迭

    //[Header("Ball Count Range")]
    //public int minBallCount = 2;   // �ּ� �� ���� (Inspector���� ����)
    //public int maxBallCount = 6;  // �ִ� �� ���� (Inspector���� ����)

    public float explosionForce = 15f;  // ���߷� (Inspector���� ����)
    public float animationDuration = 1.5f; // �ִϸ��̼� ���� �ð�
    public float fadeDuration = 0.5f;  // ���̵� �ƿ� �ð�

    public void OnClick()
    {
        GameManager.Instance.OnClick();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ���콺 Ŭ�� ����
        {
            OnClick();

            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;  // 2D ȯ�濡���� Z���� 0���� ����

            CreateExplosion(clickPosition);
        }
    }

    public void CreateExplosion(Vector3 position)
    {
        SoundManager.Instance.PlaySFX("Bloop");
        // Inspector���� ������ ���� ������ ������ �� ���� ����
        //int ballCount = Random.Range(minBallCount, maxBallCount + 1);
        int ballCount = Mathf.Min((int)(GameManager.Instance.clickBonus) + 1, 10);

        for (int i = 0; i < ballCount; i++)
        {
            // �� ������Ʈ ����
            GameObject ball = Instantiate(ballPrefab, position, Quaternion.identity);
            SpriteRenderer spriteRenderer = ball.GetComponent<SpriteRenderer>();

            // ���� ��������Ʈ ����
            int randomIndex = Random.Range(0, ballSprites.Length);
            spriteRenderer.sprite = ballSprites[randomIndex];

            // Rigidbody2D �߰� �� force ����
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb == null)
                rb = ball.AddComponent<Rigidbody2D>();

            // Collider2D ��Ȱ��ȭ �� ���� �ð� �� Ȱ��ȭ
            Collider2D col = ball.GetComponent<Collider2D>();
            if (col == null)
                col = ball.AddComponent<CircleCollider2D>();  // ���ϴ� Collider ���� ����
            col.enabled = false;  // ���� �� �浹 ��Ȱ��ȭ

            DOVirtual.DelayedCall(0.4f, () =>
            {
                col.enabled = true;  // n�� �� �浹 Ȱ��ȭ
            });


            // ���� �������� force ���� (Inspector�� explosionForce �� ���)
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.AddForce(randomDirection * explosionForce, ForceMode2D.Impulse);

            // ���� ���� �� ����
            spriteRenderer.DOFade(0, fadeDuration)
                .SetDelay(animationDuration)
                .OnComplete(() => Destroy(ball));
        }
    }
}