using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    public void GamePlay(string name)
    {
        SceneManager.LoadScene(name);
    }
}
