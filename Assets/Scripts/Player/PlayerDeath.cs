using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    private IEnumerator goToCredits()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("creadit screan");
    }


}
