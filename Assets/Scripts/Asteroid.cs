using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

	public int hp = 1000;

    private GameObject explosion;
    private Animator animator;
    private AsteroidHealthbar healthBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
		healthBar = GetComponent<AsteroidHealthbar>();
	}

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Destroyed"))
        {
            Destroy(explosion);
            Destroy(gameObject);
			GameWorld.asteroidCount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            OnAsteroidHit(collision);
		}
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().IsHit();
		}
    }

    private void OnAsteroidHit(Collider2D projectile)
    {
        Destroy(projectile.gameObject);

        int damage = projectile.GetComponent<Projectile>().Damage;
        hp -= damage;
		healthBar.LoseHealth(damage);

		if (hp <= 0)
		{
			explosion = Instantiate(explosionPrefab, transform);
			animator.SetTrigger("Destroy");
		}
    }
}
