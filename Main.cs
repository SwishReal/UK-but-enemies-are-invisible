using UnityEngine;
using HarmonyLib;
using BepInEx;
using System.Runtime.Serialization.Formatters;
using System.IO;
using BepInEx.Logging;
using HarmonyLib.Tools;

namespace UKbutEnemiesInvisible
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "swish.ultrakill.enemiesAreInvisible";
        public const string pluginName = "UK but enemies are invisible";
        public const string pluginVersion = "1.0.0";

        public GameObject[] enemies;

        public void Awake()
        {
            Logger.LogInfo("UkBEaI is started!");
        }

        public void Update()
        {
            MusicManager musicManager = GameObject.FindObjectOfType<MusicManager>();
            if (musicManager.IsInBattle() == true)
            {
                FindAllEnemies();
                MakeEnemiesInvisible();
            }
        }

        public void FindAllEnemies()
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

        public void MakeEnemiesInvisible()
        {
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            }
        }

        public void MakeEnemiesVisible()
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            }
        }
    }
}
