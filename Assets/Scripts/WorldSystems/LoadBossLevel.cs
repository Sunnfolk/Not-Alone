using UnityEngine;
using UnityEngine.SceneManagement;

namespace WorldSystems
{
    public class LoadBossLevel : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            
            if (collider.gameObject.CompareTag("NextLevel"))
            {
                SceneManager.LoadScene("BossLevel");
            }
        }
    }
}
