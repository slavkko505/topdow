using System.Collections.Generic;
using UnityEngine;

public class DisaibleEnemyInLevel : MonoBehaviour
{
    private void Start()
    {
        DestroyEnemyInMap(IsButtleSceneBool.GetIndexEnemyToDestroy());
    }

    public void DestroyEnemyInMap(List<int?> list)
    {
        if (list != null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                foreach (var child in list)
                {
                    if (i == child)
                    {
                        Destroy(transform.GetChild(i).gameObject);
                    }
                }   
            }
        }
    }
    
}
