using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int coinPoints = 100;

    [Range(0f, 1f)]
    [SerializeField] float sfxVolume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().IncreaseScoreAndUpdateUI(coinPoints);
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, sfxVolume);
        Destroy(gameObject);
    }
}
