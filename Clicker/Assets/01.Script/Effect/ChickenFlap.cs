using UnityEngine;
using DG.Tweening;

/// <summary>
/// SpriteRenderer ��� �� �Ĵ� �ִϸ��̼�
/// </summary>
public class ChickenFlap : MonoBehaviour
{
    private Transform t;

    void Awake()
    {
        t = GetComponent<Transform>();
    }

    /// <summary>
    /// Ŭ�� �� �ĴڰŸ� ȿ��
    /// </summary>
    public void Flap()
    {
        Sequence flapSeq = DOTween.Sequence();

        // �۾����� Ŀ���� Scale ����
        flapSeq.Append(t.DOScale(new Vector3(0.8f, 1.2f, 1), 0.1f))
               .Append(t.DOScale(Vector3.one, 0.1f));
    }
}
