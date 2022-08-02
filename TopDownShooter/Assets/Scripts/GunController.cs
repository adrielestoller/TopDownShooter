using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    SpriteRenderer gSprite;
    [SerializeField] GameObject bulletPrefab;

    void Start()
    {
        gSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Aim();
        Shoot();
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float aimAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
        
        gSprite.flipY = (mousePos.x < screenPoint.x);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

}
