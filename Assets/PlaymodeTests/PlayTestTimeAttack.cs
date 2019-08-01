using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTestTimeAttack
    {
        TimeAttack time;
        LifeGauge life;

        [SetUp]
        public void SetUp()
        {
            time = new GameObject().AddComponent<TimeAttack>();
            life = new GameObject().AddComponent<LifeGauge>();
            var text = new GameObject().AddComponent<Text>();
            text.text = "Time Attack: {0:F2}";

            life.life = 100;
            life.lifebar = new GameObject().AddComponent<Slider>();
            life.loose = new GameObject().AddComponent<Text>();

            time.lifeGauge = life;
            time.text = text;
        }
        
        [UnityTest]
        public IEnumerator TimeAttackTakes5Secs()
        {
            yield return new WaitForSeconds(5);

            Assert.AreEqual(5, Mathf.FloorToInt(time.timer));
        }

        [UnityTest]
        public IEnumerator TimeAttackStopsWhenLifeIsZero()
        {
            yield return new WaitForSeconds(4);

            Assert.AreEqual(4, Mathf.FloorToInt(time.timer));

            var initialTimer = time.timer;
            life.life = 0;

            yield return new WaitForSeconds(5);

            var finalTimer = time.timer;


            Assert.AreEqual(initialTimer, finalTimer);
        }

        [UnityTest]
        public IEnumerator TimeAttackRendersTextWith0value()
        {
            yield return null;

            Assert.AreEqual("Time Attack: 0", time.text.text.Split('.')[0]);
        }

        [UnityTest]
        public IEnumerator TimeAttackRendersTextWithIncreasingValues()
        {
            yield return new WaitForSeconds(2);

            Assert.AreEqual("Time Attack: 2", time.text.text.Split('.')[0]);

            yield return new WaitForSeconds(4);

            Assert.AreEqual("Time Attack: 6", time.text.text.Split('.')[0]);
        }
    }
}
