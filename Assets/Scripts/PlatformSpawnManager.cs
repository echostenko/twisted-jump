using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] float nextSpawn = 5f;
    [SerializeField] private float minTras;
    [SerializeField] private float maxTras;
    private GameObject platform;

    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    private IEnumerator ItemSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(transform.position.x, wanted, 93.79f);
            platform = Instantiate(item, position, Quaternion.identity);
            yield return new WaitForSeconds(nextSpawn);
            Destroy(platform, 30f);
        }
    }
}
