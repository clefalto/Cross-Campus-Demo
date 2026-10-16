using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleMenuManager : MonoBehaviour
{
    public Canvas mascotScheduleCanvas;

    public GameObject entryContainer;
    public GameObject pfb_ScheduleEntry;

    public void RegisterMascots(List<GameObject> mascotList)
    {
        foreach (GameObject mascotObj in mascotList)
        {
            Mascot mascot = mascotObj.GetComponent<Mascot>();
            var objScheduleEntry = Instantiate(pfb_ScheduleEntry, entryContainer.transform);
            objScheduleEntry.GetComponent<ScheduleEntry>().Populate(mascot.calendar, mascot.GetName());
        }
        // protip: Awake() is only called if the object is active. So setting the parent object as inactive before instantiating children makes awake never be called
        // This just keeps the mascotScheduleCanvas active until AFTER we've setup all the mascots, because we only have to do it once
        mascotScheduleCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !mascotScheduleCanvas.gameObject.activeSelf)
        {
            // show menu
            mascotScheduleCanvas.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && mascotScheduleCanvas.gameObject.activeSelf)
        {
            // hide menu
            mascotScheduleCanvas.gameObject.SetActive(false);
        }
    }
}
