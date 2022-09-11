using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private float asteroidSpawnRate = 3f;

    public static int asteroidCount;

	private void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1f, asteroidSpawnRate);
    }

    private void SpawnAsteroid()
    {
        if (asteroidCount >= 5)
            return;

        Vector2 asteroidSize = asteroid.GetComponent<SpriteRenderer>().size;
        float spriteWidth = Camera.main.WorldToScreenPoint(new(asteroidSize.x, 0f, 0f)).x - Camera.main.WorldToScreenPoint(Vector3.zero).x;
		Vector3 spawnPoint = Camera.main.ScreenToWorldPoint(new(Random.value * (Screen.width - spriteWidth), Screen.height, 0f));
        spawnPoint = new(spawnPoint.x + asteroidSize.x / 2f, spawnPoint.y + asteroidSize.y / 2f, 0f);
		Instantiate(asteroid, spawnPoint, Quaternion.identity);

        asteroidCount++;
	}
}
