using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SummonText : MonoBehaviour
{

    string Name;
    string Text;

    bool appear;

    float alpha;

    public void Awake()
    {
        GetComponent<Text>().color = new Color(1, 1, 1, 0);
        appear = false;
        alpha = 0;
    }

    public void Activate(string name)
    {
        Name = name;

        Text = name + XMLManager.Instance.Load_SummonText(Random.Range(0, 5)).Text;

        GetComponent<Text>().text = Text;
        
        appear = false;

        StartCoroutine(Appear());

    }

    IEnumerator Appear()
    {
        while(!appear)
        {
            yield return null;

            GetComponent<Text>().color = new Color(0, 0, 0, alpha += 0.05f);

            if(GetComponent<Text>().color.a >= 1)
            {
                appear = true;
                yield return new WaitForSeconds(0.75f);
                StartCoroutine(DisAppear());
            }
        }
    }
    IEnumerator DisAppear()
    {
        StopCoroutine(Appear());
        while (appear)
        {
            yield return null;

            GetComponent<Text>().color = new Color(0, 0, 0, alpha -= 0.05f);

            if (GetComponent<Text>().color.a <= 0)
            {
                appear = false;
                StopCoroutine(DisAppear());
            }
        }
    }
}
