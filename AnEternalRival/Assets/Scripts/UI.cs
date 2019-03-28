using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider PlayerSlider;
    public Slider EnemySlider;
    public Text PlayerBulletNum;
    public Text EnemyBulletNum;
    public Text PlayerGrenadeNum;
    public Text EnemyGrenadeNum;
    public GameObject EndPanel;
    public Text Res;
    public Text RoundText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSlider.value = GM.playerBlood;
        EnemySlider.value = GM.enemyBlood;
        PlayerBulletNum.text = GM.playerBullet.ToString();
        EnemyBulletNum.text = GM.enemyBullet.ToString();
        PlayerGrenadeNum.text = GM.playerGrenade.ToString();
        EnemyGrenadeNum.text = GM.enemyGrenade.ToString();

        if (GM.isOver)
        {
            EndPanel.SetActive(true);
            RoundText.text = "Round " + CopyU.round.ToString();
            if (GM.playerBlood <= 0)
            {
                Res.text = "You lose";
            }
            else if (GM.enemyBlood <= 0)
            {
                Res.text = "You win";
            }
            else
            {
                Res.text = "Break even";
            }
        }
    }
}
