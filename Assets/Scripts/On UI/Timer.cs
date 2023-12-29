using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static event Action RoundStarted;
    public static event Action RoundEnded;

    [SerializeField] private TextMeshProUGUI _timerField;
    [SerializeField] private float _freezeTime = 3f;
    [SerializeField] private float _roundTime = 15f;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(LaunchTimer());
    }

    private IEnumerator LaunchTimer()
    {
        yield return StartCountdown(_freezeTime);
        _animator.SetBool("FreezeTime", false);
        RoundStarted?.Invoke();
        yield return StartCountdown(_roundTime);
        RoundEnded?.Invoke();
    }

    private IEnumerator StartCountdown(float countdownSeconds)
    {
        float passedSeconds = countdownSeconds;
        while (passedSeconds > 0)
        {
            _timerField.text = passedSeconds.ToString();
            yield return new WaitForSeconds(1);
            passedSeconds--;
        }

        _timerField.text = "0";
    }
}
