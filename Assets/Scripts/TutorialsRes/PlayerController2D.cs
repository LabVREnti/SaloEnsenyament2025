using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
            moveX = -1f;

        if (Input.GetKey(KeyCode.D))
            moveX = 1f;

        Vector3 movement = new Vector3(moveX, 0, 0).normalized;

        transform.position = transform.position + (movement * moveSpeed) * Time.deltaTime;
    }
}
