using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChanger : MonoBehaviour
{
    private int _groundLayer;
    private BoxCollider _boxCollider;

    private float _xCenterValue;
    private float _xSizeValue;

    private float _yCenterValue;
    private float _ySizeValue;

    private float _centerAddition = 0.03f;
    private float _sizeAddition = 0.06f;

    private void Start()
    {
        _groundLayer = LayerMask.NameToLayer("Ground");
        _boxCollider = GetComponent<BoxCollider>();

        if(_boxCollider != null)
        {
            _xCenterValue = _boxCollider.center.x;
            _xSizeValue = _boxCollider.size.x;

            _yCenterValue = _boxCollider.center.y;
            _ySizeValue = _boxCollider.size.y;
        }
        else
        {
            Debug.Log(gameObject.name + " has no BoxCollider.");
        }
        
    }

    private void Update()
    {
        if(transform.position.y < 0.0f)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 0f, transform.position.z);
            transform.position = newPosition;
        }
    }



    //Add values on top of original Y-Values to make collider larger in Y-direction
    private void OnCollisionEnter(Collision collision)
    {
        float newCenter;
        float newSize;

        float _centerAddition2 = _centerAddition;
        float _sizeAddition2 = _sizeAddition;

        if (collision.gameObject.layer == _groundLayer & (_boxCollider != null))
        {
            if (gameObject.name.Contains("Kabel"))
            {
                if (gameObject.name.Contains("Kabel1"))
                {
                    SetBoxColliderX(0.1f, 0.2f);
                }
                else
                {
                    newCenter = _xCenterValue + _centerAddition;
                    newSize = _xSizeValue + _sizeAddition;
                    SetBoxColliderX(newCenter, newSize);
                }
                
            }
            else
            {
                newCenter = _yCenterValue + _centerAddition;
                newSize = _ySizeValue + _sizeAddition;
                SetBoxColliderY(newCenter, newSize);
            }
            Debug.Log("This object: " + gameObject.name + " fell to the floor");
        }

        //if (collision.gameObject.layer == _groundLayer & (_boxCollider != null))
        //{

        //    newCenter = _yCenterValue + _centerAddition;
        //    newSize = _ySizeValue + _sizeAddition;
        //    SetBoxColliderY(newCenter, newSize);

        //    Debug.Log("This object: " + gameObject.name + " fell to the floor");
        //}
    }

    //Set Y-values back to originalf
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.layer == _groundLayer & (_boxCollider != null))
        {
            if(gameObject.name.Contains("Kabel"))
            {
                SetBoxColliderX(_xCenterValue, _xSizeValue);
            }
            else
            {
                SetBoxColliderY(_yCenterValue, _ySizeValue);
            }
            Debug.Log("This object fell to the floor");
           
        }
    }

    private void SetBoxColliderY(float yCenter, float ySize)
    {
        _boxCollider.center = new Vector3(_boxCollider.center.x, yCenter, _boxCollider.center.z);

        _boxCollider.size = new Vector3(_boxCollider.size.x, ySize, _boxCollider.size.z);
    }

    private void SetBoxColliderX(float xCenter, float xSize)
    {
        _boxCollider.center = new Vector3(xCenter, _boxCollider.center.y, _boxCollider.center.z);

        _boxCollider.size = new Vector3(xSize, _boxCollider.size.y, _boxCollider.size.z);
    }

}
