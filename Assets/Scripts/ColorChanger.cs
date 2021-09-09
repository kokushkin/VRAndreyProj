using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetColourYellow()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        
    }

    public void SetColourGreen()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;

    }
}
