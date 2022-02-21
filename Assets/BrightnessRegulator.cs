using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessRegulator : MonoBehaviour
{
    //Materialを入れる
    Material myMaterial;

    //得点を表示するテキスト
    private GameObject scoreText;
 
    //Emissionの最小値
    private float minEmission = 0.2f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度
    private int degree = 0;
    //発光速度
    private int speed = 5;
    //ターゲットのデフォルトの色
    Color defaultColor = Color.white;
    //scoreの値を初期化
    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");

        
        //タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;

        }
        else if(tag == "LargeSterTag")
        {
            this.defaultColor = Color.yellow;


        }
        else if(tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;

            
        }

       
        //オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        //smScore[0] = smScore[1] + smScore[2] + smScore[3];
        


        if (this.degree >= 0)
        {
            //光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad)
                * this.magEmission);
            //エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;

            
        }

        

    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;
         
        if (tag == "SmallStarTag")
        {
            this.score += 5;
            
        }
        else if (tag == "LargeSterTag")
        {
            this.score += 10;
            

        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.score += 20;
            

        }

        score += score;
        Debug.Log("scoreの値" + score);
        this.scoreText.GetComponent<Text>().text = "Score:" + score;

    }


}