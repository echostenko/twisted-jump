using System.Collections;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] item;
    [SerializeField] float nextSpawn = 1f;
    [SerializeField] private float minTras;
    [SerializeField] private float maxTras;
    [SerializeField] private float spawnPositionZ;

    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }
    

    private IEnumerator ItemSpawn()
    {
        while (true)
        {
            var random = Random.Range(0,item.Length);
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y, spawnPositionZ);
            Instantiate(item[random], position, Quaternion.identity);
            yield return new WaitForSeconds(nextSpawn);
        }
    }
}
