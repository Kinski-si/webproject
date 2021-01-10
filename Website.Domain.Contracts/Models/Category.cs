﻿using System;
using System.Collections.Generic;

namespace Website.Domain.Contracts.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public IEnumerable<Clothes> Clothes { get; set; }
    }
}