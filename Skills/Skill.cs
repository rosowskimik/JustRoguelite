﻿using System;

using JustRoguelite.Utility;
using JustRoguelite.Devtools.Editor;

namespace JustRoguelite.Skills
{
    public enum SkillType { ATTACK, SPELL, DEFEND, SPECIAL };
    public enum DamageType { PHYSICAL, MAGIC };

    internal class Skill : IIdentifiable
    {
        private static uint _nextID;
        private uint _ID;
        public uint GetID() { return _ID; }
        public void SetID(uint ID) { _ID = ID; }

        public string name;
        public string description;
        public DamageType damageType;
        public List<int> values = new();

        public Skill(string name = "SkillName", string description = "", DamageType damageType = DamageType.PHYSICAL, List<int>? values = null)
        {
            _nextID++;
            _ID = _nextID;

            this.name = name;
            this.description = description;
            this.damageType = damageType;
            if (values == null)
                this.values = new();
            else
                this.values = values;
        }

        public Skill(SkillData skillData)
        {
            this.name = skillData.name;
            this.description = skillData.description;
            this.values = skillData.values;
            this.damageType = skillData.damageType;
        }

        public void DebugLog(string? localization = null)
        {
            Logger.Instance().Info($"Skill(\n\t\tID = {_ID}, Name = '{name}', \n\t\tDescription = '{description}',\n\t\tDamageType = {damageType}\n\t)", localization == null ? "Skill.DebugLog()" : $"Skill.DebugLog() -> {localization}");
        }

        public virtual bool TryToExecute(Characters.CharacterBase castingCharacter, Characters.CharacterBase targetCharacter)
        {
            Logger.Instance().Warning("You should override TryToExecute(...) function!", "Skill.TryToExecute()");

            return true;
        }

        static public uint NextID()
        {
            return _nextID++;
        }

        public void SetNextID(uint ID)
        {
            _nextID = ID + 1;
        }
    }
}
