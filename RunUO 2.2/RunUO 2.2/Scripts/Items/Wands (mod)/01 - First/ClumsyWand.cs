using System;
using Server;
using Server.Spells.First;
using Server.Targeting;

namespace Server.Items
{
	public class ClumsyWand : BaseWand
	{
		[Constructable]
		public ClumsyWand() : base( WandEffect.Clumsiness, 5, 50 )
		{
                Name = "Clumsy Wand";
		}

		public ClumsyWand( Serial serial ) : base( serial )
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

		public override void OnWandUse( Mobile from )
		{
			Cast( new ClumsySpell( from, this ) );
		}
	}
}