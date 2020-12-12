using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;

    Vector2 direction = Vector2.zero;
    Vector2 prevDirection = Vector2.zero;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        UpdateWalkAnimation();
        transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);
        prevDirection = direction;
    }

    void UpdateWalkAnimation()
    {
        if (direction.x > 0)
            animator.Play("WalkRight");
        else if (direction.x < 0)
            animator.Play("WalkLeft");
        else if (direction.y > 0)
            animator.Play("WalkUp");
        else if (direction.y < 0)
            animator.Play("WalkDown");
        else
        {
            if (prevDirection.x > 0)
                animator.Play("IdleRight");
            else if (prevDirection.x < 0)
                animator.Play("IdleLeft");
            else if (prevDirection.y > 0)
                animator.Play("IdleUp");
            else if (prevDirection.y < 0)
                animator.Play("IdleDown");
        }
    }
}
