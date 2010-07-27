﻿using System;
using System.IO;
using MeleeLib.System;

namespace MeleeLib.DatHandler
{
    public class Section1Header : Node<Header>
    {
        public const int Length = 0x8;
        public string Name { get { return File.RawData.GetAsciiString((int) (Parent.StringOffsetBase + StringOffset)); } }
        private readonly int _index;
        public Section1Data Data { get { return new Section1Data(this); } }
        public Section1Header(Header parent, int index)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            if (parent.SectionType1Count < index) throw new IndexOutOfRangeException();
            _parent = parent;
            _index = index;
        }
        public buint StringOffset { get { return RawData.GetUInt32(0x00); } }
        public buint DataOffset   { get { return RawData.GetUInt32(0x04); } }
        private readonly Header _parent;
        public override Header Parent
        {
            get { return _parent; }
        }

        public override File File
        {
            get { return Parent.File; }
        }

        public override ArraySlice<byte> RawData
        {
            get
            {
                if ((int)Parent.Datasize    != Parent.Datasize ||
                    (int)Parent.OffsetCount != Parent.OffsetCount)
                    throw new IOException();
                File.RawData.Slice((int)Parent.Datasize + (int)Parent.OffsetCount*4 + _index*8, Length);
            }
        }
    }
}