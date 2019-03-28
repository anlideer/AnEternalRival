using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static int playerBlood = 30;
    public static int enemyBlood = 30;
    public static int playerBullet = 50;
    public static int enemyBullet = 50;
    public static int playerGrenade = 3;
    public static int enemyGrenade = 3;
    public static bool isOver = false;
    public GameObject CopyUObj;

    bool copied = false;

    private void Awake()
    {
        GameObject tmpG = GameObject.FindGameObjectWithTag("CopyU");
        if (tmpG == null)
        {
            Instantiate(CopyUObj);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        playerBlood = enemyBlood = 30;
        playerBullet = enemyBullet = 50;
        playerGrenade = enemyGrenade = 3;
        isOver = false;
        copied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBlood <= 0 || enemyBlood <= 0)
        {
            isOver = true;
        }
        if (playerBullet == 0 && enemyBullet == 0)
        {
            isOver = true;
        }

        if (isOver)
        {
            if (!copied)
            {
                copied = true;
                // copy
                CopyList();
            }
        }
    }

    void CopyList()
    {
        CopyU.timeList = new List<float>();
        foreach(float f in Player.timeList)
        {
            CopyU.timeList.Add(f);
        }
        CopyU.actionList = new List<int>();
        foreach(int i in  Player.actionList)
        {
            CopyU.actionList.Add(i);
        }
        CopyU.shootingList = new List<Vector2>();
        foreach(Vector2 v in Player.shootingList)
        {
            CopyU.shootingList.Add(v);
        }
    }


    public void NextRound()
    {
        CopyU.round++;
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToCover()
    {
        SceneManager.LoadScene("Cover");
    }
}
