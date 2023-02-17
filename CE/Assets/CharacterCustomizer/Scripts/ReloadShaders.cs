using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class ReloadShaders : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ReloadShadersAtStart());
    }

    IEnumerator ReloadShadersAtStart()
    {
        // Wait for one frame to let other scripts initialize
        yield return null;

        // Reload shaders
        Shader.WarmupAllShaders();
        Debug.Log("Shaders reloaded!");
    }
}
