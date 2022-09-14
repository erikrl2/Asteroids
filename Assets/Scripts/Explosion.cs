using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Finished"))
            Destroy(gameObject);
    }
}
