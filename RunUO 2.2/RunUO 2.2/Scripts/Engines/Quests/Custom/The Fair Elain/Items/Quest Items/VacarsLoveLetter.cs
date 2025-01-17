using System;

namespace Server.Items
{
	public class VacarsLoveLetter : Item
	{
		[Constructable]
		public VacarsLoveLetter() : base( 0x14ED )
		{
                        Name = "Vacar's Love Letter";
		        Weight = 1.0;

			LootType = LootType.Blessed;
                }

		public VacarsLoveLetter( Serial serial ) : base( serial )
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