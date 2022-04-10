using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FL
{
    public class MailBox : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.GetComponent<Player>().StopForMail();
        }
    }
}