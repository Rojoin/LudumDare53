using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class House : MonoBehaviour
{
    [SerializeField] private TMP_Text deliverText = null;
    [SerializeField] private Canvas canvas = null;
    [SerializeField] private int messageTime = 3;


    public static int count = 0;
    public int index = 0;
    public bool active = false;
    public bool killOnStart = false;

    public int position = 0;
    public bool hasPosition = false;

    string deliveryMessage = "Gracias capo, muchas gracias!";

    void Awake()
    {
        index = count;
        count++;
    }

    void Start()
    {
        if (killOnStart)
        {
            Destroy(this);
        }
    }
    
    IEnumerator ShowDeliverMessage()
    {
        deliverText.text = deliveryMessage;
        yield return new WaitForSeconds(messageTime);
        canvas.enabled = false;
    }

    private void ShowMessage()
    {
        StartCoroutine(ShowDeliverMessage());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!active) return;
        if(collision.CompareTag("Player"))
        {
            Player p = collision.GetComponent<Player>();
            if (p.hasPackage)
            {
                ShowMessage();
                p.DropPackage();
                Bag.ResetBag(Destination.HOUSE);
            }
        }
    }

}
