using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class Teriyaki : Item
	{
		[Constructable]
		public Teriyaki() : base( 0xE2C )
		{
			Stackable = true;
			Hue = 0x362;
			Name = "Teriyaki";
		}

		public Teriyaki( Serial serial ) : base( serial )
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