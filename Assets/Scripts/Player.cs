using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator thrustFire;

    private Rigidbody2D rb;

	internal static int lives = 3;
	internal static int score = 0;

	internal static Vector2 forwardDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        CalculateForwardDir();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(speed * forwardDir);
			thrustFire.SetBool("Boosting", true);
        }
        else
        {
			thrustFire.SetBool("Boosting", false);
        }

        if (lives <= 0)
        {
			Time.timeScale = 0f;
            EndScreen.active = true;
        }
    }

    private void FixedUpdate()
    {
        rb.rotation += rotationSpeed * -Input.GetAxisRaw("Horizontal");
    }

    private void CalculateForwardDir()
    {
        float angle = Mathf.Deg2Rad * (rb.rotation + 90f);
        Player.forwardDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

	internal void IsHit()
    {
		lives--;
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
		GetComponent<Collider2D>().enabled = false;
		for (int i = 0; i < 3; i++)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.2f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.2f);
        }
		GetComponent<Collider2D>().enabled = true;
    }
}
