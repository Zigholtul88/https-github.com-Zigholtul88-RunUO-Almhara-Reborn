using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class HornedTribalMask : BaseHat
	{
		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public HornedTribalMask() : this( 0 )
		{
		}

		[Constructable]
		public HornedTribalMask( int hue ) : base( 0x1549, hue )
		{
                  Name = "a horned tribal mask";
			Weight = 2.0;
		}

		public override bool Dye( Mobile from, DyeTub sender )
		{
			from.SendLocalizedMessage( sender.FailMessage );
			return false;
		}

		public HornedTribalMask( Serial serial ) : base( serial )
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
