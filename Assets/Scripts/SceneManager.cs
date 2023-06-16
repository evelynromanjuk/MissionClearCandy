using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneManager : MonoBehaviour
{
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
    public Button AnalyzerActivateButton2D;
    public Button AnalyzerCheckButton2D;
    public GameObject Frame_Lab_Analyzer;
    public AnalyzerManager AnalyzerManager;
    public CMScreenManager CMScreenManager;
    public TankControl TankControl;
    public Valve Valve;
    public EmptyButton EmptyButton;
    public PlayerInteract PlayerInteract;


    private bool _isRobotScene = false;
    private bool _scannerIsVertical = false;
    private bool _doorActivatable = false;
    private bool _doorOpenable = true;
    private bool _analyzerActivatable = false;
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
                AnalyzerCheckButton2D.interactable = false;
                AnalyzerActivateButton2D.gameObject.SetActive(true);
                _analyzerActivatable = true;
                TankControl.Initialize(false);//_codeIsExternal == false, because hacker does not enter it
                break;

            case Type.VersionB:
                _doorOpenable = false;
                FrameFillMachinePC.Initialize(_isRobotScene);
                Lever.DeactivateSimpleInteractable();
                AnalyzerStartButton3D.enabled = false;
                CMScreenManager.Initialize(true);
                TankControl.Initialize(true); //_codeIsExternal == true, because hacker enters it
                Valve.Initialize(true);
                EmptyButton.Initialize(true);
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
                _analyzerActivatable = true;
                Pipe.SetHackerKeyUse();
                PlayerInteract.Initialize(true);
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
        AnalyzerManager.InitializeAnalyzer(_isRobotScene, _analyzerActivatable);

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
