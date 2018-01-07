using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    // HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    // 初期の傾き
    private float defaultAngle = 20;
    // 弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
	void Start () {
        // HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        // フリッパーの傾きを設定
        setAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
        ////////////////////////////////////////////////////////////////////////////
        // 発展課題：画面タッチで左右のフリッパーを動かす
        ////////////////////////////////////////////////////////////////////////////

        foreach (Touch t in Input.touches) {
            var id = t.fingerId;

            switch(t.phase) {
                case TouchPhase.Began:
                    if (t.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        // 画面左半分にタッチしたら、左フリッパー
                        setAngle(this.flickAngle);
                    }

                    if (t.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                    {
                        // 画面右半分にタッチしたら、右フリッパー
                        setAngle(this.flickAngle);
                    }
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        // 左タッチを離したら、左フリッパーを戻す
                        setAngle(this.defaultAngle);
                    }
                    if (t.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                    {
                        // 右タッチを離したら、右フリッパーを戻す
                        setAngle(this.defaultAngle);
                    }
                    break;

            }
        }

        // 左矢印キーを押した時、左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            setAngle(this.flickAngle);
        }
        // 右矢印キーを押した時、右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            setAngle(this.flickAngle);
        }
        // 矢印キーが離された時、フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            setAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            setAngle(this.defaultAngle);
        }

    }

    // フリッパーの傾きを設定
    public void setAngle (float angle){
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;

    }
}
