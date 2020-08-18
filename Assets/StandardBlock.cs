using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : block
{
    // Start is called before the first frame update
    [SerializeField] List<Sprite> StandardBlockSprites;
    private void Start()
    {
        base.Start();
        Points = ConfigurationUtils.StandardBlockScore;
        GetComponent<SpriteRenderer>().sprite = StandardBlockSprites[Random.Range(0, StandardBlockSprites.Count)];
    }

}
