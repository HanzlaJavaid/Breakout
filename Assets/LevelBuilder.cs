using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    float startHeight;
    [SerializeField] GameObject PaddlePrefab;
    [SerializeField] GameObject StandardblockPrefab;
    [SerializeField] GameObject BonusblockPrefab;
    [SerializeField] GameObject PickupblockPrefab;
    float[] dimenstions = new float[2];
    float StProb;
    float BsProb;
    float SpProb;
    float FrProb;
    void Start()
    {
        SetValues();
        CreatePaddle();
        CreateLevel();
    }

    private void SetValues()
    {
        startHeight = ScreenUtils.ScreenTop - (ScreenUtils.ScreenTop / 3f);
        dimenstions[0] = StandardblockPrefab.GetComponent<BoxCollider2D>().size.x;
        dimenstions[1] = StandardblockPrefab.GetComponent<BoxCollider2D>().size.y;
        StProb = ConfigurationUtils.StProb;
        BsProb = ConfigurationUtils.BsProb;
        SpProb = ConfigurationUtils.SpProb;
        FrProb = ConfigurationUtils.FrProb;
    }

    private void CreatePaddle()
    {
        GameObject x = Instantiate(PaddlePrefab);
        x.transform.position = new Vector3(ScreenUtils.ScreenRight / 2, ScreenUtils.ScreenBottom, 0);
    }

    void CreateLevel()
    {
        Vector2 posToSpawn = new Vector2(ScreenUtils.ScreenLeft, startHeight);
        while ( posToSpawn.y < ScreenUtils.ScreenTop) 
        {
            PlaceBlock(posToSpawn);
            posToSpawn.x += dimenstions[0];
            if(posToSpawn.x >= ScreenUtils.ScreenRight)
            {
                posToSpawn.y += dimenstions[1];
                posToSpawn.x = ScreenUtils.ScreenLeft;
            }
        }    
    }

    void PlaceBlock(Vector3 PostoSpawn)
    {
        GameObject temp = null;
        float RV = Random.Range(0f, 1f);
        if(RV <= StProb)
        {
            temp = StandardblockPrefab;
        }
        if(RV<= StProb+BsProb && RV >= StProb)
        {
            temp = BonusblockPrefab;
        }
        if(RV <= StProb + BsProb + SpProb && RV>=StProb+BsProb)
        {
            temp = PickupblockPrefab;
            temp.GetComponent<PickupBlock>().pickupEffect = PickupEffect.Speedup;
        }
        if (RV <= StProb + BsProb + SpProb+FrProb && RV>=StProb+BsProb+SpProb)
        {
            temp = PickupblockPrefab;
            temp.GetComponent<PickupBlock>().pickupEffect = PickupEffect.Freezer;
        }
        GameObject x = Instantiate(temp);
        x.transform.position = PostoSpawn;
    }
}
