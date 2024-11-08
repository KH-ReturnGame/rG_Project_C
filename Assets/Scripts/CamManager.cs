using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager: MonoBehaviour
{
    public Camera main;
    public Camera Ui;
    bool cam_check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && cam_check == false){
            cam_check = true;
            MainCam();
        }

        if (Input.GetKeyDown(KeyCode.V) && cam_check == true)
        {
            cam_check = false;
            MainCam();
        }
    }

    void MainCam()
    {
        main.enabled = true;
        Ui.enabled = false;
    }

    void UiCam()
    {
        main.enabled = false;
        Ui.enabled = true;
    }
}
