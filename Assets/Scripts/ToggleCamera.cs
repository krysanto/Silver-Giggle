using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject ShopCamera;
    public Transform CharacterFolder;

    void Start(){
        MainCamera.SetActive(false);
        ShopCamera.SetActive(true);
    }

    public void ChangeCamera(){
        MainCamera.SetActive(!MainCamera.activeInHierarchy);
        ShopCamera.SetActive(!ShopCamera.activeInHierarchy);
    }

    private void Update()
    {
        CharacterFolder.transform.position = new Vector3(MainCamera.activeInHierarchy ? 0 : 30, 0, 0);
    }

}
