using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int Damage = 250;

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
