using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fly : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    private bool canFly = true;

    private Rigidbody2D rb;

    public AudioSource dieSound;

    public AudioSource wingSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canFly)
        {
            wingSound.Play();
            rb.velocity = Vector2.up * velocity;
        }
        
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 10);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        dieSound.Play();
        canFly = false;
        GameManagement.instance.GameOver();
    }
}
