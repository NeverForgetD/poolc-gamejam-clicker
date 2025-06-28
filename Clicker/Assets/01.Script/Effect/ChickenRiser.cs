using UnityEngine;

/// <summary>
/// 클릭할 때마다 닭이 천천히 위로 올라가고, 다 올라가면 다시 밑에서 시작
/// </summary>
public class ChickenRiser : MonoBehaviour
{
    [SerializeField] private float moveAmount = 0.005f; // 클릭 시 올라갈 거리
    [SerializeField] private float moveSpeed = 0.4f;   // 올라가는 속도
    [SerializeField] private float topY = 10f;          // 최고 위치 Y
    [SerializeField] private float bottomY = -10f;      // 시작 위치 Y
    private float initialY = -9f;

    private Vector3 targetPos;

    void Start()
    {
        // 초기 위치를 bottomY로 세팅
        Vector3 pos = transform.position;
        pos.y = initialY;
        transform.position = pos;
        targetPos = pos;
    }

    void Update()
    {
        // 천천히 targetPos로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // 만약 닭이 화면 위로 다 올라가면 다시 아래로
        if (transform.position.y >= topY)
        {
            ResetToBottom();
        }

        // 클릭 체크 (마우스 기준)
        if (Input.GetMouseButtonDown(0))
        {
            IncreaseTargetPosition();
        }
    }

    void IncreaseTargetPosition()
    {
        // 목표 위치를 위로 moveAmount만큼 증가
        targetPos.y += moveAmount;
        targetPos.y = Mathf.Min(targetPos.y, topY); // 넘치지 않게
    }

    void ResetToBottom()
    {
        targetPos.y = bottomY;
        Vector3 pos = transform.position;
        pos.y = bottomY;
        transform.position = pos;
    }
}
