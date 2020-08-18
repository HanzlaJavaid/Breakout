using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlock : block
{
    [SerializeField] Sprite FreezerSprite;
    [SerializeField] Sprite SpeedupSprite;
    public PickupEffect pickupEffect;
    private void Start()
    {
        base.Start();
        if(pickupEffect == PickupEffect.Freezer)
        {
            GetComponent<SpriteRenderer>().sprite = FreezerSprite;
        }
        if (pickupEffect == PickupEffect.Speedup)
        {
            GetComponent<SpriteRenderer>().sprite = SpeedupSprite;
        }
        Points = ConfigurationUtils.PickupBlockScore;
    }
}
