using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float pSpeed = 5f;
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * pSpeed;
    }
}
