using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_movment : MonoBehaviour
{
    public Transform start_pos;           //��������� ������� ��������� ��������
    public bool MousePushed = false;      //�������� ������� �� �������

    private Vector2 current_pos;          //������� ������� �������� ��������

    private void Start()
    {
        current_pos = start_pos.position;
    }
    private void FixedUpdate()
    {
        current_pos = GetComponent<Cube_Interactions>().current_pos;
        transform.position = current_pos;
        Moving();              
    }

    /// <summary>
    /// ����������� ��� �������
    /// </summary>
    private void Moving()
    {
        Vector2 cursorPosition = Input.mousePosition;                       //��������� ������� ������� 
        cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);    //������������ ������� ������� ������ ������
        if (MousePushed)
        {
            transform.position = new Vector2(cursorPosition.x, cursorPosition.y + 0.5f);
        }
    }

    private void OnMouseDown()
    {
        MousePushed = true;
    }
    private void OnMouseUp()
    {
        MousePushed = false;
    }

   
}
