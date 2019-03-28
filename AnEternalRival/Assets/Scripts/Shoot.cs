using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float cd = 0.4f;
    public GameObject Bullet;
    public float shootForce = 0.5f;
    public GameObject Grenade;
    public float throwForce = 5f;
    public AudioSource ShootAudio;

    float timecnt;

    // Start is called before the first frame update
    void Start()
    {
        timecnt = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GM.playerBullet > 0 && Time.timeSinceLevelLoad > cd + timecnt)
            {
                Vector3 mousePos = Input.mousePosition;
                timecnt = Time.timeSinceLevelLoad;
                // shoot
                ShootAudio.Play();
                GM.playerBullet -= 1;
                GameObject newBullet = Instantiate(Bullet, transform.position, transform.rotation);
                Vector2 dir;
                Vector3 tmp = Camera.main.ScreenToWorldPoint(mousePos);
                dir = new Vector2(tmp.x - transform.position.x, tmp.y - transform.position.y);
                dir = dir.normalized;
                newBullet.GetComponent<Rigidbody2D>().AddForce(shootForce * dir);

                // record
                Player.timeList.Add(Time.timeSinceLevelLoad);
                Player.actionList.Add(3);
                Vector2 tmpr = new Vector2(-1 * tmp.x, tmp.y);
                Player.shootingList.Add(tmpr);
            }
        }
    }

    public void ThrowGrenade()
    {
        if (GM.playerGrenade > 0)
        {
            GM.playerGrenade--;
            GameObject newGrenade = Instantiate(Grenade, transform.position, transform.rotation);
            Vector2 dir = new Vector2(transform.up.x + transform.right.x, transform.up.y + transform.right.y);
            dir = dir.normalized;
            newGrenade.GetComponent<Rigidbody2D>().AddForce(throwForce * dir);
        }
    }
}
