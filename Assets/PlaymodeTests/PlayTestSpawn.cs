using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTestSpawn
    {
        public Object enemyPrefab;
        public EnemySpawner world;
        public GameObject cube;

        [SetUp]
        public void Setup()
        {
            enemyPrefab = Resources.Load("Enemy");
            cube = new GameObject();
            cube.transform.position = new Vector3(2, 4, 6);

            world = new GameObject().AddComponent<EnemySpawner>();
            world.spawnTime = 2f;
            world.radius = 10f;
            world.enemy = enemyPrefab as GameObject;
            world.player = cube;
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(world);
            GameObject.Destroy(cube);
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

            float firstDistance = Vector3.Distance(enemysAfter[0].transform.position, cube.transform.position);
            float secondDistance = Vector3.Distance(enemysAfter[1].transform.position, cube.transform.position);
            float thirdDistance = Vector3.Distance(enemysAfter[2].transform.position, cube.transform.position);
            float forthDistance = Vector3.Distance(enemysAfter[3].transform.position, cube.transform.position);

            Assert.That(firstDistance > secondDistance);
            Assert.That(secondDistance > thirdDistance);
            Assert.That(thirdDistance > forthDistance);
        }
    }
}
