using UnityEngine;
using UnityEngine.UI;

public class Uptime : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = string.Format("{0:f2}s", GameHandler.time);
    }
}
