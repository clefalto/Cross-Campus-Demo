using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GlobalVars;

public class ScheduleDay : MonoBehaviour
{
    public GameObject objMorning;
    public GameObject objAfternoon;
    public GameObject objEvening;

    TextMeshProUGUI textMorning;
    TextMeshProUGUI textAfternoon;
    TextMeshProUGUI textEvening;


    private void Awake()
    {
        textMorning = objMorning.GetComponentInChildren<TextMeshProUGUI>();
        textAfternoon = objAfternoon.GetComponentInChildren<TextMeshProUGUI>();
        textEvening = objEvening.GetComponentInChildren<TextMeshProUGUI>();

        textMorning.text = "morning!";
        textAfternoon.text = "afternoon!";
        textEvening.text = "evening!";
    }

    public void SetSlots(Dictionary<TimeSlot, Location> timeLocations)
    {
        foreach (var slot in timeLocations.Keys)
        {
            if (slot == TimeSlot.morning)
            {
                if (timeLocations[slot] == Location.none)
                {
                    textMorning.text = ""; // prevent clutter
                }
                else
                {
                    textMorning.text = Calendar.LocationToString(timeLocations[slot]);
                }
            }
            else if (slot == TimeSlot.afternoon)
            {
                if (timeLocations[slot] == Location.none)
                {
                    textAfternoon.text = ""; // prevent clutter
                }
                else
                {
                    textAfternoon.text = Calendar.LocationToString(timeLocations[slot]);
                }
            }
            else if (slot == TimeSlot.evening) 
            {
                if (timeLocations[slot] == Location.none)
                {
                    textEvening.text = ""; // prevent clutter
                }
                else
                {
                    textEvening.text = Calendar.LocationToString(timeLocations[slot]);
                }
            }
        }

    }
}
