using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// actionList meaning:
/// 0 - jump
/// 1 - A Down
/// -1 - A Up
/// 2 - D Down
/// -2 - D Up
/// 3 - Shoot
/// 4 - Throw Grenade
/// </summary>
/// 
public class CopyU : MonoBehaviour
{
    public static int round = 0;
    public static List<float> timeList = new List<float>();
    public static List<int> actionList = new List<int>();
    public static List<Vector2> shootingList = new List<Vector2>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
