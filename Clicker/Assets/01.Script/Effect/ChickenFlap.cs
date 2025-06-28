using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

/// <summary>
/// 클릭 시 닭이 파닥이는 애니메이션
/// </summary>
public class ChickenFlap : MonoBehaviour
{
    private RectTransform rt;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    public void Flap()
    {
        DG.Tweening.Sequence flapSeq = DOTween.Sequence();

        // 작아졌다가 커지는 Scale 연출
        flapSeq.Append(rt.DOScale(new Vector3(0.8f, 1.2f, 1), 0.1f))
               .Append(rt.DOScale(Vector3.one, 0.1f));
    }
}
