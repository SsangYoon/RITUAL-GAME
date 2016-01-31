using UnityEngine;
using System.Collections;

public class Friendly : MonoBehaviour {

    [SerializeField]
    private float _hp;
    public float hp { get { return _hp; } set { _hp = value; } }
    [SerializeField]
    private float _ap;
    public float ap { get { return _ap; } set { _ap = value; } }


    public void Awake()
    {
        
    }
}
