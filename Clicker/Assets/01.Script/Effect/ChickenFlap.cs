using UnityEngine;
using DG.Tweening;

/// <summary>
/// SpriteRenderer 기반 닭 파닥 애니메이션
/// </summary>
public class ChickenFlap : MonoBehaviour
{
    private Transform t;

    void Awake()
    {
        t = GetComponent<Transform>();
    }

    /// <summary>
    /// 클릭 시 파닥거림 효과
    /// </summary>
    public void Flap()
    {
        Sequence flapSeq = DOTween.Sequence();

        // 작아졌다 커지는 Scale 연출
        flapSeq.Append(t.DOScale(new Vector3(0.8f, 1.2f, 1), 0.1f))
               .Append(t.DOScale(Vector3.one, 0.1f));
    }
}
