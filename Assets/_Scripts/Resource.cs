using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType {
    Ore,
    Tree,
    Fruit
}

public class Resource : MonoBehaviour
{
    public ResourceType resourceType;
    public int resourceAmount;
}
