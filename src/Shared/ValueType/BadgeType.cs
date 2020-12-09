﻿using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerusDate.Shared.ValueType
{
    [Owned]
    public class BadgeType
    {
        /// <summary>
        /// only for ef core
        /// </summary>
        protected BadgeType()
        {
        }

        public BadgeType(int MaxLevel, string ClassIcon, string Title, string Description)
        {
            this.MaxLevel = MaxLevel;
            this.ClassIcon = ClassIcon;
            this.Title = Title;
            this.Description = Description;
        }

        public int Level { get; private set; }

        [Computed]
        [NotMapped]
        public int MaxLevel { get; private set; }

        [Computed]
        [NotMapped]
        public string ClassIcon { get; private set; }

        [Computed]
        [NotMapped]
        public string Title { get; private set; }

        [Computed]
        [NotMapped]
        public string Description { get; private set; }

        public void IncreaseLevel()
        {
            if (Level == MaxLevel) return;

            Level++;
        }

        public void DecreaseLevel()
        {
            if (Level == 0) return;

            Level--;
        }

        public bool Completed() => Level == MaxLevel;
    }
}