using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string scenename){
        Debug.Log("Scene to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
