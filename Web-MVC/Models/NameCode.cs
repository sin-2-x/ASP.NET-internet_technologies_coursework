using System;
using System.Collections.Generic;

namespace baza.Models
{
    public partial class NameCode
    {
        public uint? Oid { get; set; }
        public uint? Relnamespace { get; set; }
        public uint? Reltype { get; set; }
        public uint? Reloftype { get; set; }
        public uint? Relowner { get; set; }
        public uint? Relam { get; set; }
        public uint? Relfilenode { get; set; }
        public uint? Reltablespace { get; set; }
        public int? Relpages { get; set; }
        public float? Reltuples { get; set; }
        public int? Relallvisible { get; set; }
        public uint? Reltoastrelid { get; set; }
        public bool? Relhasindex { get; set; }
        public bool? Relisshared { get; set; }
        public char? Relpersistence { get; set; }
        public char? Relkind { get; set; }
        public short? Relnatts { get; set; }
        public short? Relchecks { get; set; }
        public bool? Relhasrules { get; set; }
        public bool? Relhastriggers { get; set; }
        public bool? Relhassubclass { get; set; }
        public bool? Relrowsecurity { get; set; }
        public bool? Relforcerowsecurity { get; set; }
        public bool? Relispopulated { get; set; }
        public char? Relreplident { get; set; }
        public bool? Relispartition { get; set; }
        public uint? Relrewrite { get; set; }
        public uint? Relfrozenxid { get; set; }
        public uint? Relminmxid { get; set; }
        public string[]? Reloptions { get; set; }
    }
}
