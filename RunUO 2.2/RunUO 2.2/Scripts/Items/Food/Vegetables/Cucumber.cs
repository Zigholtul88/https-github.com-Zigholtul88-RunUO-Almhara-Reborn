using System;
using Server.Network;

namespace Server.Items
{
        [FlipableAttribute( 0xC80, 0xC81 )]
	public class Cucumber : Food
	{
		[Constructable]
		public Cucumber() : this( 1 )
		{
		}

		[Constructable]
		public Cucumber( int amount ) : base( amount, 0xC81 )
		{
                        Name = "Cucumber";
                        Hue = 0x2FF;
			FillFactor = 1;
		}

		public Cucumber( Serial serial ) : base( serial )
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