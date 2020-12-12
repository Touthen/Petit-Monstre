using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;

    Vector2 direction = Vector2.zero;

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
    }
}
