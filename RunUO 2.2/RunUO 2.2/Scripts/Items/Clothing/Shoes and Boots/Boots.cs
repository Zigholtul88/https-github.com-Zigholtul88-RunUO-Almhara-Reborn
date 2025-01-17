using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x170b, 0x170c )]
	public class Boots : BaseShoes
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 33; } }

		[Constructable]
		public Boots() : this( 0 )
		{
		}

		[Constructable]
		public Boots( int hue ) : base( 0x170B, hue )
		{
			Weight = 3.0;
		}

		public Boots( Serial serial ) : base( serial )
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