using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject ShopCamera;

    void Start(){
        MainCamera.SetActive(true);
        ShopCamera.SetActive(false);
    }


    public void ChangeCamera(){
        MainCamera.SetActive(!MainCamera.active);
        ShopCamera.SetActive(!ShopCamera.active);
    }

}
