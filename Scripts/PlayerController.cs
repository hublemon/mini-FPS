using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{// ���콺�� ���� ���� �ٲٰ� bulletGenerator���� ����

    public GameObject bulletPrefab;
    public int weight;  //�ӵ� ����ġ

    RaycastHit hit;
    public int turnSpeed;
    Quaternion dr;

    public float moveSpeed;  //�׶��忡���� ������
    private float xRotate = 0.0f; //���� �ٶ󺸱�

    PlayerInput playerInput;   //������Ʈ�� start���� �Ҵ��Ű��

    public void Move(Vector3 dir)
    {
        transform.Translate(dir);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        //���� ���� �ֱ⿡ ���� ������

        float move_X = playerInput.move_x;
        float move_Z = playerInput.move_z;
        Vector3 move = new Vector3(move_X, 0, move_Z);

        Move(transform.TransformDirection(move) * Time.deltaTime*10);


    }

    // Update is called once per frame
    void Update()   
    {
       
           
        if (Input.GetMouseButton(1))  //������ ��ư���� ���� �ٲٱ�
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);  //hit�� �浹���� ����
            Vector3 click = hit.point;

            dr = Quaternion.LookRotation((click - transform.position).normalized);   //Ŭ���� �������� ȸ���ض�
            transform.rotation = Quaternion.Slerp(transform.rotation, dr, turnSpeed * Time.deltaTime); //���� �ð��� ȸ��

        }

    }

    
}

