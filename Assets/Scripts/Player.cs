using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float max_X;
    public float min_X;
    private int Score;
    public Text scoreText;
    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    public int ShotCount;
    [SerializeField]
    private GameObject player_Shot;
    [SerializeField]
    private Transform shotSpawn;
    void Start()
    {
        Score = 0;
        ShotCount = 0;
        SetScoreText();
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        Attack();
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector2 movement = new Vector2(moveHorizontal,0);
        //rb2d.AddForce(movement * speed);
       
    }
    void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            if (temp.x > max_X)
            {
                temp.x = max_X;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            if (temp.x < min_X)
            {
                temp.x = min_X;
            }
            transform.position = temp;
        }

    }
    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (canAttack)
            {
                canAttack = false;
                ShotCount += 1;
                attack_Timer = 0f;
                Instantiate(player_Shot, shotSpawn.position, Quaternion.identity);

            }
        }
    }
    void SetScoreText()
    {
        scoreText.text = Score.ToString();
    }
}
