using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _successAS;
    [SerializeField] private AudioSource _failedAS;
    [SerializeField] private AudioClip _gameOverSound;

    private void OnEnable()
    {
        Circle.CircleClicked += CirclePressed;
        Circle.CircleMissed += CircleMissed;
        Timer.RoundEnded += GameOver;
    }

    private void OnDisable()
    {
        Circle.CircleClicked -= CirclePressed;
        Circle.CircleMissed -= CircleMissed;
        Timer.RoundEnded -= GameOver;
    }

    private void CirclePressed()
    {
        _successAS.Play();
    }

    private void CircleMissed()
    {
        _failedAS.Play();
    }

    private void GameOver()
    {
        _successAS.clip = _gameOverSound;
        _successAS.Play();
    }
}
