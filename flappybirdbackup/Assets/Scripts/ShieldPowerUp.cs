using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    [SerializeField] public float shieldDuration = 7f;

    private bool isPowerUpActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Shield power-up collected");
            ActivatePowerUp(collision.gameObject);
        }
    }

    private void ActivatePowerUp(GameObject player)
    {
        isPowerUpActive = true;

        Fly playerr = FindObjectOfType<Fly>();
        if (playerr != null)
        {
            playerr.ActivateShield();
        }

        StartCoroutine(DeactivatePowerUp(player));
    }

    private IEnumerator DeactivatePowerUp(GameObject player)
    {
        yield return new WaitForSeconds(shieldDuration);

        isPowerUpActive = false;


        if (player != null)
        {
            Fly playerr = player.GetComponent<Fly>();
            playerr.DeactivateShield();
        }

        Destroy(gameObject);
    }

    public void SetShieldDuration(float duration)
    {
        shieldDuration = duration;
    }


}
