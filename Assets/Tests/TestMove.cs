using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestMove
    {
        MoveController moveController;

        [OneTimeSetUp]
        public void TestSetUp()
        {
            moveController = new MoveController();
        }

        [Test]
        public void TestMovePassesForHorizontalAxis()
        {
            float h = 1f;
            float deltaTime = 1f;

            float actualSpeed = moveController.SpeedByFrame(h, deltaTime);

            Assert.AreEqual(actualSpeed, 20f);
        }

        [Test]
        public void TestMovePassesForVerticalAxis()
        {
            float v = 0.3f;
            float deltaTime = 0.7f;

            float actualSpeed = moveController.SpeedByFrame(v, deltaTime);

            Assert.AreEqual(actualSpeed, 4.2f);
        }
    }
}
