using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int Hp = 100;
    [SerializeField]
    [Tooltip("이동속도")]
    private float MoveSpeed = 5f;
    [SerializeField]
    [Tooltip("점프력")]
    private float JumpPower = 5f;
    public bool isJumping = false;

    public SpriteRenderer SpriteRenderer;
    Animator animator;
    Rigidbody2D rigid;

    public Slider Hpslider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        // FindObjectOfType<Game_Manager>();
    }

    void Update()
    {

        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1.5f, LayerMask.GetMask("Platform"));

        if (Input.GetButtonDown("Jump") && rayHit.collider != null)
        {
            isJumping = true;
        }


    }
    void FixedUpdate()
    {
        Move();
        Jump();
        Dead();

        //점프 애니메이션
        if (rigid.velocity.y >= 0.1f)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //왼쪽오른쪽
        if(Input.GetButton("Horizontal"))
        {
            SpriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        /*
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Shoot", true);
        }
        else
        {
            animator.SetBool("Shoot", false);
        }
        */
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;

            animator.SetBool("Run", true);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;

            animator.SetBool("Run", true);
        }
        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            return;
        }
        
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelcity = new Vector2(0, JumpPower);
        rigid.AddForce(jumpVelcity, ForceMode2D.Impulse);

        

        isJumping = false;
    }

    private void Dead()
    {
        if (Hp <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

}
