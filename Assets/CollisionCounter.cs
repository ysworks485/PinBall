//////////////////////////////////////////////////////////////////////
// 星・雲にボールを当てると得点が入り、画面に表示される
//////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionCounter : MonoBehaviour
{
    // 衝突時の得点合計
    public static int CollisionCount;
    // 衝突１回当たりの得点
    private int Count;
    // 得点を表示するテキスト
    private GameObject CollisionCountText;

    // Use this for initialization
    void Start()
    {
        // シーンの中のCollisionCountTextオブジェクトを取得
        this.CollisionCountText = GameObject.Find("CollisionCountText");

        // ターゲットの種類によって得点を変える
        if (tag == "SmallStarTag") {
            this.Count = 5;
        } else if (tag == "LargeStarTag") {
            this.Count = 10;
        } else if (tag == "SmallCloudTag") {
            this.Count = 3;
        } else if (tag == "LargeCloudTag") {
            this.Count = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        CollisionCount = CollisionCount + this.Count;
        this.CollisionCountText.GetComponent<Text>().text = CollisionCount + "点";
    }

}
