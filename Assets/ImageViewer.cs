using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour
{
    public TMP_Text Title;
    public Image Image;

    private AspectRatioFitter _aspectRatioFitter;

    private void Awake()
    {
        _aspectRatioFitter = Image.gameObject.GetComponent<AspectRatioFitter>();
    }

    public void SetImage(FileImage fileImage)
    {
        Title.text = fileImage.Title;
        Image.sprite = fileImage.Image;

        _aspectRatioFitter.aspectRatio = fileImage.AspectRatio;
    }
}
