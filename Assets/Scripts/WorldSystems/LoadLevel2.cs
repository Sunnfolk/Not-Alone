using UnityEngine;
using UnityEngine.SceneManagement;

namespace WorldSystems
{
    public class LoadLevel2 : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            
            if (collider.gameObject.CompareTag("NextLevel"))
            {
                SceneManager.LoadScene("Level 2");
            }
        }
    }
}
