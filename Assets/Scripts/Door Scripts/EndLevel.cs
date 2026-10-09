using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public void Pressed()
    {
        SceneManager.LoadScene("EndLevel", LoadSceneMode.Single);
    }
}
