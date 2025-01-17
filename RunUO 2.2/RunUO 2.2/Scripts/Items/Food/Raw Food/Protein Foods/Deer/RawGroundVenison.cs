using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class RawGroundVenison : Item
	{
		[Constructable]
		public RawGroundVenison() : this( 1 )
		{
		}

		[Constructable]
		public RawGroundVenison( int amount ) : base( 0x1727 )
		{
			Name = "raw ground venison";
			ItemID = 5927;
			Weight = 1.0;
			Hue = 2117;
			Stackable = true;
			Amount = amount;
		}

		public RawGroundVenison( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}