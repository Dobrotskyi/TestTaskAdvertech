using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsAmtField;
    private int _points = 0;

    private void Awake()
    {
        _pointsAmtField.text = "0";
    }

    private void OnEnable()
    {
        Circle.CircleClicked += CircleClicked;
    }

    private void OnDisable()
    {
        Circle.CircleClicked -= CircleClicked;
    }

    private void CircleClicked()
    {
        _points++;
        _pointsAmtField.text = _points.ToString();
    }
}
