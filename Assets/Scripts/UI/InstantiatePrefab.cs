using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public void PrefabInstantiate(GameObject go)
    {
        Instantiate(go);
    }
}
