using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // 重力加速度
    const float Gravity = 9.81f; // 重力加速度定数

    // 重力の適用具合
    public float gravityScale = 1.0f; // 重力のスケールパラメーター



    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(); // 重力ベクトルの初期化

        // モバイル操作の場合
        if(Application.isMobilePlatform){
            vector.x = Input.acceleration.x;
            vector.y = Input.acceleration.y;
            vector.z = Input.acceleration.z;
        }
        // PCでのキーボード操作の場合
        else{

            // キーの入力を検知し、ベクトルを設定
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            // 高さ方向の判定は、キーのzを適応
            if (Input.GetKey("z"))
            {
                vector.y = 1.0f; // 高さ方向の入力取得
            }
            else
            {
                vector.y = -1.0f;
            }
        }
        // シーンの重力を入力ベクトルの方向に合わせて変化
        Physics.gravity = Gravity * vector.normalized * gravityScale; // 重力の変更
    }
}
 