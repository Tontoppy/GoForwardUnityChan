using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーターを入れる
    Animator animator;

    //UnityちゃんのRigidbody2D
    Rigidbody2D rigido2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプ速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度
    private float jumpVelocity = 20;

    //ゲームオーバーになる位置
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        //アニメーターのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //Rigidbody2D取得
        this.rigido2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するためにAnimatorのパラメータを調整
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうか調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態の時にはボリュームを０に
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合
        if(Input.GetMouseButtonDown(0)&& isGround)
        {
            this.rigido2D.velocity = new Vector2(0, this.jumpVelocity);

        }
        //クリックがされていないとき上方向への速度を減速する
        if (Input.GetMouseButton(0)　== false)
        {
            if(this.rigido2D.velocity.y > 0)
            {
                //this.rigido2D.velocity = new Vector2(0, this.rigido2D.velocity.y - this.dump);
                this.rigido2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする
        if(this.transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数呼び出し
            GameObject.Find("Canvas").GetComponent<UIcontroller>().GameOver();
            //Unityちゃんを削除
            Destroy(gameObject);

        }
    }
}
