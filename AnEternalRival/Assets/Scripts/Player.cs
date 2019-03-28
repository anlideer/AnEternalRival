using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movingSpeed = 6f;
    public float jumpForce = 300f;
    public Transform border;
    public Transform leftBorder;
    public float cd = 1f;
    public GameObject shootingPoint;


    Animator anim;
    bool moving = false;
    bool direction = false;
    float playerY;
    Rigidbody2D rigid;
    float timecnt;
    Quaternion playerQ;
    float timecnt2;

    // record
    public static List<float> timeList;
    public static List<int> actionList;
    public static List<Vector2> shootingList;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        moving = false;
        playerY = transform.position.y;
        timecnt = timecnt2 = Time.timeSinceLevelLoad;
        playerQ = transform.rotation;
        timeList = new List<float>();
        actionList = new List<int>();
        shootingList = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = playerQ;
        if (!GM.isOver)
        {
            // Get Input
            if (Input.GetKeyDown(KeyCode.A))
            {
                moving = true;
                direction = false;
                timeList.Add(Time.timeSinceLevelLoad);
                actionList.Add(1);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                moving = false;
                timeList.Add(Time.timeSinceLevelLoad);
                actionList.Add(-1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                moving = true;
                direction = true;
                timeList.Add(Time.timeSinceLevelLoad);
                actionList.Add(2);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                moving = false;
                timeList.Add(Time.timeSinceLevelLoad);
                actionList.Add(-2);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (Time.timeSinceLevelLoad > cd + timecnt)
                {
                    anim.Play("PlayerJump");
                    rigid.AddForce(jumpForce * transform.up);
                    timecnt = Time.timeSinceLevelLoad;
                    timeList.Add(Time.timeSinceLevelLoad);
                    actionList.Add(0);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (Time.timeSinceLevelLoad > cd + timecnt2)
                {
                    timecnt2 = Time.timeSinceLevelLoad;
                    shootingPoint.GetComponent<Shoot>().ThrowGrenade();
                    timeList.Add(Time.timeSinceLevelLoad);
                    actionList.Add(4);
                }
            }

            // move
            if (moving)
            {
                Move();
            }
        }
    }


    void Move()   // false-left, true-right
    {
        Vector3 tmpv = transform.position;
        if (direction == false && tmpv.x > leftBorder.position.x)
        {
            tmpv.x -= movingSpeed * Time.deltaTime;
        }
        else if (direction == true && tmpv.x < border.position.x)
        {
            tmpv.x += movingSpeed * Time.deltaTime;
        }

        transform.position = tmpv;
    }



}
