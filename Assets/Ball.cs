using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float ballforce;
    // Start is called before the first frame update
    [SerializeField] float angle = 20;
    Timer DeathTimer;
    Timer StartTimer;
    bool ToLaunch = true;
    void Start()
    {
        DeathTimer = gameObject.AddComponent<Timer>();
        StartTimer = gameObject.AddComponent<Timer>();
        DeathTimer.Duration = ConfigurationUtils.DeathTimer;
        StartTimer.Duration = 1f;
        DeathTimer.Run();
        StartTimer.Run();
        ballforce = ConfigurationUtils.ballImpulseForce;
        angle = angle * Mathf.Deg2Rad;
    }

    private void Launch()
    {
        Vector2 forceVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * ballforce * Time.deltaTime;
        GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
    }

    public void SetDirection(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().velocity = dir*ballforce*Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(DeathTimer.Finished == true)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
        if (StartTimer.Finished == true && ToLaunch == true)
        {
            Launch();
            ToLaunch = false;
        }
    }
    private void OnBecameInvisible()
    {
        if (DeathTimer.Finished != true && transform.position.y <= ScreenUtils.ScreenBottom)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
            HUD.BallMinus();
        }
    }
}
