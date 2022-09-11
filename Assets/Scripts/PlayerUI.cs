using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Player player;

    private Text livesText;

    private void Awake()
    {
        livesText = GetComponent<Text>();
    }

    private void Update()
    {
        int lifeCount = player.Lives;
        livesText.text = $"Lives: {lifeCount}";
    }
}
