using System;
using Server;

namespace Server.Items
{
	public class RingOfTheSavant : GoldRing
	{
		public override int LabelNumber{ get{ return 1077608; } } // Ring of the Savant

		[Constructable]
		public RingOfTheSavant()
		{
			Attributes.BonusInt = 5;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
		}

		public RingOfTheSavant( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
