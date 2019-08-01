using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    public int life;
    public int damage;
    public Slider lifebar;
    public Text loose;

    void Start() {
        lifebar.value = life;
        loose.enabled = false;
        loose.text = "You lose";
    }

    void Update() {
        lifebar.value = life;
        if (lifebar.value <= 0)
        {
            loose.enabled = true;
        }
    }

    public void Damaged()
    {
        if (life > 0)
        {
            life -= damage;
        }

        if (life <= 0)
        {
            life = 0;
        }
    }

    public void OnCollisionEnter(Collision collision) => Damaged();

    public bool IsAlive()
    {
        return life > 0;
    }
}
