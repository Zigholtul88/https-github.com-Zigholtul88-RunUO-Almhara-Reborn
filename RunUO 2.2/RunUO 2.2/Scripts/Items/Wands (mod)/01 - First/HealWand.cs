using System;
using Server;
using Server.Spells.First;
using Server.Targeting;

namespace Server.Items
{
	public class HealWand : BaseWand
	{
		[Constructable]
		public HealWand() : base( WandEffect.Healing, 10, 50 )
		{
                Name = "Heal Wand";
		}

		public HealWand( Serial serial ) : base( serial )
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
			Cast( new HealSpell( from, this ) );
		}
	}
}