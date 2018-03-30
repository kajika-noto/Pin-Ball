using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int score = 000;
    private int largestar = 10;
    private int smallstar = 1;
    private int largecloud = 50;
    private int smallcloud = 20;
    private GameObject scorepointText;

    int Add(int addpoint)
    {
        score += addpoint;
        return score;
    }

	// Use this for initialization
	void Start () {

        this.scorepointText = GameObject.Find("ScorePointText");
        
	}

    // Update is called once per frame
    void Update() {
        if (score <= 0)
        {
            this.scorepointText.GetComponent<Text>().text = "000";
        } else
        {
            this.scorepointText.GetComponent<Text>().text = score.ToString("000");
        }
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LargeStarTag")
        {
            Add(largestar); 
        }
        else if (collision.gameObject.tag == "SmallStarTag")
        {
            Add(smallstar);
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            Add(largecloud);
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            Add(smallcloud);
         }

    }


}
