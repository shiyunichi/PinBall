using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalllController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //得点を入れる変数を初期化する
    private int score ;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //得点を表示するテキスト
    private GameObject scoreText;


    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;

        //シーンの中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーンの中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");


    }

    // Update is called once per frame
    void Update()
    {

        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {

            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //衝突時に呼ばれる函数
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 5;
            
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score += 10;

        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 20;
           
        }

        this.scoreText.GetComponent<Text>().text = "Score:" + score;

    }


}
