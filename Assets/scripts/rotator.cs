using UnityEngine;

public class rotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime, Space.Self);
    }
}
