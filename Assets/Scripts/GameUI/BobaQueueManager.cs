using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobaQueueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject orderQueueObj;
    [SerializeField]
    private GameObject orderUIContainer;

    [System.Serializable]
    public struct orderUI
    {
        public GameObject orderUIObj;
        public Image image;
        public Slider slider;
    }

    [System.Serializable]
    public struct BobaOrder
    {
        public BobaType bobaType;
        public float timeLeft;
        public orderUI orderUI;
    }

    private List<BobaOrder> orderQueue = new List<BobaOrder>();

    public void AddDrinkToQueue(BobaType bobaType)
    {
        BobaOrder newOrder = new BobaOrder();
        newOrder.bobaType = bobaType;
        newOrder.timeLeft = 18;
        GameObject newOrderObj = Instantiate(orderQueueObj, orderUIContainer.transform);
        newOrder.orderUI.image = newOrderObj.GetComponentsInChildren<Image>()[1];
        newOrder.orderUI.slider = newOrderObj.GetComponentInChildren<Slider>();
        newOrder.orderUI.slider.value = 1;
        newOrder.orderUI.image.sprite = bobaType.bobaImage;
        newOrder.orderUI.orderUIObj = newOrderObj;
        orderQueue.Add(newOrder);
        StartCoroutine(timeDownBoba(newOrder));
    }

    private void Start()
    {

        
    }

    private IEnumerator timeDownBoba(BobaOrder order)
    {
        float timeLeft = order.timeLeft;

        for (int i = 0; i < timeLeft; i++)
        {
            yield return new WaitForSecondsRealtime(1);
            order.timeLeft--;
            order.orderUI.slider.value = order.timeLeft / timeLeft;
        }
        Debug.Log("Boba has failed");
        orderQueue.Remove(order);
        GameObject.Destroy(order.orderUI.orderUIObj);

    }

    private void FixedUpdate()
    {
        /*
        for (int i = 0; i < orderQueue.Count; i++)
        {
            BobaOrder order = orderQueue[i];
            order.timeLeft = order.timeLeft - Time.deltaTime;
            Debug.Log("Time left: " + order.timeLeft);
            orderQueue[i].orderUI.slider.value = order.timeLeft / 12;

            if (order.timeLeft <= 0)
            {
                Debug.Log("Boba has failed");

                orderQueue.Remove(order);
            }
        } */

    }

}
