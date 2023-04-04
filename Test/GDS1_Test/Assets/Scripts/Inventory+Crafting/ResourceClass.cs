using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Resource Class", menuName = "Item/Resource")]

public class ResourceClass : ItemClass
{
    [Header("Resource")]
    public ResourceType resourceType;
    public enum ResourceType
    {
        redResource, 
        orangeResource,
        yellowResource, 
        greenResource, 
        blueResource, 
        purpleResource
    }

    public override ResourceClass GetResource() { return this; }
}
