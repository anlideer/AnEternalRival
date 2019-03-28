using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject shootingPoint;
    public float movingSpeed = 6f;
    public float jumpForce = 300f;
    public float cd = 1f;
    public Transform border;
    public Transform rightBorder;

    Quaternion enemyQ;
    float shootcd = 0.6f;
    float jumpcd = 2f;
    float timecnt1;
    float timecnt2;
    Animator anim;
    Rigidbody2D rigid;
    bool copying = false;
    int cntforTL = 0;
    int cntforSL = 0;
    bool direction = false;
    bool moving = false;
    float outoftime = 0f;
    bool returning = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyQ = transform.rotation;
        timecnt1 = Time.timeSinceLevelLoad;
        timecnt2 = Time.timeSinceLevelLoad + jumpcd;  //  delay jumping
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        cntforSL = cntforTL = 0;
        outoftime = 0f;
        moving = false;
        returning = false;
        if (CopyU.round == 0)
        {
            copying = false;
        }
        else
        {
            copying = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = enemyQ;
        if (!GM.isOver)
        {
            Debug.Log(outoftime);
            // AI action
            if (!copying)
            {
                // shoot
                if (Time.timeSinceLevelLoad > timecnt1 + shootcd)
                {
                    timecnt1 = Time.timeSinceLevelLoad;
                    shootingPoint.GetComponent<EnemyShoot>().Shoot();
                }
                // jump
                if (Time.timeSinceLevelLoad > timecnt2 + jumpcd)
                {
                    timecnt2 = Time.timeSinceLevelLoad;
                    Jump();
                }
            }
            // Copy action
            else
            {
                if (returning)
                {
                    if (Mathf.Abs(transform.position.x - 6.79f) > 0.5f)
                    {
                        if (transform.position.x < 6.79f)
                        {
                            direction = true;
                            moving = true;
                        }
                        else
                        {
                            direction = false;
                            moving = true;
                        }
                    }
                    else
                    {
                        returning = false;
                        outoftime = Time.timeSinceLevelLoad;
                        cntforSL = cntforTL = 0;
                    }
                }
                else
                {
                    if (Mathf.Abs(Time.timeSinceLevelLoad - CopyU.timeList[cntforTL] - outoftime) < 0.2f)
                    {
                        // take action
                        int flag = CopyU.actionList[cntforTL];
                        cntforTL++;
                        if (flag == 0)
                        {
                            Jump();
                        }
                        else if (flag == 1) // A down
                        {
                            moving = true;
                            direction = true;
                        }
                        else if (flag == -1)    // A up
                        {
                            moving = false;
                        }
                        else if (flag == 2) // D down
                        {
                            moving = true;
                            direction = false;
                        }
                        else if (flag == -2)    // D up
                        {
                            moving = false;
                        }
                        else if (flag == 3) // shoot
                        {
                            shootingPoint.GetComponent<EnemyShoot>().Shoot(CopyU.shootingList[cntforSL]);
                            cntforSL++;
                        }
                        else if (flag == 4) // throw
                        {
                            shootingPoint.GetComponent<EnemyShoot>().ThrowGrenade();
                        }

                        if (cntforTL >= CopyU.timeList.Count)
                        {
                            // return to the start place and act it again
                            returning = true;
                        }
                    }
                }

                if(moving)
                {
                    Move();
                }
            }
        }
    }


    void Jump()
    {
        anim.Play("EnemyJump");
        rigid.AddForce(jumpForce * transform.up);
    }

    void Move()   // false-left, true-right
    {
        Vector3 tmpv = transform.position;
        if (direction == false && tmpv.x > border.position.x)
        {
            tmpv.x -= movingSpeed * Time.deltaTime;
        }
        else if (direction == true && tmpv.x < rightBorder.position.x)
        {
            tmpv.x += movingSpeed * Time.deltaTime;
        }
        transform.position = tmpv;
    }

}
