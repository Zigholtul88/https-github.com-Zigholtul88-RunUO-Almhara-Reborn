
using System;
using Server.Network;

namespace Server.Items
{
    public class UncookedSausagePizza : Food
    {
        public override int LabelNumber { get { return 1041337; } }

        [Constructable]
        public UncookedSausagePizza()
            : base(0x1083)
        {
        }

        public UncookedSausagePizza(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}