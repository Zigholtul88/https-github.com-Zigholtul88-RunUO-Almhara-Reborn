using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class RawBeefPrimeRib : Food, ICarvable
	{
		public void Carve( Mobile from, Item item )
		{
			if ( !Movable )
				return;

			base.ScissorHelper( from, new RawBeefSlice(), 5 );

			from.SendMessage( "You slice the sirloin into thin strips." );
		}

		[Constructable]
		public RawBeefPrimeRib() : this( 1 )
		{
		}

		[Constructable]
                public RawBeefPrimeRib( int amount ) : base( amount, 0x9F1 )
		{
			Weight = 1.0;
			Stackable = true;
			Amount = amount;
			Name = "raw beef prime rib";
		}

		public RawBeefPrimeRib( Serial serial ) : base( serial )
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