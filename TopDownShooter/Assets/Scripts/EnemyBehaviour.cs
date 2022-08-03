using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject player;
    float eSpeed;
    float eLife;
    int eScore;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        switch (this.gameObject.tag)
        {
            case "Tank":
                this.eLife = 3;
                this.eSpeed = 2;
                this.eScore = 7;
                break;
            case "Speedy":
                this.eLife = 1;
                this.eSpeed = 4;
                this.eScore = 5;
                break;
            default:
                this.eLife = 1;
                this.eSpeed = 3;
                this.eScore = 4;
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
                PlayerBehaviour.instance.AddScore(this.eScore);
            }
            
            Destroy(other.gameObject);
        }
    }
}
