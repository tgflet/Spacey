﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Base"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
