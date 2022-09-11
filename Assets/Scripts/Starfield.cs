using UnityEngine;

public class Starfield : MonoBehaviour
{
	[SerializeField] private float scrollSpeed = 0.5f;

	private void Update()
	{
		Material mat = GetComponent<MeshRenderer>().material;
		Vector2 offset = mat.mainTextureOffset;
		offset.y += scrollSpeed * Time.deltaTime;
		mat.mainTextureOffset = offset;
	}
}
