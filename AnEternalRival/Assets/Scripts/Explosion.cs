using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public bool exploded = false;
    bool countedP = false;
    bool countedE = false;

    // Start is called before the first frame update
    void Start()
    {
        exploded = false;
        countedP = false;
        countedE = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (exploded && !countedP && collision.gameObject.tag == "Player")
            {
                countedP = true;
                GM.playerBlood -= 5;
            }
            if (exploded && !countedE && collision.gameObject.tag == "Enemy")
            {
                countedE = true;
                GM.enemyBlood -= 5;
            }
    }
}
