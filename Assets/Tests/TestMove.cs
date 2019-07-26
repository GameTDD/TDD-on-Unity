using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestMove
    {
        Movement movement;

        [OneTimeSetUp]
        public void TestSetUp()
        {
            movement = new Movement();
        }

        [Test]
        public void TestMovePassesForHorizontalAxis()
        {
            float h = 1f;
            float speed = 20f;
            float deltaTime = 1f;

            float actualSpeed = movement.SpeedByFrame(h, speed, deltaTime);

            Assert.AreEqual(actualSpeed, 20f);
        }

        [Test]
        public void TestMovePassesForVerticalAxis()
        {
            float v = 0.3f;
            float speed = 20f;
            float deltaTime = 0.7f;

            float actualSpeed = movement.SpeedByFrame(v, speed, deltaTime);

            Assert.That(Mathf.Approximately(actualSpeed, 4.2f));
        }

        [Test]
        public void TestNewPositionHasNoChangeOverDirection()
        {
            float x = 0f;
            float z = 0f;
            Vector3 position = new Vector3(3f, 4f, 5f);

            Vector3 newPosition = movement.CalculatePosition(position, x, z);

            Assert.AreEqual(position, newPosition);
        }

        [Test]
        public void TestNewPositionHasChangedOnX()
        {
            float x = 1f;
            float z = 0f;
            Vector3 position = new Vector3(3f, 4f, 5f);

            Vector3 newPosition = movement.CalculatePosition(position, x, z);

            Assert.AreEqual(new Vector3(4f,4f,5f) , newPosition);
        }

        [Test]
        public void TestNewPositionHasChangedOnXAndZ()
        {
            float x = 3f;
            float z = 5f;
            Vector3 position = new Vector3(3f, 4f, 5f);

            Vector3 newPosition = movement.CalculatePosition(position, x, z);

            Assert.AreEqual(new Vector3(6f, 4f, 10f), newPosition);
        }
    }
}
