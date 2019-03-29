using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : Enemy
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
            int willAttack = Random.Range(0, 500);
            canAttack = false;
            attack_Timer = 0f;
            if (willAttack == 3)
            {
                Instantiate(enemy_Shot, shotSpawn.position, Quaternion.identity);
            }


        }
    }
}


