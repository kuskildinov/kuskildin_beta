using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Interactions : MonoBehaviour
{    
    [SerializeField] GameObject Win_panel;              //������ ��� ������
    [SerializeField] GameObject Lose_panel;             //������ ��� ���������

    private bool MousePushed;                           //�������� ������� �� �������
    private Vector2 start_pos;                          //��������� ������� ��������

    public Vector2 current_pos;                         //������� ������� �������� ��������

    private void Start()
    {
        start_pos = GetComponent<Cube_movment>().start_pos.position;
        current_pos = start_pos;
    }
    private void FixedUpdate()
    {
        MousePushed = GetComponent<Cube_movment>().MousePushed;    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //������� ������ � ������ � ������������ � �� ������
        if ((collision.gameObject.tag == "cell" || collision.gameObject.tag == "empty_cell") && MousePushed)
        {
            current_pos = collision.gameObject.transform.position;
        }

        // ���� ��� ������ ������� � ����������� Cell
        if (collision.gameObject.GetComponent<Cell>())
        {
            // ��������� ������ ������ ��� ���������� ������������ ��������
            if (collision.gameObject.GetComponent<Cell>().is_win && !MousePushed)
            {
                Win_panel.SetActive(true);
            }
            // ��������� ������ ��������� ��� ������������ ������������ ���d����
            if (!collision.gameObject.GetComponent<Cell>().is_win && !MousePushed)
            {
                Lose_panel.SetActive(true);
            }
        }            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {       
          current_pos = start_pos;                           //���������� ������� �� ��������� ���������, ���� ������ �������� ���             
    }
}
