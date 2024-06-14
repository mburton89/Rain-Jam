using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType
    { 
        time,
        doomEternal
    }

    public PowerupType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<WaterDrop>()) return;

        if (type == PowerupType.time)
        {
            HUD.instance.timeRemaining += 3;
        }

        SoundManager.Instance.PlayPowerup13Sound();
        Destroy(gameObject);
    }
}
