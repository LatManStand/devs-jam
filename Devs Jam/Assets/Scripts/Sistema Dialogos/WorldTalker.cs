using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTalker : MonoBehaviour
{

    public GameObject lastNPC;
    public GameObject lastDoor;
    // Start is called before the first frame update
    void Start()
    {
        lastNPC = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (lastDoor != null)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                lastDoor.gameObject.GetComponent<Puerta>().abre();
            }
        }

        if (lastNPC != null)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                lastNPC.gameObject.GetComponent<NPCDialogue>().talk();
            }
        }
    }


    public void setLastNPC(GameObject npc)
    {
        lastNPC = npc;
    }

    public void setLastDoor(GameObject door)
    {
        lastDoor = door;
    }
}
