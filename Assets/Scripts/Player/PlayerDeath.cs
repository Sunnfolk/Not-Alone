using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private PlayerHealth _health;

    private void Start()
    {
        _health = GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            if (_health.health <= 0)
            {
                RestartScene();
            }
            
        }

        if (col.gameObject.tag == "DeathZone")
        {
            RestartScene();
        }
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}