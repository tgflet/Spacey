using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Horde : MonoBehaviour
{
    private Transform Swarm;
    public float speed;
    public bool primed = true;
    public int trigger;
    // Start is called before the first frame update
    void Start()
    {
        Swarm = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Swarm.childCount <= trigger)
        {
            primed = false;
            foreach(Transform enemy in Swarm)
            {
                Enemy select = enemy.GetComponent<Enemy>();
                select.active = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (primed)
        {
            MoveEnemy();
            foreach(Transform enemy in Swarm)
            {

            }
        }
    }
    void MoveEnemy()
    {
        Swarm.position += Vector3.right * speed*Time.deltaTime;
        foreach(Transform enemy in Swarm)
        {
            if (enemy.position.x < -3.5 || enemy.position.x > 3.5)
            {
                speed = -speed;
                Swarm.position += Vector3.down * 0.2f;
                return;
            }
        }

    }
}
