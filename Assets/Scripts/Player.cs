using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] public float rayPos = 0.76f;
    [SerializeField] public float rayLength = 0.3f;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * speed , rb.velocity.y);
        float pos = transform.position.magnitude;
        // Debug.Log(pos);

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.velocity = Vector2.up * jumpForce;
        }

        RaycastHit2D groundHit = Physics2D.Raycast(transform.position - new Vector3(0.0f, rayPos, 0.0f), Vector2.down, rayLength);
        Debug.DrawRay(transform.position- new Vector3(0.0f, rayPos, 0.0f), Vector2.down *rayLength, Color.red);

        if(groundHit.collider != null){
            Debug.Log("Hitting: " + groundHit.collider.name);
            Debug.DrawRay(transform.position- new Vector3(0.0f, rayPos, 0.0f), Vector2.down *rayLength, Color.green);
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }
    }
}
