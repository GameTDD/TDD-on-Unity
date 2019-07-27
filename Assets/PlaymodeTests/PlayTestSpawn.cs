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

        [OneTimeSetUp]
        public void Setup()
        {
            enemyPrefab = Resources.Load("Enemy");
            Debug.Log(enemyPrefab);
            cube = new GameObject();
            cube.transform.position = new Vector3(2, 4, 6);

            world = new GameObject().AddComponent<EnemySpawner>();
            world.spawnTime = 2f;
            world.radius = 2f;
            world.enemy = enemyPrefab as GameObject;
            world.player = cube;
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
    }
}
