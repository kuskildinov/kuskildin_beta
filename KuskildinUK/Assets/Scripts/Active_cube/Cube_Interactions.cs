using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Interactions : MonoBehaviour
{    
    [SerializeField] GameObject Win_panel;              //Панель при победе
    [SerializeField] GameObject Lose_panel;             //Панель при поражении

    private bool MousePushed;                           //проверка нажатия на квадрат
    private Vector2 start_pos;                          //начальная позиция квадрата

    public Vector2 current_pos;                         //текущая позиция привязки квадрата

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
        //квадрат входит в ячейку и привязывется к ее центру
        if ((collision.gameObject.tag == "cell" || collision.gameObject.tag == "empty_cell") && MousePushed)
        {
            current_pos = collision.gameObject.transform.position;
        }

        // если это ячейка таблицы с компонентом Cell
        if (collision.gameObject.GetComponent<Cell>())
        {
            // активация панели ПОБЕДА при правильном расположении квадрата
            if (collision.gameObject.GetComponent<Cell>().is_win && !MousePushed)
            {
                Win_panel.SetActive(true);
            }
            // активация панели Поражение при неправильном расположении кваdрата
            if (!collision.gameObject.GetComponent<Cell>().is_win && !MousePushed)
            {
                Lose_panel.SetActive(true);
            }
        }            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {       
          current_pos = start_pos;                           //возвращает квадрат на начальное положение, если других привязок нет             
    }
}
