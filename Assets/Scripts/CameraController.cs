using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform playerTransform;

	private void Update()
	{
		Vector3 pos = playerTransform.position;
		pos.z = transform.position.z;
		transform.position = pos;
	}
}
