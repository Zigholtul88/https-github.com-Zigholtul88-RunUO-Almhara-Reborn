using System;
using Server;

namespace Server.Items
{
	public class PhilosophersHat : WizardsHat
	{
		public override int LabelNumber{ get{ return 1077602; } } // Philosopher's Hat

		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 9; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public PhilosophersHat()
		{
			Attributes.RegenMana = 1;
			Attributes.LowerRegCost = 10;
		}

		public PhilosophersHat( Serial serial ) : base( serial )
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
