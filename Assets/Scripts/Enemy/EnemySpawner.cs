using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }
    public List<GameObject> Enemys = new List<GameObject>();

    [SerializeField] private Transform _zonePoint1;
    [SerializeField] private Transform _zonePoint2;

    private void OnDisable()
    {
        MainLinks.Instance.StartCounter.StartGame -= FirstSpawnEnemy;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        MainLinks.Instance.StartCounter.StartGame += FirstSpawnEnemy;
        MainLinks.Instance.Shop.ShopDestroy += ShopSpawnEnemy;
    }

    public void FirstSpawnEnemy()
    {
        StartCoroutine(SpawnEnemyFirt());
    }

    private IEnumerator SpawnEnemyFirt()
    {
        SpawnBatInFirtZone(true);
        yield return new WaitForSeconds(1);
        SpawnBatInFirtZone(true);
    }

    private void SpawnBatInFirtZone(bool setTrriger)
    {
        Vector3 randomPosition = GetRandomPositionBetweenPoints(_zonePoint1.position, _zonePoint2.position);
        randomPosition.y = 4.2f;

        GameObject Bat = Instantiate(PrefabContainer.Instance.Bat, randomPosition, Quaternion.Euler(0, 164, 0));
        if (setTrriger) Bat.GetComponent<Enemy>().EnemyDie += SecondSpawnEnemy;
    }

    private Vector3 GetRandomPositionBetweenPoints(Vector3 point1, Vector3 point2)
    {
        float t = UnityEngine.Random.Range(0f, 1f);
        return Vector3.Lerp(point1, point2, t);
    }

    public void SecondSpawnEnemy()
    {
        if (Enemys.Count == 0)
        {
            StartCoroutine(SpawnEnemySecond());
        }
    }
    private IEnumerator SpawnEnemySecond()
    {
        yield return new WaitForSeconds(1);
        SpawnSkeletonInFirtZone();
        yield return new WaitForSeconds(7);
        SpawnSkeletonInFirtZone();
    }
    private void SpawnSkeletonInFirtZone()
    {
        Vector3 randomPosition = GetRandomPositionBetweenPoints(_zonePoint1.position, _zonePoint2.position);
        randomPosition.y = 1f;

        GameObject Skeleton = Instantiate(PrefabContainer.Instance.Sceleton, randomPosition, Quaternion.Euler(0, 164, 0));
    }

    public void ShopSpawnEnemy()
    {
        StartCoroutine(SpawnEnemyAfterShop());
    }
    private IEnumerator SpawnEnemyAfterShop()
    {
        SpawnBatInFirtZone(false);
        yield return new WaitForSeconds(3);
        SpawnSkeletonInFirtZone();
    }
}
