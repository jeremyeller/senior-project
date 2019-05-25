using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
        if (velocity != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        playerRigidbody.MovePosition(transform.position + velocity * speed * Time.deltaTime);
    }
}
