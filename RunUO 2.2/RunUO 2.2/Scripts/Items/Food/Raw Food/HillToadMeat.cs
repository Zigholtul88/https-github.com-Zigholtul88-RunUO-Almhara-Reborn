using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class HillToadMeat : Food
	{
		[Constructable]
		public HillToadMeat() : this( 1 )
		{
		}

		[Constructable]
                public HillToadMeat( int amount ) : base( amount, 0x9F1 )
		{
			this.Name = "Hill Toad Meat";
			this.Hue = 176;
                        this.Stackable = true;
                        this.Amount = amount;

			this.Weight = 1.0;
			this.FillFactor = 1;
                        this.Poison = Poison.Lesser;
		}

		public HillToadMeat( Serial serial ) : base( serial )
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