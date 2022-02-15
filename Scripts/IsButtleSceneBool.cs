
using System.Collections.Generic;

public static class IsButtleSceneBool
{
   
   public static bool isBattleScene;

   public static int indexOfEnemy = 0;

   public static List<int?> indexEnemyToDestroy = new List<int?>();
   
   public static  void ChangeBatleState()
   {
      isBattleScene = !isBattleScene;
   }

   public static bool GetindexxBattleScene()
   {
      return isBattleScene;
   }

   public static void SetIndexEnemy(int index)
   {
      indexOfEnemy = index;
   }

   public static int GetIndexEnemy()
   {
      return indexOfEnemy;
   }

   public static void SetInedxToDestroy(int index)
   {
      indexEnemyToDestroy.Add(index);
   }
   
   public static List<int?> GetIndexEnemyToDestroy()
   {
      return indexEnemyToDestroy;
   }
}
