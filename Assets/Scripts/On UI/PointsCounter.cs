using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsAmtField;
    private Animator _animator;
    public int Points { private set; get; } = 0;

    private void Awake()
    {
        _pointsAmtField.text = "0";
        _animator = GetComponent<Animator>();
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
        Points++;
        _pointsAmtField.text = Points.ToString();
        _animator.SetTrigger("PlusOne");
    }
}
