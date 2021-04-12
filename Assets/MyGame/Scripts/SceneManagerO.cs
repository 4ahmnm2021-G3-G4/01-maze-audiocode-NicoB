using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerO : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MazeScene", LoadSceneMode.Additive);
    }
}
