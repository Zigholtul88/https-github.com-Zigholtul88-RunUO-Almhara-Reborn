using System;

namespace Server.Items
{
	public class IronBolt : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public IronBolt() : this( 1 )
		{
		}

		[Constructable]
		public IronBolt( int amount ) : base( 0x1BFB )
		{
			Name = "Iron Bolt";
                        Hue = 1923;
			Stackable = true;
			Amount = amount;
		}

		public IronBolt( Serial serial ) : base( serial )
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