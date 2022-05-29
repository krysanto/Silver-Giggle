using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject ShopCamera;
    public Transform CharacterFolder;

    // defines what camera should be active at the start of the game
    void Start(){
        MainCamera.SetActive(false);
        ShopCamera.SetActive(true);
    }

    // turns all active cameras off, and all inactive cameras on
    public void ChangeCamera(){
        MainCamera.SetActive(!MainCamera.activeInHierarchy);
        ShopCamera.SetActive(!ShopCamera.activeInHierarchy);
    }

    // moves the Character Folder to the current camera
    private void Update()
    {
        CharacterFolder.transform.position = new Vector3(MainCamera.activeInHierarchy ? 0 : 30, 0, 0);
    }

}
