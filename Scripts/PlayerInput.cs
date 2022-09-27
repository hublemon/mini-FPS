using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveX = "Horizontal";
    public string moveZ = "Vertical";
    public string mouseX = "Mouse X";

    // Start is called before the first frame update
        //�ܺο��� �� �б⸸ ����
        public float move_x { get; private set; }
        public float move_z { get; private set; }
        public float mouse_x { get; private set; } //�ϴ� ���ܵ���


    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxis(moveX);
        move_z = Input.GetAxis(moveZ);
        mouse_x = Input.GetAxis(mouseX);
    }
}