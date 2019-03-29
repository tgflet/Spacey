using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float max_X;
    public float min_X;
    private double new_Y;
    protected int PointValue;
    public bool dextrous;
    public Vector3 downward;
    public bool active;
    private SpriteRenderer enemy_SpriteRenderer;
    public float attack_Timer = 20f;
    public float current_Attack_Timer;
    public bool canAttack;
 
    public GameObject enemy_Shot;
    public Transform shotSpawn;

    // Start is called before the first frame update
    void Start()
    {
        dextrous = true;
        active = false;
        enemy_SpriteRenderer = GetComponent<SpriteRenderer>();
        enemy_SpriteRenderer.color = Color.white;
        PointValue = 30;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= -3.45)
        {
            GameOver.isFailure = true;
        }
        Attack();
        if (active)
        {
            enemy_SpriteRenderer.color = Color.cyan;
            Move();
        }

    }
    public virtual void MoveRight()
    {

        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
        if (temp.x > max_X)
        { 
            dextrous = false;
            transform.position += downward * Time.deltaTime;

        }
    }
    public virtual void MoveLeft()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
        if(temp.x < min_X)
        {
            dextrous = true;
            transform.position += downward * Time.deltaTime;
        }

    }
    public virtual void MoveDown()
    {
        Vector3 temp = transform.position;
        new_Y = temp.y-0.40;
        temp.y -= speed * Time.deltaTime;
        if (temp.y < new_Y)
        {
            temp.y = (float)new_Y;
        }
        transform.position = temp;

    }
    public virtual void Move()
    {
        if (dextrous)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(gameObject);
            Player.Score += PointValue;
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Base"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            GameOver.isFailure = true;
        }
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }
            if (canAttack)
            {
            int willAttack = Random.Range(0,500);
                canAttack = false;
                attack_Timer = 0f;
                if(willAttack == 3)
            {
                Instantiate(enemy_Shot, shotSpawn.position, Quaternion.identity);
            }
            

            }
        }
    }
