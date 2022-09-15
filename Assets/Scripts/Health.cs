using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image[] hearts;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Player.lives)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
