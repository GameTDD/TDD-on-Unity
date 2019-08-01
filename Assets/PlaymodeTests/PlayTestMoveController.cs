using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTestMoveController
    {
        public MoveController cube;
        public IUnityService service;
        LifeGauge life;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            life = new GameObject().AddComponent<LifeGauge>();
            life.lifebar = new GameObject().AddComponent<Slider>();
            life.loose = new GameObject().AddComponent<Text>();
        }

        public void Setup()
        {
            cube = new GameObject().AddComponent<MoveController>();
            cube.gameObject.AddComponent<Rigidbody>();
            cube.speed = 1f;

            service = Substitute.For<IUnityService>();
            service.GetDeltaTime().Returns(0.3f);
            life.life = 100;
            cube.lifeGauge = life;
        }

        [UnityTest]
        public IEnumerator PlayerMovesOnlyTowardsXDirection()
        {
            Setup();
            service.GetInputAxis("Horizontal").Returns(1f);
            cube.service = service;

            Vector3 initialPosition = cube.transform.position;
            cube.service.GetInputAxis("Horizontal");

            yield return new WaitForSeconds(0.25f);

            Vector3 finalPosition = cube.transform.position;

            Assert.That(finalPosition.x > initialPosition.x);
            Assert.AreEqual(initialPosition.z, finalPosition.z);
        }

        [UnityTest]
        public IEnumerator PlayerMovesNegativelyOnXZDirections()
        {
            Setup();
            service.GetInputAxis("Horizontal").Returns(-1f);
            service.GetInputAxis("Vertical").Returns(-1f);

            cube.speed = 1f;
            cube.service = service;

            Vector3 initialPosition = cube.transform.position;
            cube.service.GetInputAxis("Horizontal");
            cube.service.GetInputAxis("Vertical");

            yield return new WaitForSeconds(0.25f);

            Vector3 finalPosition = cube.transform.position;

            Assert.That(finalPosition.x < initialPosition.x);
            Assert.That(finalPosition.z < initialPosition.z);
        }

        [UnityTest]
        public IEnumerator PlayerStopsMovingWhenLifeIsZero()
        {
            Setup();
            service.GetInputAxis("Horizontal").Returns(-1f);
            service.GetInputAxis("Vertical").Returns(-1f);

            cube.speed = 1f;
            cube.service = service;

            Vector3 initialPosition = cube.transform.position;
            life.life = 0;

            cube.service.GetInputAxis("Horizontal");
            cube.service.GetInputAxis("Vertical");

            yield return new WaitForSeconds(0.25f);

            Vector3 finalPosition = cube.transform.position;

            Assert.AreEqual(initialPosition.x, finalPosition.x);
            Assert.AreEqual(initialPosition.z, finalPosition.z);
        }
    }
}
