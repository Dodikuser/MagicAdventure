using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        foreach (Transform obj in Canvas.transform)
        {
            Destroy(obj.gameObject);
        }
    }
}
