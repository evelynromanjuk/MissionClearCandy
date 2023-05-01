using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public bool IsRobotScene;
    public FluidEntry FluidEntry;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Awake()
    {
        FluidEntry.SetFontSize(IsRobotScene);
    }
}
