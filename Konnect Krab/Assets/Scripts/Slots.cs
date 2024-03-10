using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public int slot;
    public GameManager gm;

    void OnMouseDown()
    {
       Debug.Log("slot number is" +  slot); 
    }
}
