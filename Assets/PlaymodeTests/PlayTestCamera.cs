using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTestCamera
    {
        MoveController moveController;
        CameraController camera;
        IUnityService service;
        LifeGauge life;

        [SetUp]
        public void TestSetUp()
        {
            life = new GameObject().AddComponent<LifeGauge>();
            life.lifebar = new GameObject().AddComponent<Slider>();
            life.loose = new GameObject().AddComponent<Text>();
            life.life = 100;
        
            moveController = new GameObject().AddComponent<MoveController>();
            moveController.gameObject.AddComponent<Rigidbody>();
            moveController.transform.position = Vector3.one;
            moveController.lifeGauge = life;

            camera = new GameObject().AddComponent<CameraController>();
            camera.transform.position = new Vector3(3, 3, 3);
            camera.target = moveController.transform;

            service = Substitute.For<IUnityService>();
            service.GetDeltaTime().Returns(0.5f);

        }

        [UnityTest]
        public IEnumerator OffsetIsCreatedAsStart()
        {
            yield return null;

            Assert.That(camera.Offset.x.CompareTo(2.0f) == 0);
        }

        [UnityTest]
        public IEnumerator CameraPositionIsGreaterWhenObjMovesRight()
        {

            service.GetInputAxis("Horizontal").Returns(1f);
            moveController.service = service;

            Vector3 initialPosition = camera.transform.position;
            moveController.service.GetInputAxis("Horizontal");

            yield return new WaitForSeconds(1f);

            Vector3 finalPosition = camera.transform.position;

            Assert.That(finalPosition.x > initialPosition.x);
            Assert.AreEqual(initialPosition.z, finalPosition.z);
        }

        [UnityTest]
        public IEnumerator CameraPositionIsGreaterWhenObjMovesUp()
        {

            service.GetInputAxis("Vertical").Returns(-1f);
            moveController.service = service;

            Vector3 initialPosition = camera.transform.position;
            moveController.service.GetInputAxis("Vertical");

            yield return new WaitForSeconds(1f);

            Vector3 finalPosition = camera.transform.position;

            Assert.That(finalPosition.z < initialPosition.z);
            Assert.AreEqual(initialPosition.x, finalPosition.x);
        }

        [UnityTest]
        public IEnumerator CameraDoesntMoveIfPlayerDoesntMove()
        {

            moveController.service = service;

            Vector3 initialPosition = camera.transform.position;

            yield return new WaitForSeconds(1f);

            Vector3 finalPosition = camera.transform.position;

            Assert.AreEqual(finalPosition.z, initialPosition.z);
            Assert.AreEqual(initialPosition.x, finalPosition.x);
        }
    }
}
