using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private void Update()
    {
		GetComponent<Text>().text = $"Lives: {Player.lives}";
    }
}
