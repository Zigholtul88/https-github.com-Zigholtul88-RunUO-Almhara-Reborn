using System;
using Server;

namespace Server.Items
{
	public class BarghestTooth : Item
	{
		[Constructable]
		public BarghestTooth() : this( 1 )
		{
		}

		[Constructable]
		public BarghestTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Barghest Tooth";
			Weight = 0.2;
			Hue = 0x455;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from a barghest that can be sold to butchers." );
			m.PlaySound( 0x52C );
		}

		public BarghestTooth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}