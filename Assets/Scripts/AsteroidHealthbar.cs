using UnityEngine;
using UnityEngine.UI;

public class AsteroidHealthbar : MonoBehaviour
{
	[SerializeField] Image fill;

	private int maxHP;

	private void Awake()
	{
		maxHP = GetComponent<Asteroid>().hp;
	}

	public void LoseHealth(int damage)
	{
		fill.fillAmount -= (float)damage / maxHP;
	}
}
