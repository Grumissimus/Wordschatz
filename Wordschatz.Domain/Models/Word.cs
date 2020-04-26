﻿using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models
{
    public class Word : EventSourcedAggregate
    {
        public string Term { get; set; }
        public string Meaning { get; set; }

        public ulong ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual List<MarkWord> Marks { get; set; }

        public Word()
        {

        }
    }
}