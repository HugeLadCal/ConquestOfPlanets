// KHOGDEN 001115381
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UiButton : MonoBehaviour
    {
        // KH - Change from one scene to another.
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        // KH - Closes the build application.
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}