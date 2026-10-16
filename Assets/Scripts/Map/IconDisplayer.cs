using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IconDisplayer : MonoBehaviour
{
    // children of this object are icons on the map that display what mascots are occupying this location.
    // updated with every time increment, UpdateMascotList is called when this happens.

    public HorizontalLayoutGroup hlg; // high. lander. gaming
    public GameObject mapIconPrefab;

    // Start is called before the first frame update
    void Start()
    {
        hlg = GetComponent<HorizontalLayoutGroup>(); // icon holder, haven't decided where spatially it should even exist
    }

    public void UpdateMascotList(List<GameObject> list)
    {
        // clear children first
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (GameObject go in list)
        {
            // create prefab
            var icon = Instantiate(mapIconPrefab, this.transform);
            // assign sprite to the name of the mascot in the list
            Sprite iconSprite = GetIconSpriteByMascot(go);
            if (iconSprite != null)
            {
                icon.GetComponent<Image>().sprite = iconSprite;
            }

        }
    }

    public Sprite GetIconSpriteByMascot(GameObject mascot)
    {
        var circles = Resources.LoadAll("MapIcons").Cast<MapIconSO>().ToArray(); ;
        foreach (MapIconSO icon in circles)
        {
            if (icon.mascotName == mascot.GetComponent<Mascot>().mascotName.ToLower())
            {
                Debug.Log("returning icon!");
                return icon.icon;
            }
        }
        return null;
    }
}
