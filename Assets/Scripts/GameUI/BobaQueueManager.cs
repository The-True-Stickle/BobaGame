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
        public string bobaName;
        public float timeLeft;
        public orderUI orderUI;
        public Coroutine timeDownBoba;
    }

    private List<BobaOrder> orderQueue = new List<BobaOrder>();

    [SerializeField]
    private List<BobaType> bobaTypes = new List<BobaType>();

    public void enemyAddsDrink()
    {
        AddDrinkToQueue(bobaTypes[Random.Range(0, bobaTypes.Count)]);
    }
    
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
        newOrder.bobaName = bobaType.bobaName;
        orderQueue.Add(newOrder);
        newOrder.timeDownBoba = StartCoroutine(timeDownBoba(newOrder));
    }

    public void ServeDrink(BobaType bobaType)
    {
        Debug.Log("Searching for: " + bobaType.bobaName);

        for (int i = 0; i < orderQueue.Count; i++)
        {
            Debug.Log("Checked: " + orderQueue[i].bobaName + " with " + bobaType.bobaName + "");
            if (orderQueue[i].bobaName == bobaType.bobaName)
            {
                Debug.Log("Boba has been served");
                if (orderQueue[i].timeDownBoba != null)
                {
                    StopCoroutine(orderQueue[i].timeDownBoba);

                }
                GameObject.Destroy(orderQueue[i].orderUI.orderUIObj);
                orderQueue.Remove(orderQueue[i]);
                return;
            }
        }
        Debug.Log("Boba not found");
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
        GameManager.starRating--;
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
