using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    float score = 0;
    public static float ballsleft;
    [SerializeField] GameObject Score;
    [SerializeField] public static GameObject BallsLeft;
    // Start is called before the first frame update
    void Start()
    {
        Score = transform.Find("Score").gameObject;
        BallsLeft = transform.Find("Ballsleft").gameObject;
        ballsleft = ConfigurationUtils.BallsPerGame;
        SetScore();
        SetBallsleft();

    }

    public void EditScore(float val)
    {
        score = score + val;
        SetScore();
    }

    public static void BallMinus()
    {
        ballsleft -= 1f;
        SetBallsleft();
    }

    public void SetScore()
    {
        Score.GetComponent<Text>().text = "Score: " + score.ToString();
    }
    public static void SetBallsleft()
    {
        BallsLeft.GetComponent<Text>().text = "Balls Left: " + ballsleft.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
