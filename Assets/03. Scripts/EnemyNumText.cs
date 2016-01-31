using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyNumText : MonoBehaviour {

    DayControll.DayManager dayManager;
    StageInfo temp;
    void Awake()
    {
        dayManager = FindObjectOfType<DayControll.DayManager>().GetComponent<DayControll.DayManager>();
    }
	void Update()
    {
        temp = XMLManager.Instance.Load_StageData(dayManager._PassedDay - 1);
        
        GetComponent<Text>().text = temp.Sum.ToString();
    }
}
