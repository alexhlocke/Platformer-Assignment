using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float maxRunSpeed = 6f;
    public float jumpForce;

    public bool onGround;

    private Rigidbody rb;
    private Collider col;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        col = GetComponent<Collider>();
        onGround = Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
        //Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;*/
            if (onGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    void FixedUpdate()
    {
        /*transform.position += new Vector3(movementSpeed * Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);*/
        rb.AddForce(Vector3.right * Input.GetAxisRaw("Horizontal") * movementSpeed, ForceMode.Force);
        //transform.rotation = new Quaternion(0, Input.GetAxisRaw("Horizontal")*90, 0, 0);
        if (Mathf.Abs(rb.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed + Mathf.Sign(rb.velocity.x);
            //clamp velocity
        }


        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1f)
        {
            float newX = rb.velocity.x * 0.95f;
            rb.velocity = new Vector3(newX, rb.velocity.y, rb.velocity.x);
        }
    }
}
