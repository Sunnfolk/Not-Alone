using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cutscenes
{
    public class Loadlvl1 : MonoBehaviour
    {
        public void LoadScene1()
        {
            SceneManager.LoadScene("Level1");
        }

        public void LoadScene1_1()
        {
            SceneManager.LoadScene("Level1 1");
        }

        public void LoadSceneEnd()
        {
            SceneManager.LoadScene("End Scene");
        }
    }
}
