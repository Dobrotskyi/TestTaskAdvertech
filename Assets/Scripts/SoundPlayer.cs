using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _successAS;
    [SerializeField] private AudioSource _failedAS;

    private void OnEnable()
    {
        Circle.CircleClicked += CirclePressed;
    }

    private void OnDisable()
    {
        Circle.CircleClicked -= CirclePressed;
    }

    private void CirclePressed()
    {
        _successAS.Play();
    }
}
