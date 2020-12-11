using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject gameOverText;
    //走行距離テキスト
    private GameObject RunLangeText;
    //走った距離
    private float len = 0;
    //走るスピード
    private float speed = 5;
    //ゲームオーバーの判定
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.RunLangeText = GameObject.Find("RunLange");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            //走った距離を更新する
            this.len += this.speed * Time.deltaTime;

            //走った距離を表示する
            this.RunLangeText.GetComponent<Text>().text = "Distance:" + len.ToString("F2")+"m";
        }
        //ゲームオーバーになった場合
        if (this.isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        //ゲームオーバーになったとき、ゲーム上にGameOverを表示する
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}
