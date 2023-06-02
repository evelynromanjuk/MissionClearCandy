using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
public class Sound : ScriptableObject
{
    public new string name;
    public AudioClip clip;

    [Range(0.1f, 1f)]
    public float volume;

    public bool onLoop;

    [HideInInspector]
    public AudioSource source;
}
