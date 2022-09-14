using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameHandler gameHandler;

    internal static bool active = false;

    private void Update()
    {
        if (!active)
            return;

        GetComponent<Text>().text = "Game Over";

        if (Input.anyKeyDown)
        {
			gameHandler.NewGame();

            Time.timeScale = 1f;
            GetComponent<Text>().text = string.Empty;
            active = false;
        }
    }
}
