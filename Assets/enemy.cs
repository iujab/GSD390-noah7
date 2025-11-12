using UnityEngine;

public class enemy
{
    //[STATICS] shared amongst all enemy class instances
    public static int enemyCount = 0;
    //I plan to add "zombies" that chase you

    public enemy()
    {
        enemyCount++;
    }
}
