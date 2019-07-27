using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class TestEnemySpawner
	{
		EnemySpawner enemySpawner;

		[OneTimeSetUp]
		public void TestSetUp()
		{
			enemySpawner = new GameObject().AddComponent<EnemySpawner>();
		}

		[Test]
		public void TestEnemySpawnForZeroValues()
		{
			float radius = 1f;
			float angle = 0f;

			Vector3 enemyPosition = enemySpawner.GetPosition(Vector3.zero, radius, angle);
			Vector3 expected = new Vector3(1, 0, 0);
            
			Assert.AreEqual(expected, enemyPosition);
		}

        [Test]
        public void TestEnemySpawnForLargeRadius()
        {
            float radius = 3f;
            float angle = 0f;

            Vector3 enemyPosition = enemySpawner.GetPosition(Vector3.zero, radius, angle);
            Vector3 expected = new Vector3(3, 0, 0);

            Assert.AreEqual(expected, enemyPosition);
        }

        [Test]
        public void TestEnemySpawnForNegativeRadius()
        {
            float radius = -5f;
            float angle = 0f;

            Vector3 enemyPosition = enemySpawner.GetPosition(Vector3.zero, radius, angle);
            Vector3 expected = new Vector3(5, 0, 0);

            Assert.AreEqual(expected, enemyPosition);
        }

        [Test]
        public void TestEnemySpawnForZeroRadius()
        {
            float radius = 0;
            float angle = 0f;

            Vector3 enemyPosition = enemySpawner.GetPosition(Vector3.zero, radius, angle);
            Vector3 expected = new Vector3(1, 0, 0);

            Assert.AreEqual(expected, enemyPosition);
        }

        [Test]
        public void TestEnemySpawnForPlayerPosisionOne()
        {
            float radius = 4;
            float angle = 0f;
            Vector3 playerPosition = Vector3.one;

            Vector3 enemyPosition = enemySpawner.GetPosition(playerPosition, radius, angle);
            Vector3 expected = new Vector3(5, 1, 1);

            Assert.AreEqual(expected, enemyPosition);
        }

        [Test]
        public void TestEnemySpawnForRadiusSmallerThanOne()
        {
            float radius = 0.5f;
            float angle = 0f;
            Vector3 playerPosition = Vector3.one;


            Vector3 enemyPosition = enemySpawner.GetPosition(playerPosition, radius, angle);
            Vector3 expected = new Vector3(2, 1, 1);

            Assert.AreEqual(expected, enemyPosition);
        }

        [Test]
        public void TestEnemySpawnForPlayerPosisionVariableAndAngleVariable()
        {
            float radius = 4;
            float angle = Mathf.PI / 4;
            Vector3 playerPosition = new Vector3(3, 4, 6);

            Vector3 enemyPosition = enemySpawner.GetPosition(playerPosition, radius, angle);
            Vector3 expected = new Vector3(5.8f, 4, 8.8f);

            Assert.AreEqual(expected.x, enemyPosition.x, 0.1f, "Positions differ x", null);
            Assert.AreEqual(expected.y, enemyPosition.y, 0.1f, "Positions differ y", null);
            Assert.AreEqual(expected.z, enemyPosition.z, 0.1f, "Positions differ z", null);
        }
    }
}
