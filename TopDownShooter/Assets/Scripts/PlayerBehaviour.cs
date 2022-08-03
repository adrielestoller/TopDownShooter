using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;

    public int life = 3;
    public int score = 0;
    [SerializeField] float pSpeed = 5f;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        life = 3;
        score = 0;
    }

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
    
    public void AddScore(int points)
    {
        score += points;
        UIManager.instance.UpdateStats();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            life--;
            UIManager.instance.UpdateStats();

            if (life == 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Game Over...");
                // Game Over   
            }
        }
    }
}
