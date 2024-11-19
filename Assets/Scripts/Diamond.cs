using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.UpdateDiamonds();
            }
            else
            {
                Debug.LogError("GameManager instance is null. Please check the setup.");
            }

            StartCoroutine(FadeAndDestroy());
        }
    }

    private IEnumerator FadeAndDestroy()
    {
        float duration = 0.5f;
        Vector3 initialScale = transform.localScale;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float scale = Mathf.Lerp(1, 0, t / duration);
            transform.localScale = initialScale * scale;
            yield return null;
        }

        Destroy(gameObject);
    }
}
