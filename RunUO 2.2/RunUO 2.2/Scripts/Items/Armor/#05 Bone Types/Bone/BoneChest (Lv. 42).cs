using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x144f, 0x1454 )]
	public class BoneChest : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		public override int AosStrReq{ get{ return 70; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public BoneChest() : base( 0x144F )
		{
                        Name = "Bone Chest - (Lv. 42)";
			Weight = 6.0;
			Attributes.BonusHits = 40;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 42 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 42 in order to equip this." );
				return false;
			}
		}

		public BoneChest( Serial serial ) : base( serial )
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