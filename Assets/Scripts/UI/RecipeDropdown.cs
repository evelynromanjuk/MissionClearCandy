using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeDropdown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    private void Awake()
    {
        _dropdown = this.gameObject.GetComponent<TMP_Dropdown>();
    }

    public void OnRecipeSelected()
    {
        Debug.Log(_dropdown.options[_dropdown.value].text);
    }
}
