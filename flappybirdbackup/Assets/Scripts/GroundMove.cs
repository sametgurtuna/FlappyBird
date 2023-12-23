using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float width = 5f;

    private SpriteRenderer sr;

    private Vector2 size;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        size = new Vector2(sr.size.x, sr.size.y);

    }

    private void Update()
    {
        sr.size = new Vector2(sr.size.x + moveSpeed *Time.deltaTime, size.y);

        if (sr.size.x > width)
            sr.size = size;
    }

}
