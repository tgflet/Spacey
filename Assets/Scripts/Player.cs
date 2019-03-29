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
    public static int Score;
    public Text scoreText;
    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    public int ShotCount;
    public int lives = 2;
    Vector2 origin;
    [SerializeField]
    private GameObject player_Shot;
    [SerializeField]
    private Transform shotSpawn;
    private SpriteRenderer player_SpriteRenderer;
    void Start()
    {
        Score = 0;
        ShotCount = 0;
        SetScoreText();
        current_Attack_Timer = attack_Timer;
        origin = new Vector2(0, -3.35f);
        player_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        SetScoreText();

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector2 movement = new Vector2(moveHorizontal,0);
        //rb2d.AddForce(movement * speed);

    }
    private void Update()
    {
        Attack();


        if (lives >= 2)
        {
            player_SpriteRenderer.color = Color.green;
        }
        if(lives == 1)
        {
            player_SpriteRenderer.color = Color.yellow;
        }
        if(lives == 0)
        {
            player_SpriteRenderer.color = Color.red;
        }
        if(Score >= 300)
        {
            lives += 1;
        }


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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet")){
            Destroy(other.gameObject);
            if(lives > 0)
            {
                lives -= 1;
                Time.timeScale = 0.01f;

                transform.position = origin;
                Time.timeScale = 1;
            }
            else
            {
                GameOver.isFailure = true;
            }

        }
    }
}
