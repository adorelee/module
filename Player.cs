using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     [SerializeField] Rigidbody2D rb;
    [SerializeField] public float jumpForce = 5.0f;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    [SerializeField] Animator anim;
    bool jump;
    float lastYPos;
    // Start is called before the first frame update
    void Start()
    {
       lastYPos = transform.position.y; 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        if(transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }

        lastYPos = transform.position.y;
        
    }
    void FixedUpdate()
    {
        CheckForGrounded();
        if(jump == true)
        {
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            jump = false;
        }
    }
    void CheckForInput()
    {
        if(isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Here!");
                jump = true;   
                anim.SetTrigger("Jump");
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
        
    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);
       
        if (hit.collider != null)
        {
                if (hit.distance < 0.1f)
                {
                    isGrounded = true;
                    anim.SetBool("IsGrounded", true);
                    Debug.Log(isGrounded);
                } 
                else
                {
                        isGrounded = false;
                        anim.SetBool("IsGrounded",false);
                }
            Debug.DrawRay(raycastOrigin.position, Vector2.down,Color.green);
        }
    }
}
