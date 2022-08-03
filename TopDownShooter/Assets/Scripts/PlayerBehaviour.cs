using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    int life = 3;
    [SerializeField] float pSpeed = 5f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * pSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            life--;
            Debug.Log("Life: " + life);

            if (life == 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Game Over...");
                // Game Over   
            }
        }
    }
}
