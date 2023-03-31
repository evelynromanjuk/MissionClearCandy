using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour, IInteractable
{
    private Pipe _pipe;

    // Start is called before the first frame update
    void Start()
    {
        Pipe parentPipe = transform.parent.gameObject.GetComponent<Pipe>();
        if(parentPipe)
        {
            _pipe = parentPipe;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        _pipe.OpenClosePipe();
    }
}
