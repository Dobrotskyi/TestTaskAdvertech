using UnityEngine;

public class CirclesFactory : MonoBehaviour
{
    private const float MAX_SIZE_SCALE = 2;

    public bool Spawn;

    [SerializeField] private Circle _cirlcePrefab;
    [SerializeField] private RectTransform _playArea;

    public void SpawnCircle()
    {
        Circle circle = Instantiate(_cirlcePrefab);
        circle.transform.SetParent(_playArea.transform, false);
        Vector2 newPosition = new Vector2(
                                Random.Range(-_playArea.rect.width / 2, _playArea.rect.width / 2),
                                Random.Range(-_playArea.rect.height / 2, _playArea.rect.height / 2)
                                );

        circle.GetComponent<RectTransform>().sizeDelta *= Random.Range(1, MAX_SIZE_SCALE);
        circle.transform.localPosition = newPosition;
        Debug.Log(Camera.main.ScreenToWorldPoint(circle.transform.position));
    }

    private void Update()
    {
        if (Spawn)
        {
            SpawnCircle();
            Spawn = false;
        }
    }
}
