using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTalker : MonoBehaviour
{

    public GameObject lastNPC;
    // Start is called before the first frame update
    void Start()
    {
        lastNPC = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastNPC != null)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                lastNPC.gameObject.GetComponent<NPCDialogue>().talk();
            }
        }
    }


    public void setLastNPC(GameObject npc)
    {
        lastNPC = npc;
    }
}
