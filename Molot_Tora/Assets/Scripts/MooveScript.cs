using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveScript : MonoBehaviour
{
    public Player player;
  
    void OnMouseDrag()
    {

        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //player.transform.position = Vector3.MoveTowards(player.transform.position,  new Vector2(mousePosition.x, player.transform.position.y), 0.2f);

        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 mousePosition  = Input.mousePosition;
        //mousePosition.x = mousePosition.x > 5f ? 5f : mousePosition.x;
        //mousePosition.x = mousePosition.x < -5f ? -5f : mousePosition.x;
        //player.transform.position = new Vector2(mousePosition.x, this.transform.position.y);


        // Vector2 mousePosition = new Vector2(Input.mousePosition.x, player.position.y); // переменной записываютьс€ координаты мыши по иксу и игрику
        // Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваетьс€ переменна€ с координатами мыши
        // player.position = objPosition; // и собственно объекту записываютьс€ координаты  



        //Vector2 targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //targetPos.y = 0; // I fixed Y value to zero you may change this to value you want
        //player.position = targetPos;
        //if ((Vector2)transform.position != targetPos)
        //{
        //    player.position = Vector2.MoveTowards(player.position, targetPos, speed * Time.deltaTime);
        //
        //}

        //if (Input.mousePosition.x > Screen.width / 2)
        //    player.GetComponent<Rigidbody>().MovePosition(new Vector3(Input.mousePosition.x / 100000, 1, 0));
        //else
        //    player.GetComponent<Rigidbody>().MovePosition(new Vector3(-(Screen.width - Input.mousePosition.x) / 100000, 1, 0));



       if (Input.mousePosition.x > Screen.width / 2)
       {


           if (player.transform.position.x <= 4.7f)
           {
               if (player.transform.position.x >= 5)
               {
                   player.transform.position = new Vector3(5, 0, 0);

               }
               // player.transform.Rotate(0,-0.1f,0);
               player.transform.Translate(new Vector3(Input.mousePosition.x / 7800 * (-1), 0, 0));
           }

       }
       else
       {
           if (player.transform.position.x >= -4.2f)
           {
               if (player.transform.position.x <= -5)
               {
                   player.transform.position = new Vector3(-5, 0, 0);
               }
               //player.transform.Rotate(0,0.1f, 0);
               player.transform.Translate(new Vector3(-(Screen.width - Input.mousePosition.x) / 7800 * (-1), 0, 0));
           }
       }
        
    }
}
