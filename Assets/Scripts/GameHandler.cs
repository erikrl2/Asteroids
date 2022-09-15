using System.Collections;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	[SerializeField] private GameObject asteroid;
	[SerializeField] private Transform player;
	[SerializeField] private float difficultyIncreaseInterval = 5f;
	[SerializeField] private int maxAsteroidCount = 5;

	internal static float asteroidSpawnInterval = 3f;
	internal static int asteroidCount;
	internal static float time;
	internal static float gameStartTime;

	private IEnumerator Start()
	{
		InvokeRepeating(nameof(IncreaseDifficulty), 10f, difficultyIncreaseInterval);

		while (true)
		{
			yield return new WaitForSeconds(asteroidSpawnInterval);
			SpawnAsteroid();
		}	

	}

	private void Update()
	{
		time = Time.time - gameStartTime;
	}

	private void SpawnAsteroid()
	{
		if (asteroidCount >= maxAsteroidCount)
			return;

		float h = Camera.main.orthographicSize;
		float w = h * Camera.main.aspect;
		float r = Mathf.Sqrt(h * h + w * w) + 1f;
		Vector2 f = Player.forwardDir;
		Vector2 q = (Vector2)player.position + f * r;
		Vector2 s = new(-f.y, f.x);
		Vector2 spawnPoint = q + (Random.value * 2f - 1f) * h * s;

		Instantiate(asteroid, spawnPoint, Quaternion.identity);

		asteroidCount++;
	}

	private void IncreaseDifficulty()
	{
		Asteroid.speed = Mathf.Min(Asteroid.speed += .1f, 2f);
		asteroidSpawnInterval = Mathf.Max(asteroidSpawnInterval -= .5f, 1f);
		maxAsteroidCount++;
	}

	internal void NewGame()
	{
		asteroidSpawnInterval = 3f;
		gameStartTime = Time.time;
		time = 0f;

		Player.lives = 3;
		Player.score = 0;
		player.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		foreach (Asteroid asteroid in (Asteroid[])FindObjectsOfType(typeof(Asteroid)))
			Destroy(asteroid.gameObject);

		GetComponent<AudioSource>().Play();
	}
}
