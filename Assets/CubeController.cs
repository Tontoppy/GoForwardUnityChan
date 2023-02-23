using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //キューブの移動速度
    private float speed = -12;

    //消滅位置w
    private float deadLine = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x <= deadLine)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したオブジェクトを取得
        GameObject collisionObject = collision.gameObject;
        //CubeかGroundに当たった時に音を鳴らす
        //Cubeの時は位置が上のキューブだけ音を鳴らす（2重に鳴るので）
        if((collisionObject.tag == TagName.CubeTag && this.transform.position.y >= collisionObject.transform.position.y)
            || collisionObject.tag == TagName.GroundTag)
        {
            //音を鳴らす
            GetComponent<AudioSource>().Play();

        }
    }
}
