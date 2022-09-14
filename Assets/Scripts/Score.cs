using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = $"Score: {Player.score}";
    }
}
