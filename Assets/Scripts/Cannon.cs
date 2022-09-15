using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	[SerializeField] private Rigidbody2D projectile;
	[SerializeField] private float bulletSpeed = 10;
	[SerializeField] private float fireRate = 5f;

	private bool allowFire = true;

	private void Update()
    {
		if (Input.GetKey(KeyCode.Space) && allowFire)
		{
			StartCoroutine(Fire());
		}
	}

	private IEnumerator Fire()
	{
		allowFire = false;

		GetComponent<Animator>().Play("Fire");
		GetComponent<AudioSource>().Play();

		Rigidbody2D bullet = Instantiate(projectile, transform.position, transform.rotation);
		float playerSpeed = GetComponentInParent<Rigidbody2D>().velocity.magnitude;
		bullet.velocity = (playerSpeed + bulletSpeed) * Player.forwardDir;

		yield return new WaitForSeconds(1f / fireRate);

		allowFire = true;
	}
}
