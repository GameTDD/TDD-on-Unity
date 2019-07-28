using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestLife
    {
        LifeGauge cube;

        [SetUp]
        public void Setup()
        {
            cube = new GameObject().AddComponent<LifeGauge>();
            cube.life = 100;
            cube.damage = 5;
        }

        [Test]
        public void TestLifeSimpleDamage()
        {
            Assert.AreEqual(100, cube.life);

            cube.Damaged();

            Assert.AreEqual(95, cube.life);
        }

        [Test]
        public void TestLifeMultiDamage()
        {
            Assert.AreEqual(100, cube.life);

            cube.Damaged();
            cube.Damaged();
            cube.Damaged();

            Assert.AreEqual(85, cube.life);
        }

        [Test]
        public void TestLifeAlwaysGreaterOrEqualToZero()
        {
            Assert.AreEqual(100, cube.life);

            for (int i = 0; i < 30; i++)
            {
                cube.Damaged();
            }

            Assert.That(cube.life == 0);
        }

        [Test]
        public void TestLifeAlwaysGreaterOrEqualToZeroForVariableDamage()
        {
            cube.damage = 7;
            Assert.AreEqual(100, cube.life);

            for (int i = 0; i < 15; i++)
            {
                cube.Damaged();
            }

            Assert.That(cube.life == 0);
        }
    }
}
