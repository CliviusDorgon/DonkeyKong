using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugDontDestroyObjects : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start DebugDontDestroyObjects script.");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) // Druk op D tijdens Play Mode
        {
            Scene dontDestroyOnLoadScene = SceneManager.GetSceneByName("DontDestroyOnLoad");

            if (dontDestroyOnLoadScene.IsValid())
            {
                GameObject[] rootObjects = dontDestroyOnLoadScene.GetRootGameObjects();
                Debug.Log("Objects in DontDestroyOnLoad:");
                foreach (GameObject obj in rootObjects)
                {
                    Debug.Log($"Object: {obj.name}");
                }
            }
            else
            {
                Debug.Log("DontDestroyOnLoad scène niet gevonden.");
            }
        }
    }
}
