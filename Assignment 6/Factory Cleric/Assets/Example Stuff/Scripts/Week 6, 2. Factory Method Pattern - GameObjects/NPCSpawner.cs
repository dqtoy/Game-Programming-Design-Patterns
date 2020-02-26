using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPatternWithGameObjects
{
    public class NPCSpawner : MonoBehaviour
    {
        public float spawnDistance;
        private Transform playerOrCameraTransform;

        public NPCCreator npcCreator;
        public bool npcCreatorIsAlly;

        public List<GameObject> enemies;
        public List<GameObject> allies;



        // Start is called before the first frame update
        void Start()
        {
            spawnDistance = 20f;
            playerOrCameraTransform = Camera.main.transform;

            npcCreator = new AllyCreator();
            npcCreatorIsAlly = true;
        }

        public GameObject SpawnNPC(string type)
        {
            GameObject npc = null;
            
            //Assign prefab to npc
            npc = npcCreator.CreateNPCPrefab(type);

            //Set the spawn position
            float xRand = Random.Range(-10, 10);
            float zRand = Random.Range(-10, 10);
            Vector3 spawnPos = playerOrCameraTransform.position +
                               playerOrCameraTransform.forward * spawnDistance +
                               new Vector3(xRand, 0, zRand);


            //If there is an NPC script on the NPC prefab, destroy it
            if (npc.GetComponent<NPC>() != null)
            {
                NPC npcScriptToRemove = npc.GetComponent<NPC>();
                DestroyImmediate(npcScriptToRemove,true);
            }

            //Add script to our npc 
            npcCreator.AddNPCScript(npc, type);

            //Spawn the npc
            npc = Instantiate(npc, spawnPos, playerOrCameraTransform.rotation);
                         
            //return the npc instance
            return npc;

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("tab key pressed");
                Debug.Log(npcCreator.GetType());
                Debug.Log(npcCreator.GetType().Equals("FactoryMethodPatternWithGameObjects.EnemyCreator"));

                if (npcCreatorIsAlly)
                {
                    npcCreator = new EnemyCreator();
                    npcCreatorIsAlly = false;
                }
                else
                {
                    npcCreator = new AllyCreator();
                    npcCreatorIsAlly = true;
                }

                Debug.Log(npcCreator.GetType());
                Debug.Log(npcCreator.GetType().Equals("FactoryMethodPatternWithGameObjects.EnemyCreator"));

            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (npcCreatorIsAlly)
                {
                    allies.Add(SpawnNPC("Zombie"));
                }
                else
                {
                    enemies.Add(SpawnNPC("Zombie"));
                }
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (npcCreatorIsAlly)
                {
                    allies.Add(SpawnNPC("Vampire"));
                }
                else
                {
                    enemies.Add(SpawnNPC("Vampire"));
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (npcCreatorIsAlly)
                {
                    allies.Add(SpawnNPC("Werewolf"));
                }
                else
                {
                    enemies.Add(SpawnNPC("Werewolf"));
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {

                foreach (GameObject ally in allies)
                {
                    //using polymorphism with GetComponent, Attack is called on the supertype NPC
                    ally.GetComponent<NPC>().Attack();
                }

                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<NPC>().Attack();
                }

            }

        }
    }
}