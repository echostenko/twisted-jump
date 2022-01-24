using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] item;
    [SerializeField] float nextSpawn = 5f;
    [SerializeField] private float spawnPosition;
    private GameObject platform;

    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    private IEnumerator ItemSpawn()
    {
        while (true)
        {
            var random = Random.Range(0,item.Length);
            var position = new Vector3(transform.position.x, spawnPosition, 23.55f);
            platform = Instantiate(item[random], position, Quaternion.identity);
            yield return new WaitForSeconds(nextSpawn);
            Destroy(platform, 50f);
        }
    }
}
