using System;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class SausOnionMushPizza : Food
	{
		[Constructable]
		public SausOnionMushPizza() : this( 1 )
		{
		}

		[Constructable]
		public SausOnionMushPizza( int amount ) : base( amount, 0x1040 )
		{
			this.Weight = 1.0;
			this.FillFactor = 5;
                        this.Name = "Sausage Onion and Mushroom Pizza";
		}

		public SausOnionMushPizza( Serial serial ) : base( serial )
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