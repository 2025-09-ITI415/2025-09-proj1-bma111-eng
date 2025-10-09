using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        Goal.goalMet = true;

        // also set the alpha of the color of higher opacity
        Material mat = GetComponent<Renderer>().material;
        Color c = mat.color;
        c.a = 0.75f;
        mat.color = c;
    }
}
