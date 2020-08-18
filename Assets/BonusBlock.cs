using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : block
{
    [SerializeField] Sprite BonusBlockSprite;
    private void Start()
    {
        base.Start();
        Points = ConfigurationUtils.BonusBlockScore;
        GetComponent<SpriteRenderer>().sprite = BonusBlockSprite;
    }
}
