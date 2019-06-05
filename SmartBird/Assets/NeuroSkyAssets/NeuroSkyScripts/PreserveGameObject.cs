using UnityEngine;
using System.Collections;

public class PreserveGameObject : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
