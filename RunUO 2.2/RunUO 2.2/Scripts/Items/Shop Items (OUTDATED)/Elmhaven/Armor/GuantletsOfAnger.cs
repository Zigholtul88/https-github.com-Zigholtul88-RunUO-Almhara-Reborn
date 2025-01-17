using System;
using Server;

namespace Server.Items
{
	public class GuantletsOfAnger : PlateGloves
	{
		public override int LabelNumber{ get{ return 1094902; } } // Gauntlets of Anger [Replica]

		public override int BasePhysicalResistance{ get{ return 4; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public GuantletsOfAnger()
		{
			Hue = 0x29b;

			Attributes.BonusHits = 25;
			Attributes.DefendChance = 5;
		}

		public GuantletsOfAnger( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
