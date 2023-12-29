using System.Collections;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 0.8f;
    [SerializeField] private Circle _circlePrefab;
    [SerializeField] private RectTransform _playArea;

    private CirclesFactory _circlesFactory;

    private void Awake()
    {
        _circlesFactory = new(_circlePrefab, _playArea);
    }

    private void OnEnable()
    {
        Timer.RoundStarted += StartSpawning;
        Timer.RoundEnded += StopAllCoroutines;
    }

    private void OnDisable()
    {
        Timer.RoundStarted -= StartSpawning;
        Timer.RoundEnded -= StopAllCoroutines;
    }

    private void StartSpawning()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            _circlesFactory.SpawnCircle();
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
