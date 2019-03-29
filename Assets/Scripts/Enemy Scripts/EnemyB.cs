using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    private SpriteRenderer enemy_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        dextrous = true;
        active = false;
        enemy_SpriteRenderer = GetComponent<SpriteRenderer>();
        enemy_SpriteRenderer.color = Color.white;
        PointValue = 20;
    }

    // Update is called once per frame
    void Update()
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
                Instantiate(enemy_Shot, shotSpawn.position, rotation: Quaternion.identity);
            }

        }
    }

}
