using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalVars;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class ScheduleEntry : MonoBehaviour
{
    public GameObject mascotIconObj;
    public Image mascotIcon;

    public ScheduleDay monday;
    public ScheduleDay tuesday;
    public ScheduleDay wednesday;
    public ScheduleDay thursday;
    public ScheduleDay friday;

    public Dictionary<Day, ScheduleDay> days;


    //public GameObject tempMascot; // for testing

    private void Awake()
    {
        days = new Dictionary<Day, ScheduleDay>()
        {
            { Day.Monday, monday },
            { Day.Tuesday, tuesday },
            { Day.Wednesday, wednesday },
            { Day.Thursday, thursday },
            { Day.Friday, friday }
        };

        mascotIcon = mascotIconObj.GetComponentInChildren<Image>();
    }

    private void Start()
    {

    }

    public void Populate(Calendar mascotCalendar, string mascotName)
    {
        // handle calendar population
        for (Day d = Day.Monday; d <= Day.Friday; d++)
        {
            //List<string> slots = new List<string>();
            Dictionary<TimeSlot, Location> timeLocations = new Dictionary<TimeSlot, Location>();
            for (TimeSlot t = TimeSlot.morning; t <= TimeSlot.evening; t++)
            {
                timeLocations.Add(t, mascotCalendar.GetLocation(t, d));
            }
            days[d].SetSlots(timeLocations);
        }


        // handle the image
        // find the matching sprite for the name we're given
        mascotIcon.sprite = GetIconSpriteByMascot(mascotName);
        var capitalizedName = mascotName.Substring(0, 1).ToUpper() + mascotName.Substring(1, mascotName.Length - 1);
        mascotIconObj.GetComponentInChildren<TextMeshProUGUI>().text = capitalizedName;
    }

    // code is (almost) the exact same as in IconDisplayer.cs
    // this is very good practice!
    private Sprite GetIconSpriteByMascot(string mascotName)
    {
        var circles = Resources.LoadAll("MapIcons").Cast<MapIconSO>().ToArray(); ;
        foreach (MapIconSO icon in circles)
        {
            if (icon.mascotName == mascotName.ToLower())
            {
                return icon.icon;
            }
        }
        return null;
    }
}
