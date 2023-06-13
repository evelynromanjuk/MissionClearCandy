using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void StartGame(int versionID)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(versionID);

        //Scene Overview
        //0 - Main Menu
        //1 - Version A (Hacker 2D)
        //2 - Version B (Hacker 2D)
        //3 - Version C (Hacker 3D)
        //4 - Version D (Hacker 3D)
    }
}
