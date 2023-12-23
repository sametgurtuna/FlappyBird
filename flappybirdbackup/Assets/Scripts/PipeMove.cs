using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 30f;

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
