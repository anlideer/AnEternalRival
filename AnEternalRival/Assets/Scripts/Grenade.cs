using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    Animator anim;
    float timecnt;
    float cd = 0.3f;
    bool isExploding = false;
    public AudioSource ExplosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isExploding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isExploding && Time.timeSinceLevelLoad > cd + timecnt)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isExploding && collision.gameObject.tag != "Grenade")
        {
            // explode
            ExplosionAudio.Play();
            isExploding = true;
            anim.Play("GrenadeExplosion");
            GameObject ex = GameObject.Find(gameObject.name + "/ExplosionRange");
            ex.GetComponent<Explosion>().exploded = true;
            timecnt = Time.timeSinceLevelLoad;
        }
    }
}
