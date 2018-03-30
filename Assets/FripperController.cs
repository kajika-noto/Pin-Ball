using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;
    private float flickAngle = -20;

    //FingerID格納
    private int leftFingerId = 0;
    private int rightFingerId = 0;

	// Use this for initialization
	void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {
        //キーボード操作
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        //タッチ操作
        for (int i = 0; i < Input.touchCount; i++)
        {
            var id = Input.touches[i].fingerId;
            var pos = Input.touches[i].position;

            switch (Input.touches[i].phase)
            {
                case TouchPhase.Began:
                    if (pos.x < Screen.width * 0.5 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                        leftFingerId = id;
                    }
                    if (pos.x > Screen.width * 0.5 && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                        rightFingerId = id;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (id == leftFingerId && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    if (id == rightFingerId && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    break;
            }
        }

	}

    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
