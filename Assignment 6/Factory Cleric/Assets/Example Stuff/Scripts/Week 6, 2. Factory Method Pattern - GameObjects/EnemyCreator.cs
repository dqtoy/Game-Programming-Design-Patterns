using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPatternWithGameObjects
{

    public class EnemyCreator : NPCCreator
    {
        private GameObject enemyPrefab;

        public override GameObject CreateNPCPrefab(string type)
        {
            if (type.Equals("Zombie"))
            {
                enemyPrefab = Resources.Load<GameObject>("Capsule");

            }
            else if (type.Equals("Vampire"))
            {
                enemyPrefab = Resources.Load<GameObject>("Sphere");

            }
            else if (type.Equals("Werewolf"))
            {
                enemyPrefab = Resources.Load<GameObject>("Cube");

            }

            return enemyPrefab;
        }

        public override GameObject AddNPCScript(GameObject prefab, string type)
        {


            if (type.Equals("Zombie"))
            {

                //If there is not already a Zombie script attached to the prefab, attach one
                if (enemyPrefab.GetComponent<EnemyZombie>() == null)
                {
                    enemyPrefab.AddComponent<EnemyZombie>();
                }
            }
            else if (type.Equals("Vampire"))
            {

                //If there is not already a Vampire script attached to the prefab, attach one
                if (enemyPrefab.GetComponent<EnemyVampire>() == null)
                {
                    enemyPrefab.AddComponent<EnemyVampire>();
                }

            }
            else if (type.Equals("Werewolf"))
            {

                //If there is not already a Werewolf script attached to the prefab, attach one
                if (enemyPrefab.GetComponent<EnemyWerewolf>() == null)
                {
                    enemyPrefab.AddComponent<EnemyWerewolf>();
                }
            }

            return enemyPrefab;
        }


    }
}