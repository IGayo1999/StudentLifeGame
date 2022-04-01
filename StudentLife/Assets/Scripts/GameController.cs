using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI fullnessUI;
    public TextMeshProUGUI energyUI;
    public TextMeshProUGUI motivationUI;
    public TextMeshProUGUI restfulnessUI;
    public TextMeshProUGUI peacefulnessUI;
    public TextMeshProUGUI calendarUI;
    public int day = 1;
    public int month = 1;
    public int hour = 8;
    public int minute = 30;
    public Canvas activityConfirmation;
    public Canvas transportConfirmation;
    public Canvas taskCompleted;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player1= GameObject.FindGameObjectWithTag("Player");
        player = player1.GetComponent<Player>();
        calendarUI.text = day.ToString() + "/" + month.ToString() + "\n" + hour.ToString() + ":" + minute.ToString();
        activityConfirmation.gameObject.SetActive(false);
        transportConfirmation.gameObject.SetActive(false);
        taskCompleted.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fullnessUI.text = "Fullness: " + player.fullness.ToString();
        energyUI.text = "Energy: " + player.energy.ToString();
        motivationUI.text = "Motivation: " + player.motivation.ToString();
        restfulnessUI.text = "Restfulness: " + player.restfulness.ToString();
        peacefulnessUI.text = "Peacefulness: " + player.peacefulness.ToString();
        

    }
}
