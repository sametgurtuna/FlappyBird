using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fly : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canFly = true;
    private bool hasShield = false;

    [SerializeField] private float velocity = 5f;
    [SerializeField] private AudioSource shieldBreak;

    public int reviveCount = 1;
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
        reviveCount--;
        if (hasShield)
        {
            hasShield = false;
            shieldBreak.Play();
            Debug.Log("Shield is broken");
        }
        else if(!hasShield && reviveCount<1)
        {
            dieSound.Play();
            canFly = false;
            GameManagement.instance.GameOver();
        }
    }

    public void ActivateShield()
    {
        hasShield = true;
    }

    public void DeactivateShield()
    {
        hasShield = false;
    }

}
