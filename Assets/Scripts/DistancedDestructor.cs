using UnityEngine;
using System.Collections;

public class DistancedDestructor : MonoBehaviour
{
    [SerializeField]
    private float destructionDistance = 15f;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(CheckDistance());
    }

    private IEnumerator CheckDistance()
    {
        while (true)
        {
            if (player && Vector2.Distance(player.transform.position, transform.position) > destructionDistance)
            {
                Destroy(gameObject);
                yield break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
