using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Seed Class", menuName = "Item/Seed")]

public class SeedClass : ItemClass
{
    [Header("Seed")]
    public SeedType seedType;
    public enum SeedType
    {
        redSeed,
        yellowSeed,
        blueSeed
    }

    public override SeedClass GetSeed() { return this; }
}
