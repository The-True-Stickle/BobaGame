using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private List<CinemachinePath> paths = new List<CinemachinePath>();

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (GameManager.gameState == "ACTIVE")
        {
            GameObject enemy = Instantiate(enemyPrefab, paths[Random.Range(0, paths.Count)].transform.position, Quaternion.identity);
            enemy.GetComponent<CinemachineDollyCart>().m_Path = paths[Random.Range(0, paths.Count)];
            yield return new WaitForSeconds(8f);

        }
    }

}
