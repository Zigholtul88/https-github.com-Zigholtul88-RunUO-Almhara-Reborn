using System;
using Server;

namespace Server.Items
{
	public class KelpieEye : Item
	{
		[Constructable]
		public KelpieEye() : this( 1 )
		{
		}

		[Constructable]
		public KelpieEye( int amount ) : base( 0x5749 )
		{
			Name = "Kelpie Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.2;
                        Hue = 1266;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "eyeball of a kelpie that can be sold to butchers." );
			m.PlaySound( 0xA8 );
		}

		public KelpieEye( Serial serial ) : base( serial )
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