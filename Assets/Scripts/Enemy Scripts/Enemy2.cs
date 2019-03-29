using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    //public float speed;
    //public float max_X;
    //public float min_X;
    //private double new_Y;
    //protected int PointValue;
    //public bool dextrous;
    //public Vector3 downward;
    //public bool active;

    //public float attack_Timer = 20f
    private SpriteRenderer enemy_SpriteRenderer;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        int directionguide = Random.Range(0, 4);
        if (directionguide == 0)
        {
            direction = new Vector2(-0.5f,-0.5f);
        }
        if (directionguide == 1)
        {
            direction = new Vector2(0.5f, -0.5f);
        }
        if (directionguide == 2)
        {
            direction = new Vector2(-0.5f, -0.25f);
        }
        if (directionguide == 3)
        {
            direction = new Vector2(0.5f, -0.25f);
        }
        direction = direction.normalized * speed * Time.deltaTime;
        dextrous = true;
        active = false;
        enemy_SpriteRenderer = GetComponent<SpriteRenderer>();
        enemy_SpriteRenderer.color = Color.white;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Attack();
        if (active)
        {
            PointValue = 45;
            enemy_SpriteRenderer.color = Color.red;
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Move();
            //Ray ray = new Ray(transform.position, transform.forward);
            //RaycastHit hit;
            //if(Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
            //{
            //Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            //float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            //transform.eulerAngles = new Vector2(0, rot);
            Ray cast = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Physics.Raycast(cast, out hit);

            transform.position += transform.forward * speed * Time.deltaTime;

        }
        if (transform.position.y <= -3.45)
        {
            GameOver.isFailure = true;
        }

    }
    //public virtual void MoveRight()
    //{

    //    Vector3 temp = transform.position;
    //    temp.x += speed * Time.deltaTime;
    //    transform.position = temp;
    //    if (temp.x > max_X)
    //    {
    //        dextrous = false;
    //        transform.position += downward * Time.deltaTime;

    //    }
    //}
    //public virtual void MoveLeft()
    //{
    //    Vector3 temp = transform.position;
    //    temp.x -= speed * Time.deltaTime;
    //    transform.position = temp;
    //    if (temp.x < min_X)
    //    {
    //        dextrous = true;
    //        transform.position += downward * Time.deltaTime;
    //    }

    //}
    //public virtual void MoveDown()
    //{
    //    Vector3 temp = transform.position;
    //    new_Y = temp.y - 0.40;
    //    temp.y -= speed * Time.deltaTime;
    //    if (temp.y < new_Y)
    //    {
    //        temp.y = (float)new_Y;
    //    }
    //    transform.position = temp;

    //}
    //public virtual void Move()
    //{
    //    if (dextrous)
    //    {
    //        MoveRight();
    //    }
    //    else
    //    {
    //        MoveLeft();
    //    }
    //}
    public override void Move()
    {
        {
            transform.Translate(direction);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Left"))
        {
            direction.x = -direction.x;
        }
        if (other.tag =="Right")
        {
            direction.x = -direction.x;
    }
        if (other.transform.CompareTag("Enemy"))
        {
            direction.x = -direction.x;
        }
        if (other.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Player.Score += PointValue;
        }
        //i f (other.transform.CompareTag("Top"))
        //{
        //    Collision(other);
        //}
        //if (other.transform.CompareTag("Base"))
        //{
        //    Collision(other);
        //}
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
            int willAttack = Random.Range(0, 500);
            canAttack = false;
            attack_Timer = 0f;
            if (willAttack == 3)
            {
                Instantiate(enemy_Shot, shotSpawn.position, rotation:Quaternion.identity);
            }

            } 
        }


}
