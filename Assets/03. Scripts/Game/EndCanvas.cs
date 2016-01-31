using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DayControll;
using ApplicationControll;

public class EndCanvas : MonoBehaviour {

    DayManager dayManager;

    [SerializeField]
    private Text day;

    public void Awake()
    {
        dayManager = FindObjectOfType<DayManager>().GetComponent<DayManager>();
        day.text = dayManager._PassedDay.ToString();
    }
    public void Update()
    {
        if(Input.GetMouseButton(0))
        {
            GetComponent<ExitApplication>()._Exit = true;
        }
    }
    
}
