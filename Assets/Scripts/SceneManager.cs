using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneManager : MonoBehaviour
{
    //public bool IsRobotScene;
    public FluidEntry FluidEntry;
    public SubstanceMachine SubstanceMachine;
    public FrameFillMachine FrameFillMachineLab;
    public FrameFillMachine FrameFillMachinePC;
    public SecurityManager SecurityManager;
    public Pipe Pipe;
    public Door Door;
    public Lever Lever;
    public Button AnalyzerStartButton2D;
    public XRSimpleInteractable AnalyzerStartButton3D;
    public GameObject Frame_Lab_Analyzer;
    public AnalyzerManager AnalyzerManager;


    private bool _isRobotScene = false;
    private bool _scannerIsVertical = false;
    private bool _doorActivatable = false;
    private bool _doorOpenable = true;
    private bool _usesRobotTip = false;

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
            case Type.VersionA:
                _doorActivatable = true;
                FrameFillMachinePC.Initialize(_isRobotScene);
                AnalyzerStartButton2D.interactable = false;
                break;

            case Type.VersionB:
                _doorOpenable = false;
                FrameFillMachinePC.Initialize(_isRobotScene);
                Lever.DeactivateSimpleInteractable();
                AnalyzerStartButton3D.enabled = false;
                break;

            case Type.VersionC:
                _isRobotScene = true;
                Debug.Log("Is Version C! _isRobotScene = " + _isRobotScene);
                break;

            case Type.VersionD:
                _isRobotScene = true;
                _scannerIsVertical = true;
                _doorActivatable = true;
                _usesRobotTip = true;
                Pipe.SetHackerKeyUse();
                Debug.Log("Is Version D! _isRobotScene = " + _isRobotScene + ", _isVertical = " + _scannerIsVertical);
                break;

            default:
                break;
        }

        SubstanceMachine.SetScreenOrientation(_scannerIsVertical, _isRobotScene);
        FluidEntry.SetFontSize(_isRobotScene);
        Pipe.SetRobotInteraction(_isRobotScene);
        Door.InitializeDoor(_isRobotScene, _doorActivatable, _doorOpenable);
        FrameFillMachineLab.SetRobotTip(_usesRobotTip);
        FrameFillMachineLab.Initialize(_isRobotScene);
        SecurityManager.Initizalize(_isRobotScene);
        AnalyzerManager.InitializeAnalyzer(_isRobotScene, true);

        //FrameFillMachineManager --> isRobotScene
    }

    private void Start()
    {
        if(!_isRobotScene)
        {
            Frame_Lab_Analyzer.SetActive(false);
        }
    }
}
