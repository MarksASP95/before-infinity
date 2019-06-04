using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public RectTransform mPanelGameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            mPanelGameOver.gameObject.SetActive(true);
            StartCoroutine(wait(collision));
            
        }


    }

    IEnumerator wait(Collision2D collision)
    {
        yield return new WaitForSeconds(2);
        collision.transform.position = spawnPoint.position;
        mPanelGameOver.gameObject.SetActive(false);
    }
}