using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TEST");
    }

    public void ChangeScene(string scenename){
        Debug.Log("Scene to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
