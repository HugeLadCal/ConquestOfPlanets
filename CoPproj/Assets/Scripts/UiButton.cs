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

        // KH - Activate a inputted gameobject.
        public void ActivateGameObject(GameObject obj)
        {
            obj.SetActive(true);
        }

        // KH - Deactivate a inputted gameobject.
        public void DeactivateGameObject(GameObject obj)
        {
            obj.SetActive(false);
        }

        // KH - Closes the build application.
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}