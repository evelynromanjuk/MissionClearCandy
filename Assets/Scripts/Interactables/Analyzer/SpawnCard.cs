using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnCard : MonoBehaviour
{
    public AnalyzerManager AnalyzerManager;
    public XRGrabInteractable Card;

    // Start is called before the first frame update
    void Start()
    {
        AnalyzerManager.SubscribeSubstanceAnalyzedEvent(Spawn);
        this.gameObject.SetActive(false);
        Card.gameObject.SetActive(false);
    }

    private void Spawn()
    {
        this.gameObject.SetActive(true);
        Card.gameObject.SetActive(true);
    }
}
