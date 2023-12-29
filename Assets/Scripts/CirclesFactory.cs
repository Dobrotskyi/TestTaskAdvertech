using UnityEngine;
using UnityEngine.EventSystems;

public class CirclesFactory
{
    private const float MAX_SIZE_SCALE = 2;

    private Circle _cirlcePrefab;
    private RectTransform _playArea;

    public CirclesFactory(Circle cirlcePrefab, RectTransform playArea)
    {
        _cirlcePrefab = cirlcePrefab;
        _playArea = playArea;
    }

    public void SpawnCircle()
    {
        Circle circle = GameObject.Instantiate(_cirlcePrefab);
        circle.transform.SetParent(_playArea.transform, false);
        Vector2 newPosition = new Vector2(
                                Random.Range(-_playArea.rect.width / 2, _playArea.rect.width / 2),
                                Random.Range(-_playArea.rect.height / 2, _playArea.rect.height / 2)
                                );

        circle.GetComponent<RectTransform>().sizeDelta *= Random.Range(1, MAX_SIZE_SCALE);
        circle.transform.localPosition = newPosition;
    }
}
