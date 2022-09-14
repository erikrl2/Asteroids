using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    public int maxHP = 1000;

    private int hp;

	internal static float speed = 1.5f;

    private Animator animator;
    private AsteroidHealthbar healthBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
		healthBar = GetComponent<AsteroidHealthbar>();

        if (Random.value < .5f)
        {
            maxHP /= 2;
            Vector2 scale = transform.localScale;
            Vector3 halfScale = new(scale.x / 2f, scale.y / 2f, 1f);
            transform.localScale = halfScale;
		}
        hp = maxHP;
	}

    private void Start()
    {
        StartCoroutine(FollowPlayer());
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Destroyed"))
        {
            Destroy(gameObject);
            Player.score++;
		}

        Camera cam = Camera.main;
		Vector2 target = cam.transform.position;
		float distToPlayerSqr = (target - (Vector2)transform.position).sqrMagnitude;
        float halfCamWidth = cam.orthographicSize * cam.aspect;
        if (distToPlayerSqr > halfCamWidth * halfCamWidth * 3f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            OnAsteroidHit(collision);
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
			collision.collider.GetComponent<Player>().IsHit();
            if (Player.lives > 0)
				Instantiate(explosionPrefab, collision.transform);
		}
    }

    private void OnDestroy()
    {
		GameHandler.asteroidCount--;
    }

    private void OnAsteroidHit(Collider2D projectile)
    {
        Destroy(projectile.gameObject);

        int damage = projectile.GetComponent<Projectile>().damage;
        hp -= damage;
		healthBar.LoseHealth(damage);

		if (hp <= 0)
		{
			Instantiate(explosionPrefab, transform);
			animator.SetTrigger("Destroy");
		}
    }

    private IEnumerator FollowPlayer()
    {
        while (true)
        {
            Vector2 target = Camera.main.transform.position;
            Vector2 dir = target - (Vector2)transform.position;
            GetComponent<Rigidbody2D>().velocity = speed * dir.normalized;

            yield return new WaitForSeconds(.5f);
        }
    }
}
