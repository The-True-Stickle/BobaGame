using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private GameObject player;

    public void Die()
    {
        cam.SetActive(true);
        player.SetActive(true);
    }

}
