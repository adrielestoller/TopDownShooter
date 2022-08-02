using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float bSpeed = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }
}
