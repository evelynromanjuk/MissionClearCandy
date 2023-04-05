using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fluid", menuName = "Fluid")]
public class Fluid : ScriptableObject
{
    public Material material;

    public string FluidName;
    public float CurrentPercentage;
    public float GoalPercentage;
    public bool ReachedGoal;

}
