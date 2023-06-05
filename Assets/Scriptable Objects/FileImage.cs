using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FileImage", menuName = "FileImage")]
public class FileImage : ScriptableObject
{
    public string Title;
    public Sprite Image;
    public float AspectRatio = 0f;

    private float _height;
    private float _width;

    private void OnEnable()
    {
        _height = Image.rect.height;
        _width = Image.rect.width;

        AspectRatio = _width / _height;
    }

}
