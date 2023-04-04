using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Ammo Class", menuName = "Item/Ammo")]
public class AmmoClass : ItemClass
{
    
    [Header("Ammo")]
    public AmmoType ammoType;
    public enum AmmoType
    {
        redAmmo,
        orangeAmmo,
        yellowAmmo,
        greenAmmo,
        blueAmmo,
        purpleAmmo
    }

    public override AmmoClass GetAmmo() { return this; }

}
