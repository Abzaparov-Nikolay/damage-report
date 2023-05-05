using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Variable<TimeSpan> levelTime;
    [SerializeField] private Variable<Transform> player;
    [SerializeField] private Reference<int> enemyCap;
    [SerializeField] private RuntimeSet<GameObject> enemies;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float spawnHeight;
    [SerializeField] private List<Wave> waves;

    private double previousWavesTotalTime;
    private int currentWaveIndex;

    private void Update()
    {
        var now = levelTime.Value.TotalSeconds;
        if (now > previousWavesTotalTime + waves[currentWaveIndex].Duration
            && currentWaveIndex < waves.Count - 1)
        {
            previousWavesTotalTime += waves[currentWaveIndex].Duration;
            currentWaveIndex++;
        }

        if (enemies.Count >= enemyCap)
        {
            return;
        }

        var wave = waves[currentWaveIndex];
        var enemyCount = wave.Enemies.Count;
        for (var i = 0; i < enemyCount; i++)
        {
            var enemy = wave.Enemies[i];
            if (now - enemy.LastSpawnTime > enemy.SpawnInterval)
            {
                Spawn(enemy.Prefab);
                enemy.LastSpawnTime = now;
            }
        }
    }

    private void Spawn(GameObject enemyPrefab)
    {
        var position = player.Value.position.Xz() + UnityEngine.Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, position.AsXz(spawnHeight), Quaternion.identity);
    }

    [Serializable]
    public class Wave
    {
        [field: Tooltip("In seconds.")]
        [field: SerializeField] public float Duration { get; private set; }

        [field: SerializeField] public List<EnemySpawnEvent> Enemies { get; private set; }
    }

    [Serializable]
    public class EnemySpawnEvent
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }

        [field: Tooltip("In seconds.")]
        [field: SerializeField] public float SpawnInterval { get; private set; }

        [NonSerialized] public double LastSpawnTime;
    }
}


