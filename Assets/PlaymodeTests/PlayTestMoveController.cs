using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTestMoveController
    {
        [UnityTest]
        public IEnumerator PlayerMovesTowardsXDirection()
        {
            var cube = new GameObject().AddComponent<MoveController>();
            cube.gameObject.AddComponent<Rigidbody>();

            var service = Substitute.For<IUnityService>();
            service.GetDeltaTime().Returns(0.3f);
            service.GetInputAxis("Horizontal").Returns(1f);

            cube.speed = 1f;
            cube.service = service;

            Vector3 initialPosition = cube.transform.position;
            cube.service.GetInputAxis("Horizontal");

            yield return new WaitForSeconds(0.25f);

            Vector3 finalPosition = cube.transform.position;

            Assert.That(finalPosition.x > initialPosition.x);
            Assert.AreEqual(initialPosition.z, finalPosition.z);
        }
    }
}
