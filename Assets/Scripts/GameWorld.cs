using UnityEngine;

public class GameWorld : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private float asteroidSpawnTime = 5f;

    public static int asteroidCount;

	private void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1f, asteroidSpawnTime);
    }

    private void Update()
    {
    }

    private void SpawnAsteroid()
    {
        if (asteroidCount >= 5)
            return;

		int spawnPointX = Random.Range(-5, 5);
		int spawnPointY = Random.Range(-5, 5);
		Vector3 spawnPosition = new(spawnPointX, spawnPointY, 0);

		Instantiate(asteroid, spawnPosition, Quaternion.identity);

        asteroidCount++;
	}
}
