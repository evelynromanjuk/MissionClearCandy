using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source: https://www.youtube.com/watch?v=WyqjGW7euVc&ab_channel=DanielStringer

public class VRNoPeeking : MonoBehaviour
{
    [SerializeField] LayerMask _collisionLayer;
    [SerializeField] float _fadeSpeed;
    [SerializeField] float _sphereCheckSize = .15f;

    private Material _cameraFadeMat;
    private bool _isCameraFadedOut = false;

    void Awake()
    {
        _cameraFadeMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.CheckSphere(transform.position, _sphereCheckSize, _collisionLayer, QueryTriggerInteraction.Ignore))
        {
            CameraFade(1f);
            _isCameraFadedOut = true;
        }
        else
        {
            if (!_isCameraFadedOut)
                return;

            CameraFade(0f);
        }
    }

    public void CameraFade(float targetAlpha)
    {
        var fadeValue = Mathf.MoveTowards(_cameraFadeMat.GetFloat("_AlphaValue"), targetAlpha, Time.deltaTime * _fadeSpeed);
        _cameraFadeMat.SetFloat("_AlphaValue", fadeValue);

        if (fadeValue <= 0.01f)
            _isCameraFadedOut = false;
    }


}
