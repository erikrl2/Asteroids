using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator thrustFire;

    public int Lives = 3;

    private Rigidbody2D rb;
    private Vector2 forwardDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = speed * forwardDir;
			thrustFire.SetBool("Boosting", true);
        }
        else
        {
            rb.velocity = Vector2.zero;
			thrustFire.SetBool("Boosting", false);
        }

        if (Lives == 0)
        {
            // TODO
        }

        CalculateForwardDir();
    }

    private void FixedUpdate()
    {
        rb.rotation += rotationSpeed * -Input.GetAxisRaw("Horizontal");
    }

    public Vector2 GetForwardDir()
    {
        return forwardDir;
    }

    private void CalculateForwardDir()
    {
        float angle = Mathf.Deg2Rad * (rb.rotation + 90f);
        forwardDir = new(Mathf.Cos(angle), Mathf.Sin(angle));
        forwardDir.Normalize();
    }

    public void IsHit()
    {
		Lives--;
        transform.position = Vector3.zero;
    }
}
