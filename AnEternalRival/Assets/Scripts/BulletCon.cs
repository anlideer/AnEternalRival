using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GM.playerBlood -= 1;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            GM.enemyBlood -= 1;
        }
        Destroy(gameObject);
    }
}
