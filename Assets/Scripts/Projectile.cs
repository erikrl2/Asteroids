using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage = 250;

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
