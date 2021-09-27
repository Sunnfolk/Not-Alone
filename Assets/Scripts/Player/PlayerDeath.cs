using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private PlayerHealth _health;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            // if health <= 0
            RestartScene();
        }
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}