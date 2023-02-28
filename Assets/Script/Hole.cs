using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // どのボールを吸い寄せるかをタグで指定
    public string targetTag;
    bool isHolding;

    // ボールが入っているかを返す
    public bool IsHolding()
    {
        return isHolding;
    }

    // ボールがコライダーに入った瞬間に呼び出し
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }

    // ボールがコライダーに出た瞬間に呼び出し
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = false;
        } 
    }

    // ボールが重なっている間、毎フレーム呼び出し
    void OnTriggerStay(Collider other)
    {
        // コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>(); // Rigid body コンポーネント取得

        // ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        // タグに応じてボールに力を加える
        if (other.gameObject.tag == targetTag)
        {
            // 中心地点でボールを止めるため速度を原則させる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
}
