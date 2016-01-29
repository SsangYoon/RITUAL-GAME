using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float hp { get; set; }
    public float ap { get; set; }


    public void Awake()
    {
        hp = 10;
        ap = 1;
    }
}
