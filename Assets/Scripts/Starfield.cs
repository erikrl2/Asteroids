using UnityEngine;

public class Starfield : MonoBehaviour
{
	[SerializeField] private int parallax = 2;
	[SerializeField] private bool rotated;

	private void Update()
	{
		Material mat = GetComponent<MeshRenderer>().material;
		Vector2 offset = mat.mainTextureOffset;

		offset.x = transform.position.x / transform.localScale.x / parallax;
		offset.y = transform.position.y / transform.localScale.y / parallax;

		mat.mainTextureOffset = rotated ? -offset : offset;
	}
}
