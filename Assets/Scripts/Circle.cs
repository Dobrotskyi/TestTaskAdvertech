using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    [SerializeField] private Vector2 _minMaxTimeOfLife = new Vector2(3, 5);
    [SerializeField] private Image _innerImage;
    [SerializeField] private ParticleSystem _destroyEffect;
    private float _timeOfLife = 0;

    private void OnEnable()
    {
        _innerImage.color = Random.ColorHSV();
        _timeOfLife = Random.Range(_minMaxTimeOfLife.x, _minMaxTimeOfLife.y);
        StartCoroutine(InAndOut());
    }

    private IEnumerator InAndOut()
    {
        float t = 0;
        RectTransform rectTrns = GetComponent<RectTransform>();
        Vector2 startSize = rectTrns.sizeDelta;
        rectTrns.sizeDelta = Vector2.zero;
        float lerpTime = _timeOfLife / 2;

        while (t < lerpTime)
        {
            rectTrns.sizeDelta = Vector2.Lerp(Vector2.zero, startSize, t / lerpTime);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        rectTrns.sizeDelta = startSize;

        t = 0;
        while (t < lerpTime)
        {
            rectTrns.sizeDelta = Vector2.Lerp(startSize, Vector2.zero, t / lerpTime);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
