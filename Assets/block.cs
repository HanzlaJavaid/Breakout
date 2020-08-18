using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour 
{
    [SerializeField] protected GameObject hud;
    protected float Points = 0;
    protected void Start()
    {
        hud = GameObject.Find("HUD"); 
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        hud.GetComponent<HUD>().EditScore(Points);
        Destroy(gameObject);
    }
}
