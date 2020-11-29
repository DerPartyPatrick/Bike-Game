using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int id;
    public int collectedPresents; 

    public Level(int id, int collectedPresents)
    {
        this.id = id;
        this.collectedPresents = collectedPresents; 
    }
}
