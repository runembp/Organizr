﻿namespace Organizr.Domain.Entities
{
    public class MemberGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsOpen { get; set; }
    }
}