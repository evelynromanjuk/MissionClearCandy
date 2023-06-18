using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzerCheckLight : MonoBehaviour
{
    public Material LightGreen;
    public Material LightRed;
    public AnalyzerManager AnalyzerManager;

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        AnalyzerManager.SubscribeCheckedCorrect(ChangeLight);
        _renderer = gameObject.GetComponent<Renderer>();
    }

    void ChangeLight(bool allCorrect)
    {
        if(allCorrect)
        {
            _renderer.material = LightGreen;
        }
        else
        {
            _renderer.material = LightGreen;
        }
    }
}
