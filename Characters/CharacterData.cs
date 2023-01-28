﻿using JustRoguelite.Utility;
using System.Text.Json;

namespace JustRoguelite.Characters
{
    internal class CharacterData
    {
        public uint id;
        public string name;
        public string description;
        public CharacterStats characterBaseStats;
        public CharacterType characterType;

        public List<uint> skillIDs = new();
        public List<uint> itemIDs = new();

        public CharacterData(uint ID, string name, string description, CharacterStats characterBaseStats, CharacterType characterType) 
        {
            this.id = ID;
            this.name = name;
            this.description = description;
            this.characterBaseStats = characterBaseStats;
            this.characterType = characterType;
        }

        public CharacterData(uint ID, string name, string description, CharacterStats characterBaseStats, CharacterType characterType, List<uint> skillIDs, List<uint> itemIDs)
        {
            this.id = ID;
            this.name = name;
            this.description = description;
            this.characterBaseStats = characterBaseStats;
            this.characterType = characterType;

            if(skillIDs != null && skillIDs.Count() > 0)
                this.skillIDs = skillIDs;
            if(itemIDs != null && itemIDs.Count() > 0)
                this.itemIDs = itemIDs;
        }

        public void DebugPrint()
        {
            Logger.Instance().Info($"CharacterData([{id}], {name}, {description}, {characterType})", "CharacterData - DebugPrint()");
        }

        internal Dictionary<string, string> ToDict()
        {
            Dictionary<string, string> characterDataDict = new();
            characterDataDict.Add("id", id.ToString());
            characterDataDict.Add("name", name);
            characterDataDict.Add("description", description);
            characterDataDict.Add("characterBaseStats", JsonSerializer.Serialize(characterBaseStats));
            characterDataDict.Add("characterType", characterType.ToString());

            return characterDataDict;
        }
    }
}
