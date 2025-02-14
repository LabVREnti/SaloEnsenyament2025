using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
    }
}
