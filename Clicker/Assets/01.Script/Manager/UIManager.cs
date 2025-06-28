using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heightText;


    /// <summary>
    /// mm 단위의 ulong 값을 적절한 단위로 변환하여 문자열로 반환합니다.
    /// (소숫점 1자리까지, 단위: mm / cm / m / km)
    /// </summary>
    public static string FormatLengthAuto(ulong lengthInMm)
    {
        if (lengthInMm < 10UL) // 10mm 미만
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
        else // 1km 이상
        {
            double km = lengthInMm / 1_000_000.0;
            return $"{km:F1} km";
        }
    }

    private void Update()
    {
        heightText.text = $"높이 :{FormatLengthAuto(HeightManager.Instance.height)}";

        
    }
}
