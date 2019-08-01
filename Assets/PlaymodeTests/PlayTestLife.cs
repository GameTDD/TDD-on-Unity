using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTestLife
    {
        public LifeGauge cube;
        public Slider lifebar;


        [SetUp]
        public void Setup()
        {
            lifebar = new GameObject().AddComponent<Slider>();
            lifebar.maxValue = 100;
            var text = new GameObject().AddComponent<Text>();
            text.text = "OK";

            cube = new GameObject().AddComponent<LifeGauge>();
            cube.lifebar = lifebar;
            cube.life = 91;
            cube.damage = 3;
            cube.loose = text;

        }

        [UnityTest]
        public IEnumerator StartsLife()
        {
            yield return null;

            Assert.AreEqual(cube.life, cube.lifebar.value);

        }

        [UnityTest]
        public IEnumerator ReducesLife()
        {
            cube.OnCollisionEnter(new Collision());
            yield return null;

            cube.OnCollisionEnter(new Collision());
            yield return null;

            cube.OnCollisionEnter(new Collision());
            yield return null;

            Assert.AreEqual(cube.life, cube.lifebar.value);
            Assert.AreEqual(82, cube.lifebar.value);

        }

        [UnityTest]
        public IEnumerator EnablesYouLooseText()
        {
            Assert.AreEqual(91, cube.lifebar.value);
            Assert.False(cube.loose.enabled);

            cube.lifebar.value = 0;
            yield return new WaitForFixedUpdate();

            Assert.AreEqual("You lose", cube.loose.text);
        }
    }
}
