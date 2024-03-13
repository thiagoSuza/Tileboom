using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayerIndex : MonoBehaviour
{
    [SerializeField]
    private int layerIndex;
    public void Action()
    {
        GetComponentInChildren<PieceControllerRandon>().layer = layerIndex;
    }
}
