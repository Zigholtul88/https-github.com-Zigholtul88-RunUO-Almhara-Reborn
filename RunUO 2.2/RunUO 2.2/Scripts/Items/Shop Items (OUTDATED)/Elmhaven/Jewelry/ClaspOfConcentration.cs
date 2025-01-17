using System;
using Server;

namespace Server.Items
{
	public class ClaspOfConcentration : SilverBracelet
	{
		public override int LabelNumber{ get{ return 1077695; } } // Clasp of Concentration

		[Constructable]
		public ClaspOfConcentration()
		{
			Attributes.RegenStam = 1;
			Attributes.RegenMana = 1;
			Resistances.Fire = 10;
			Resistances.Cold = 10;
		}

		public ClaspOfConcentration( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
