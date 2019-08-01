using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttack : MonoBehaviour
{
    public float timer;
    public LifeGauge lifeGauge;
    public Text text;
    const string FORMATTER = "Time Attack: {0:F2}"; 

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        text.text = string.Format(FORMATTER, timer);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeGauge.life > 0)
        {
            timer += Time.deltaTime;
        }
        text.text = string.Format(FORMATTER, timer);
    }
}
