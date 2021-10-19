using UnityEngine;
using UnityEngine.SceneManagement;

namespace WorldSystems
{
    public class LoadBossLevel : MonoBehaviour
    {

        public FadeInOut _fade;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                _fade.FadeOut();
            }
        }
    }
}
