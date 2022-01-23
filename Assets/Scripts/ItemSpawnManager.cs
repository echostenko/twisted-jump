using System.Collections;
using System.Security.Cryptography;
using UnityEditor.EditorTools;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] float nextSpawn = 1f;
    [SerializeField] private float minTras;
    [SerializeField] private float maxTras;
    private GameObject cherry;

    private void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    private IEnumerator ItemSpawn()
    {
        while (true)
        {
             
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y, 89.97f);
            cherry = Instantiate(item, position, Quaternion.identity);
            yield return new WaitForSeconds(nextSpawn);
            Destroy(cherry, 5f);
        }
    }
}
