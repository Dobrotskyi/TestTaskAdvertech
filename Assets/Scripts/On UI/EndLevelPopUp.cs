using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLevelPopUp : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    [SerializeField] private TextMeshProUGUI _amtField;

    private void Awake()
    {
        if (_body.activeSelf)
            _body.SetActive(false);
    }

    private void OnEnable()
    {
        Timer.RoundEnded += ShowEndLevelPopUp;
    }

    private void OnDisable()
    {
        Timer.RoundEnded -= ShowEndLevelPopUp;
    }

    private void ShowEndLevelPopUp()
    {
        _body.SetActive(true);
        _amtField.text = FindObjectOfType<PointsCounter>().Points.ToString();
    }
}
