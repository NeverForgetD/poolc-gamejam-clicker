using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

/// <summary>
/// Ŭ�� �� ���� �Ĵ��̴� �ִϸ��̼�
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

        // �۾����ٰ� Ŀ���� Scale ����
        flapSeq.Append(rt.DOScale(new Vector3(0.8f, 1.2f, 1), 0.1f))
               .Append(rt.DOScale(Vector3.one, 0.1f));
    }
}
