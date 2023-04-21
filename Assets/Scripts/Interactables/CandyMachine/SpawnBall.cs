using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform parent;

    public void Spawn()
    {
        GameObject b = Instantiate(BallPrefab);
        b.transform.SetParent(parent, false);
        b.transform.localPosition = new Vector3(-0.7f, 1.5f, 0);
    }
}
