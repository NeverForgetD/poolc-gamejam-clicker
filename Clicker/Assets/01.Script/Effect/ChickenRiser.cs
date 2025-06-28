using UnityEngine;

/// <summary>
/// Ŭ���� ������ ���� õõ�� ���� �ö󰡰�, �� �ö󰡸� �ٽ� �ؿ��� ����
/// </summary>
public class ChickenRiser : MonoBehaviour
{
    [SerializeField] private float moveAmount = 0.1f; // Ŭ�� �� �ö� �Ÿ�
    [SerializeField] private float moveSpeed = 0.1f;   // �ö󰡴� �ӵ�
    [SerializeField] private float topY = 9f;          // �ְ� ��ġ Y
    [SerializeField] private float bottomY = -8f;      // ���� ��ġ Y
    private float initialY = -8f;

    private Vector3 targetPos;

    void Start()
    {
        // �ʱ� ��ġ�� bottomY�� ����
        Vector3 pos = transform.position;
        pos.y = initialY;
        transform.position = pos;
        targetPos = pos;
    }

    void Update()
    {
        // õõ�� targetPos�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // ���� ���� ȭ�� ���� �� �ö󰡸� �ٽ� �Ʒ���
        if (transform.position.y >= topY)
        {
            ResetToBottom();
            moveAmount += 1;
            moveSpeed += 1;

        }

        // Ŭ�� üũ (���콺 ����)
        if (Input.GetMouseButtonDown(0))
        {
            IncreaseTargetPosition();
        }
    }

    void IncreaseTargetPosition()
    {
        // ��ǥ ��ġ�� ���� moveAmount��ŭ ����
        targetPos.y += moveAmount;
        targetPos.y = Mathf.Min(targetPos.y, topY); // ��ġ�� �ʰ�
    }

    void ResetToBottom()
    {
        targetPos.y = bottomY;
        Vector3 pos = transform.position;
        pos.y = bottomY;
        transform.position = pos;
        Blink();
    }

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float visibleDuration = 1f;

    public void Blink()
    {
        StartCoroutine(BlinkRoutine());
    }

    private System.Collections.IEnumerator BlinkRoutine()
    {
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(visibleDuration);
        spriteRenderer.enabled = false;
    }
}
