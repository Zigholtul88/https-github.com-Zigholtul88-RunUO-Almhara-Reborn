using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 15836, 15837 )]
	public class ElvenPlateChest : BaseArmor, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 19; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 90; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public ElvenPlateChest() : base( 15836 )
		{
                        Name = "Elven Plate Chest - (Lv. 54)";
			Weight = 10.0;
			Layer = Layer.InnerTorso;

			Attributes.BonusHits = 100;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 54 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 54 in order to equip this." );
				return false;
			}
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public ElvenPlateChest( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}