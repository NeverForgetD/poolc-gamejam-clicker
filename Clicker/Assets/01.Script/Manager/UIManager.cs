using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heightText;


    /// <summary>
    /// mm ������ ulong ���� ������ ������ ��ȯ�Ͽ� ���ڿ��� ��ȯ�մϴ�.
    /// (�Ҽ��� 1�ڸ�����, ����: mm / cm / m / km)
    /// </summary>
    public static string FormatLengthAuto(ulong lengthInMm)
    {
        if (lengthInMm < 10UL) // 10mm �̸�
        {
            return $"{lengthInMm:F1} mm";
        }
        else if (lengthInMm < 1000UL) // 1cm ~ 99.9cm
        {
            double cm = lengthInMm / 10.0;
            return $"{cm:F1} cm";
        }
        else if (lengthInMm < 1_000_000UL) // 1m ~ 999.9m
        {
            double meters = lengthInMm / 1000.0;
            return $"{meters:F1} m";
        }
        else // 1km �̻�
        {
            double km = lengthInMm / 1_000_000.0;
            return $"{km:F1} km";
        }
    }

    private void Update()
    {
        heightText.text = $"���� :{FormatLengthAuto(HeightManager.Instance.height)}";

        
    }
}
