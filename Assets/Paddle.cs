using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    float PaddleMoveUnits;
    float widthOfCollider;
    [SerializeField] float BounceAngleHalfRange = 60f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PaddleMoveUnits = ConfigurationUtils.PaddleMoveUnitsPerSecond;
        widthOfCollider = GetComponent<BoxCollider2D>().size.x / 2;
        BounceAngleHalfRange = BounceAngleHalfRange * Mathf.Deg2Rad;
    }

    private void FixedUpdate()
    {
        float dir = Input.GetAxis("Horizontal");
        Vector2 FuturePos = new Vector2(transform.position.x + (dir * PaddleMoveUnits * Time.deltaTime), transform.position.y);
        Vector2 postomove = ClampedX(FuturePos);
        HanldeControll(postomove);
    }
    void HanldeControll(Vector2 postomove)
    {
        rb.MovePosition(postomove);
    }
    Vector2 ClampedX(Vector2 FuturePos)
    {
        if (FuturePos.x >= ScreenUtils.ScreenRight - widthOfCollider)
        {
            FuturePos.x = ScreenUtils.ScreenRight - widthOfCollider;
        }
        if (FuturePos.x <= ScreenUtils.ScreenLeft + widthOfCollider)
        {
            FuturePos.x = ScreenUtils.ScreenLeft + widthOfCollider;
        }
        return FuturePos;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        bool isonTop = true;
        if (coll.gameObject.transform.position.y <= gameObject.transform.position.y + gameObject.GetComponent<BoxCollider2D>().size.y)
        {
            isonTop = false;
            print(GetComponent<BoxCollider2D>().size.y - coll.gameObject.GetComponent<CircleCollider2D>().radius);
            print(coll.gameObject.transform.position.y);
        }
        if (isonTop == true)
        {
            if (coll.gameObject.CompareTag("Ball"))
            {
                // calculate new ball direction
                float ballOffsetFromPaddleCenter = transform.position.x -
                    coll.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    widthOfCollider;
                float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // tell ball to set direction to new direction
                Ball ballScript = coll.gameObject.GetComponent<Ball>();
                ballScript.SetDirection(direction);
            }
        }
    }

}
