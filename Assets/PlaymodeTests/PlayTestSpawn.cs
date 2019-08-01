using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTestSpawn
    {
        Object enemyPrefab;
        EnemySpawner world;
        LifeGauge life;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            life = new GameObject().AddComponent<LifeGauge>();
            life.lifebar = new GameObject().AddComponent<Slider>();
            life.loose = new GameObject().AddComponent<Text>();
        }

        [SetUp]
        public void Setup()
        {
            enemyPrefab = Resources.Load("Enemy");

            world = new GameObject().AddComponent<EnemySpawner>();
            world.spawnTime = 2f;
            world.radius = 10f;
            world.enemy = enemyPrefab as GameObject;
            world.lifeGauge = life;

            life.transform.position = new Vector3(2, 4, 6);
            life.life = 100;

        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(world);
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                GameObject.Destroy(obj);
            }
        }

        [UnityTest]
        public IEnumerator SpawnsFirstEnemy()
        {
            var enemysBefore = GameObject.FindGameObjectsWithTag("Enemy");
            yield return new WaitForSeconds(3);
            var enemysAfter = GameObject.FindGameObjectsWithTag("Enemy");

            Assert.That(enemysAfter.Length > enemysBefore.Length);
            Assert.AreEqual(enemysAfter.Length, 1);
        }

        [UnityTest]
        public IEnumerator SpawnsManyEnemies()
        {
            yield return new WaitForSeconds(11);
            var enemysAfter = GameObject.FindGameObjectsWithTag("Enemy");

            Assert.That(enemysAfter.Length >= 5);
        }

        [UnityTest]
        public IEnumerator EnemiesApproachPlayer()
        {
            yield return new WaitForSeconds(11);
            var enemysAfter = GameObject.FindGameObjectsWithTag("Enemy");

            float firstDistance = Vector3.Distance(enemysAfter[0].transform.position, life.transform.position);
            float secondDistance = Vector3.Distance(enemysAfter[1].transform.position, life.transform.position);
            float thirdDistance = Vector3.Distance(enemysAfter[2].transform.position, life.transform.position);
            float forthDistance = Vector3.Distance(enemysAfter[3].transform.position, life.transform.position);

            Assert.That(firstDistance > secondDistance);
            Assert.That(secondDistance > thirdDistance);
            Assert.That(thirdDistance > forthDistance);
        }

        [UnityTest]
        public IEnumerator SpawnsManyEnemiesUntilLifeIsZero()
        {
            yield return new WaitForSeconds(3);
            var enemysAfter = GameObject.FindGameObjectsWithTag("Enemy");

            Assert.That(enemysAfter.Length >= 1);

            life.life = 0;
            yield return new WaitForSeconds(3);

            var enemysLifeZero = GameObject.FindGameObjectsWithTag("Enemy");

            Assert.AreEqual(enemysAfter.Length, enemysLifeZero.Length);
        }
    }
}
