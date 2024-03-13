using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFronTheListRandom : MonoBehaviour
{
    public int index;
    public ChangePositions changePositions;

    private void Awake()
    {

    }
    private void Start()
    {
        changePositions = FindObjectOfType<ChangePositions>();
        index = GetComponent<PieceControllerRandon>().layer + 1;
        AddToList();
    }

    public void RemoveList()
    {
        changePositions.Remove(index, gameObject);
    }

    public void AddToList()
    {
        changePositions.Add(index, gameObject);
    }
}
