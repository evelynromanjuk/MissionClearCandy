using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //public bool IsRobotScene;
    public FluidEntry FluidEntry;
    public SubstanceMachine SubstanceMachine;
    public Pipe Pipe;


    private bool _isRobotScene = false;
    private bool _isVertical = false;

    [SerializeField]
    Type type = new Type();

    enum Type
    {
        VersionA,
        VersionB,
        VersionC,
        VersionD
    };

    // Update is called once per frame
    void Awake()
    {
        switch (type)
        {
            case Type.VersionC:
                _isRobotScene = true;
                Debug.Log("Is Version C! _isRobotScene = " + _isRobotScene);
                break;

            case Type.VersionD:
                _isRobotScene = true;
                _isVertical = true;
                Pipe.SetHackerKeyUse();
                Debug.Log("Is Version D! _isRobotScene = " + _isRobotScene + ", _isVertical = " + _isVertical);
                break;

            default:
                break;
        }

        SubstanceMachine.SetScreenOrientation(_isVertical, _isRobotScene);
        FluidEntry.SetFontSize(_isRobotScene);
        Pipe.SetRobotInteraction(_isRobotScene);
    }
}
