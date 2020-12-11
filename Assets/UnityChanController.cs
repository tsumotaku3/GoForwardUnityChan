﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるためのコンポーネントを入れる
    Rigidbody2D rigid2D;
    //地面の位置
    private float groundLevel = -3.0f;
    //ジャンプの速度の減衰
    private float dump = 0.8f;
    //ジャンプの速度
    float jumpVelocity = 20;
    //ゲームオーバーになる位置
    private float deadLine = -9;
    // Start is called before the first frame update
    void Start()
    {
        //アニメータのコンポーネントを入れる
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するためにAnimatorのパラメータを調節する
        this.animator.SetFloat("Horizontal",1);

        //着地しているかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
        //ジャンプ状態のときはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        //着地状態でクリックされたとき
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        }
        //クリックするのをやめたら上方向への力を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        //deadLineを超えたらゲームオーバーにする
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //Unityちゃんを破棄する
            Destroy(gameObject);
        }
    }
}
