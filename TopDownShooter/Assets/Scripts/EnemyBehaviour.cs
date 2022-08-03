using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject player;
    float eSpeed;
    float eLife;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        switch (this.gameObject.tag)
        {
            case "Tank":
                eLife = 3;
                eSpeed = 2;
                break;
            case "Speedy":
                eLife = 1;
                eSpeed = 4;
                break;
            default:
                eLife = 1;
                eSpeed = 3;
                break;
        }

    }

    void Update()
    {
        FollowPlayer(player);
    }

    void FollowPlayer(GameObject target)
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * eSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            this.eLife--;

            if (this.eLife == 0)
            {
                Destroy(this.gameObject);
                PlayerBehaviour.instance.AddScore(10);
            }
            
            Destroy(other.gameObject);
        }
    }
}
