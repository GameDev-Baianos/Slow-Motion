using UnityEngine;

public class playerState : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public static bool alive = true;
    public logic logic2;

    void Start()
    {
        logic2 = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            alive = false;
            logic2.gameOver();
        }
    }
}
