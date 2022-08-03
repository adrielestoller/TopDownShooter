using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float eSpeed = 3f;

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
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
