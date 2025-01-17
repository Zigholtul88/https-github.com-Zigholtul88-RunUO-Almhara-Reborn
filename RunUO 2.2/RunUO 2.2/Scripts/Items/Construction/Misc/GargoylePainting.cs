using System;

namespace Server.Items
{
        [FlipableAttribute(0x403D, 0x403E)]
	public class GargoylePainting : Item
	{
		[Constructable]
		public GargoylePainting() : base(0x403D)
		{
                        Name = "Gargoyle Painting";
			Weight = 10.0;
		}

		public GargoylePainting(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
