using UnityEngine;
using UnityEngine.UI;

public class AsteroidHealthbar : MonoBehaviour
{
	[SerializeField] private Image fill;

	internal void LoseHealth(int damage)
	{
		fill.fillAmount -= (float)damage / GetComponentInParent<Asteroid>().maxHP;
	}
}
