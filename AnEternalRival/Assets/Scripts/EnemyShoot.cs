using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shootForce = 0.5f;
    public GameObject bullet;
    public GameObject Grenade;
    public float throwForce = 5f;
    public AudioSource ShootAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (GM.enemyBullet > 0)
        {
            // shoot
            ShootAudio.Play();
            GM.enemyBullet -= 1;
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(shootForce * transform.right * -1);
        }
    }
    public void Shoot(Vector2 des)
    {
        if (GM.enemyBullet > 0)
        {
            // shoot
            ShootAudio.Play();
            GM.enemyBullet -= 1;
            Vector2 dir = new Vector2(des.x - transform.position.x, des.y - transform.position.y);
            dir = dir.normalized;
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(shootForce * dir);
        }
    }

    public void ThrowGrenade()
    {
        if (GM.enemyGrenade > 0)
        {
            GM.enemyGrenade--;
            GameObject newGrenade = Instantiate(Grenade, transform.position, transform.rotation);
            Vector2 dir = new Vector2(transform.up.x - transform.right.x, transform.up.y - transform.right.y);
            dir = dir.normalized;
            newGrenade.GetComponent<Rigidbody2D>().AddForce(throwForce * dir);
        }
    }
}
